using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredCellularAutomaton
{
    public class Cell
    {
        public bool[] SurviveConditions { get; }
        public bool[] BirthConditions { get; }
        public bool IsAliveCell { get; set; }

        public Cell()
        {
            SurviveConditions = new bool[9];
            BirthConditions = new bool[9];
            IsAliveCell = true;
        }

        public Cell(bool[] surviveConditions, bool[] birthConditions)
        {
            SurviveConditions = surviveConditions;
            BirthConditions = birthConditions;
        }

        public Color GetColor()
        {
            float red = 0;
            float green = 0;
            float blue = 0;
            float alpha = 0;

            for (int i = 0; i < SurviveConditions.Length; i++)
            {
                red += SurviveConditions[i] ? CCAEnv.Palette[i].R : 0;
                green += SurviveConditions[i] ? CCAEnv.Palette[i].G : 0;
                blue += SurviveConditions[i] ? CCAEnv.Palette[i].B : 0;
                alpha += SurviveConditions[i] ? CCAEnv.Palette[i].A : 255;
            }

            for (int i = 0; i < BirthConditions.Length; i++)
            {
                red += BirthConditions[i] ? CCAEnv.Palette[i + 8].R : 0;
                green += BirthConditions[i] ? CCAEnv.Palette[i + 8].G : 0;
                blue += BirthConditions[i] ? CCAEnv.Palette[i + 8].B : 0;
                alpha += BirthConditions[i] ? CCAEnv.Palette[i + 8].A : 255;
            }

            return Color.FromArgb((int)(alpha % 256f), (int)(red % 256f), (int)(green % 256f), (int)(blue % 256f));
        }

        public byte[] Serialize()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            writer.Write(IsAliveCell);

            writer.Write((byte)SurviveConditions.Length);
            for(int i = 0; i < SurviveConditions.Length; i++)
            {
                writer.Write(SurviveConditions[i]);
            }

            writer.Write((byte)BirthConditions.Length);
            for (int i = 0; i < BirthConditions.Length; i++)
            {
                writer.Write(BirthConditions[i]);
            }
            writer.Flush();

            return stream.ToArray();
        }

        public Cell(byte[] data)
        {
            using MemoryStream stream = new(data);
            using BinaryReader reader = new(stream);

            IsAliveCell = reader.ReadBoolean();

            int surviveConditionsLength = reader.ReadByte();
            SurviveConditions = new bool[surviveConditionsLength];
            for(int i = 0; i < surviveConditionsLength; i++)
            {
                SurviveConditions[i] = reader.ReadBoolean();
            }

            int birthConditionsLength = reader.ReadByte();
            BirthConditions = new bool[birthConditionsLength];
            for (int i = 0; i < birthConditionsLength; i++)
            {
                BirthConditions[i] = reader.ReadBoolean();
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Cell c) return false;

            return c.SurviveConditions.SequenceEqual(SurviveConditions) && c.BirthConditions.SequenceEqual(BirthConditions);
        }

        public override int GetHashCode()
        {
            return SurviveConditions.GetHashCode() ^ BirthConditions.GetHashCode();
        }
    }
}
