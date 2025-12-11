using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;
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

        public static void GenerateTerrain(int Seed = 0)
        {
            Random random = Seed == 0 ? new Random() : new Random(Seed);
            int height = (Game.Height / 3) * 2;
            int randomWater = random.Next(95, 100);
            int LastWaterBlockX = -10;
            int LastWaterBlockY = -10;

            for (int x = 0; x < Game.Width; x++)
            {
                for (int y = Game.Height - 1; y >= 0; y--)
                {
                    if (y >= height)
                    {                                                                                                                                                                                                                                                                       
                        //if (((LastWaterBlockX == x + 1 || LastWaterBlockX == x - 1) || (LastWaterBlockY == y + 1 || LastWaterBlockY == y - 1)) && randomWater >= 95)
                        //{
                        //    TerrainMap[x, y] = 4; // Water block
                        //    LastWaterBlockX = x;
                        //    LastWaterBlockY = y;
                        //    randomWater = random.Next(1, 101);
                        //}
                        //else
                        //{
                            TerrainMap[x, y] = 1; // Ground block
                        //}
                    }
                    else
                    {
                        TerrainMap[x, y] = 0; // Air block
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
