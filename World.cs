using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal static class World
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static Canvas world;

        public static int[,] TerrainMap { get; private set; }

        public static void SetSize(int width = 100, int height = 45)
        {
            Width = width + 1;
            Height = height + 2;
            world = new Canvas(Width, Height);
            TerrainMap = new int[Height, Width];
        }

        public static void RenderWorld()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (TerrainMap[y, x] == 0)
                    {
                        world.SetPixel(x, y, Color.Green);
                    }
                    else
                    {
                        world.SetPixel(x, y, Color.CornflowerBlue);
                    }   
                }
            }
            AnsiConsole.Write(world);
        }

        public static void GenerateTerrain()
        {
            Random random = new Random();
            int height = random.Next(2, Height + 1);
            height = Height / 2;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (y <= height)
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

                if (height > Height - 2)
                {
                    height = Height - 2;
                }
            }
        }
    }
}
