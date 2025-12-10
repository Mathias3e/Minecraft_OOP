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

        public static int[][] TerrainMap { get; private set; }

        public static void SetSize(int width = 100, int height = 45)
        {
            Width = width + 1;
            Height = height + 2;
            world = new Canvas(Width, Height);
        }

        public static void RenderWorld()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    world.SetPixel(x, y, Color.CadetBlue);
                }
            }
            AnsiConsole.Write(world);
        }

        public static void GenerateTerrain()
        {
            
        }
    }
}
