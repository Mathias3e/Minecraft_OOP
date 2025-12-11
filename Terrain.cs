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

        public static void GenerateTerrain(int Seed)
        {
            bool isTree1 = false;
            bool isTree2 = false;

            Random random = Seed == 0 ? new Random() : new Random(Seed);
            int height = (Game.Height / 3) * 2;

            int seePosX = random.Next(3, Game.Width - 7 - 1);
            int tree1PosX = random.Next(3, Game.Width - 3 - 1);
            int tree2PosX = random.Next(3, Game.Width - 3 - 1);
            int tree3PosX = random.Next(3, Game.Width - 3 - 1);

            for (int x = 0; x < Game.Width; x++)
            {
                if (x == seePosX)
                {
                    TerrainMap[x, height] = 1;
                    TerrainMap[x + 1, height] = 4;
                    TerrainMap[x + 2, height] = 4;
                    TerrainMap[x + 3, height] = 4;
                    TerrainMap[x + 4, height] = 4;
                    TerrainMap[x + 5, height] = 4;
                    TerrainMap[x + 6, height] = 1;

                    TerrainMap[x, height + 1] = 1;
                    TerrainMap[x + 1, height + 1] = 1;
                    TerrainMap[x + 2, height + 1] = 4;
                    TerrainMap[x + 3, height + 1] = 4;
                    TerrainMap[x + 4, height + 1] = 4;
                    TerrainMap[x + 5, height + 1] = 1;
                    TerrainMap[x + 6, height + 1] = 1;

                    for (int i = x; i < x + 7; i++)
                    {
                        for (int j = height + 2; j < Game.Height; j++)
                        {
                            TerrainMap[i, j] = 1;
                        }
                    }

                    for (int i = x; i < x + 7; i++)
                    {
                        for (int j = height - 1; j >= 0; j--)
                        {
                            TerrainMap[i, j] = 9;
                        }
                    }

                    x += 6;
                }
                else if ((x == tree2PosX || x == tree1PosX || x == tree3PosX) && height > 3)
                {
                    TerrainMap[x + 1, height - 4] = 3;
                    TerrainMap[x + 1, height - 3] = 3;
                    TerrainMap[x + 1, height - 1] = 2;
                    TerrainMap[x + 1, height - 2] = 2;
                    TerrainMap[x + 2, height - 3] = 3;
                    TerrainMap[x, height - 3] = 3;
                    TerrainMap[x + 2, height - 1] = 9;
                    TerrainMap[x, height - 1] = 9;
                    TerrainMap[x + 2, height - 2] = 9;
                    TerrainMap[x, height - 2] = 9;
                    TerrainMap[x + 2, height - 4] = 9;
                    TerrainMap[x, height - 4] = 9;

                    for (int i = x; i < x + 3; i++)
                    {
                        for (int j = height; j < Game.Height; j++)
                        {
                            TerrainMap[i, j] = 1;
                        }
                    }

                    for (int i = x; i < x + 3; i++)
                    {
                        for (int j = height - 5; j >= 0; j--)
                        {
                            TerrainMap[i, j] = 9;
                        }
                    }

                    x += 2;
                }
                else
                {
                    for (int y = Game.Height - 1; y >= 0; y--)
                    {
                        if (y >= height)
                        {
                            TerrainMap[x, y] = 1; // Ground block
                        }
                        else
                        {
                            TerrainMap[x, y] = 9; // Air block
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
}
