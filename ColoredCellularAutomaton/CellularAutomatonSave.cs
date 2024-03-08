using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredCellularAutomaton
{
    public class CellularAutomatonSave
    {
        public Cell EmptyCell { get; }
        public int GridWidth { get; }
        public int GridHeight { get; }
        public int MutationChance { get; set; }
        public Cell[,] Grid { get; set; }
        public List<Cell> AvailableCells { get; }
        public uint Generation { get; set; }

        public CellularAutomatonSave(int gridWidth, int gridHeight)
        {
            EmptyCell = new()
            {
                IsAliveCell = false
            };
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            MutationChance = 130;
            Grid = new Cell[GridWidth, GridHeight];
            AvailableCells = new()
            {
                EmptyCell
            };
            Clear();
        }

        public CellularAutomatonSave(byte[] data)
        {
            EmptyCell = new()
            {
                IsAliveCell = false
            };
            
            AvailableCells = new();

            using MemoryStream stream = new(data);
            using BinaryReader reader = new(stream);

            GridWidth = reader.ReadInt32();
            GridHeight = reader.ReadInt32();
            Generation = reader.ReadUInt32();
            MutationChance = reader.ReadInt32();
            Grid = new Cell[GridWidth, GridHeight];

            ushort availableCellsCount = reader.ReadUInt16();

            for (ushort i = 0; i < availableCellsCount; i++)
            {
                AvailableCells.Add(new(reader.ReadBytes(reader.ReadUInt16())));
            }

            for (int y = 0; y < GridHeight; y++)
            {
                for(int x = 0; x < GridWidth; x++)
                {
                    Grid[x, y] = AvailableCells[reader.ReadInt32()];
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return Grid[x.WrapNumber(0, GridWidth - 1), y.WrapNumber(0, GridHeight - 1)];
        }

        public List<Cell> GetNeighbours(int x, int y)
        {
            List<Cell> neighbours = new();
            for (int cY = -1; cY < 2; cY++)
            {
                for (int cX = -1; cX < 2; cX++)
                {

                    int gridX = x + cX;
                    int gridY = y + cY;

                    if (cX == 0 && cY == 0) continue;

                    try
                    {
                        neighbours.Add(GetCell(gridX, gridY));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return neighbours;
        }

        public Cell MutateCell(IEnumerable<Cell> sourceCells)
        {
            if (Random.Shared.Next(0, MutationChance) != 0)
                return Random.Shared.Next(0, 100) != 0 ? sourceCells.ElementAt(Random.Shared.Next(0, sourceCells.Count())) : EmptyCell;

            IEnumerable<Cell> validCells = sourceCells.Where(sc => sc.IsAliveCell);
            Cell mutatedCell = new();
            IEnumerable<int> surviveRandomValues = Enumerable.Range(0, 9).Select(_ => Random.Shared.Next(2));
            IEnumerable<int> birthRandomValues = Enumerable.Range(0, 9).Select(_ => Random.Shared.Next(2));

            for (int i = 0; i < 9; i++)
            {
                if (!mutatedCell.SurviveConditions[i] && validCells.Any(cell => cell.SurviveConditions[i]) || Random.Shared.Next(0, 1000) == 0)
                {
                    mutatedCell.SurviveConditions[i] = true;
                }

                if (mutatedCell.SurviveConditions[i])
                {
                    mutatedCell.SurviveConditions[i] = surviveRandomValues.ElementAt(i) == 0;
                }

                if (!mutatedCell.BirthConditions[i] && validCells.Any(cell => cell.BirthConditions[i]) || Random.Shared.Next(0, 1000) == 0)
                {
                    mutatedCell.BirthConditions[i] = true;
                }

                if (mutatedCell.BirthConditions[i])
                {
                    mutatedCell.BirthConditions[i] = birthRandomValues.ElementAt(i) == 0;
                }
            }

            return mutatedCell;
        }

        public void Simulate()
        {
            Cell[,] nextGrid = new Cell[GridWidth, GridHeight];

            List<Cell> cellsOnGrid = new()
            {
                EmptyCell
            };

            int batchSize = 100;

            Parallel.For(0, GridHeight / batchSize, batchIndex =>
            {
                int startRow = batchIndex * batchSize;
                int endRow = Math.Min((batchIndex + 1) * batchSize, GridHeight);
                Parallel.For(startRow, endRow, y =>
                {
                    Parallel.For(0, GridWidth, x =>
                    {
                        nextGrid[x, y] = GetNextCell(x, y);
                        if (!cellsOnGrid.Contains(nextGrid[x, y])) cellsOnGrid.Add(nextGrid[x, y]);
                    });
                });
            });

            AvailableCells.RemoveAll(c => !cellsOnGrid.Contains(c));

            Generation++;
            Grid = nextGrid;
        }

        public void Clear()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Grid[x, y] = EmptyCell;
                }
            }
        }

        public Cell GetNextCell(int x, int y)
        {
            Cell cell = GetCell(x, y);

            if (!AvailableCells.Contains(cell)) return EmptyCell;

            List<Cell> neighbours = GetNeighbours(x, y);

            int sameNeighbours = neighbours.Count(n => n.Equals(cell));
            int aliveNeighbours = neighbours.Count(n => n.IsAliveCell);
            int aliveSameNeighbours = neighbours.Count(n => n.IsAliveCell && n.Equals(cell));

            if (!cell.IsAliveCell)
            {
                List<Cell> possibleCells = AvailableCells.Where(c => c is not null && c.IsAliveCell && c.BirthConditions[aliveNeighbours] && neighbours.Contains(c)).ToList();
                if (!possibleCells.Any()) return EmptyCell;

                Cell mutatedCell = MutateCell(possibleCells);
                if (!AvailableCells.Contains(mutatedCell))
                {
                    AvailableCells.Add(mutatedCell);
                }

                return mutatedCell;
            }
            else if (cell.IsAliveCell)
            {
                if (cell.SurviveConditions[aliveSameNeighbours]) return cell;
            }
            return EmptyCell;
        }

        public byte[] Serialize()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            writer.Write(GridWidth);
            writer.Write(GridHeight);
            writer.Write(Generation);
            writer.Write(MutationChance);

            writer.Write((ushort)AvailableCells.Count);

            for (int i = 0; i < AvailableCells.Count; i++)
            {
                byte[] cellData = AvailableCells[i].Serialize();
                writer.Write((ushort)cellData.Length);
                writer.Write(cellData);
            }

            for (int y = 0; y < GridHeight; y++)
            {
                for(int x = 0; x < GridWidth; x++)
                {
                    writer.Write(AvailableCells.IndexOf(Grid[x, y]));
                }
            }

            writer.Flush();

            return stream.ToArray();
        }
    }
}
