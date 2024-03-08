using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredCellularAutomaton
{
    public static class CCAEnv
    {
        public static Color[] Palette { get; }
        public static CellularAutomatonSave LoadedSave { get; set; }

        static CCAEnv()
        {
            Palette = new Color[18];

            try
            {
                using Bitmap bmp = new("Palette.png");

                for (int i = 0; i < Palette.Length; i++)
                {
                    Palette[i] = bmp.GetPixel(i % 9, i / 9);
                }
            }
            catch
            {
                Console.WriteLine("Failed to load color palette.");
            }

            LoadedSave = new(1, 1);
        }
    }
}
