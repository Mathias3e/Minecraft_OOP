using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;
using System.Collections.Specialized;

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

            OrderedDictionary Sees = new OrderedDictionary();
            for (int i = 0; i < 2; i++)
            {
                int heightSee = random.Next(3, Game.Width - 7 - 1);
                if (!Sees.Contains(heightSee + " "))
                {
                    Sees.Add(heightSee + " ", new See(heightSee));
                }
            }

            OrderedDictionary Trees = new OrderedDictionary();
            for (int i = 0; i < 3; i++)
            {
                int heightTree = random.Next(3, Game.Width - 3 - 1);
                if (!Trees.Contains(heightTree + " "))
                {
                    Trees.Add(heightTree + " ", new Tree(heightTree, Sees));
                }
            }

            for (int x = 0; x < Game.Width; x++)
            {
                if (Sees.Contains(x + " "))
                {
                    ((See)Sees[x + " "]).GenerateSee(ref x, ref height);
                }
                else if (Trees.Contains(x + " ") && height > 3)
                {
                        ((Tree)Trees[x + " "]).GenerateTree(ref x, ref height);
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