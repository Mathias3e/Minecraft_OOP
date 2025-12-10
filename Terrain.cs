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
            TerrainMap = new int[Game.Height, Game.Width];
        }

        public static void GenerateTerrain()
        {
            Random random = new Random();
            int height = (Game.Height / 3) * 2;

            for (int x = 0; x < Game.Width; x++)
            {
                for (int y = Game.Height - 1; y >= 0; y--)
                {
                    if (y >= height)
                    {
                        TerrainMap[y, x] = 1;
                    }
                    else
                    {
                        TerrainMap[y, x] = 0;
                    }
                }

                int randomUpDown = random.Next(1, 101);

                if (randomUpDown <= 20)
                {
                    height++;
                }
                else if (randomUpDown <= 40)
                {
                    height--;
                }
                else if (randomUpDown <= 45)
                {
                    height += 2;
                }
                else if (randomUpDown <= 50)
                {
                    height -= 2;
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
