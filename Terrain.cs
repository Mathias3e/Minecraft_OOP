using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal static class Terrain
    {
        public static int[,] TerrainMap { get; private set; }

        public static void InitializeTerrain()
        {
            TerrainMap = new int[Game.Width, Game.Height];
        }

        public static void GenerateTerrain()
        {
            Random random = new Random(3);
            int height = (Game.Height / 3) * 2;

            for (int x = 0; x < Game.Width; x++)
            {
                for (int y = Game.Height - 1; y >= 0; y--)
                {
                    if (y >= height)
                    {
                        TerrainMap[x, y] = 1;
                    }
                    else
                    {
                        TerrainMap[x, y] = 0;
                    }
                }

                int randomUpDown = random.Next(1, 101);

                if (randomUpDown <= 25)
                {
                    height++;
                }
                else if (randomUpDown <= 50)
                {
                    height--;
                }

                if (height < 2)
                {
                    height = 2;
                }

                if (height > Game.Height - 2)
                {
                    height = Game.Height - 2;
                }
            }
        }
    }
}
