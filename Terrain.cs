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

        public static void SmoothTerrain() 
        {
            for (int x = 1; x < Game.Width - 1; x++)
            {
                for (int y = Game.Height - 1; y >= 0; y--)
                {
                    if (TerrainMap[x, y] == 1)
                    {
                        if (TerrainMap[x - 1, y] == 9 && TerrainMap[x + 1, y] == 9)
                        {
                            TerrainMap[x, y] = 9;
                        }
                    }
                    else if (TerrainMap[x, y] == 9)
                    {
                        if (TerrainMap[x - 1, y] == 1 && TerrainMap[x + 1, y] == 1)
                        {
                            TerrainMap[x, y] = 1;
                        }
                    }
                }
            }
        }
        public static void GenerateTerrain(int Seed)
        {
            Random random = Seed == 0 ? new Random() : new Random(Seed);
            int height = (Game.Height / 3) * 2;

            See see = new See(random);
            Tree tree1 = new Tree(random, see.PosX); // Set oder dictionery einfügen
            Tree tree2 = new Tree(random, see.PosX);
            Tree tree3 = new Tree(random, see.PosX);
        
            for (int x = 0; x < Game.Width; x++)
            {
                if (x == see.PosX)
                {
                    see.GenerateSee(ref x, ref height);
                }
                else if (x == tree1.PosX)
                {
                    tree1.GenerateTree(ref x, ref height, see.PosX);
                }
                else if (x == tree2.PosX)
                {
                    tree2.GenerateTree(ref x, ref height, see.PosX);
                }
                else if (x == tree3.PosX)
                {
                    tree3.GenerateTree(ref x, ref height, see.PosX);
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

            SmoothTerrain();
        }
    }
}