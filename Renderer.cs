using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projekt_Minecraft
{
    internal static class Renderer
    {
        public static Canvas World;
        
        public static void InitializeCanvas()
        {
            World = new Canvas(Math.Min(Game.Width, 100), Game.Height); // Scrol welt vorbereitung
        }
        public static void RenderWorld()
        {
            AnsiConsole.Clear();
            /*
            for (int i = 0; i < Terrain.TerrainMap.GetLength(0); i++)
            {
                for (int j = 0; j < Terrain.TerrainMap.GetLength(1); j++)
                {
                    Console.Write(Terrain.TerrainMap[i, j] + " ");
                }
                Console.WriteLine();
            }
            */
            for (int x = 0; x < Game.Width; x++)
            {
                for (int y = 0; y < Game.Height; y++)
                {
                    if (Terrain.TerrainMap[x, y] == 1)
                    {
                        if (y == 0 || Terrain.TerrainMap[x, y - 1] != 1 && Terrain.TerrainMap[x, y - 1] != 4)
                        {
                            World.SetPixel(x, y, Color.Green); // Surface blocks Color
                        }
                        else
                        {
                            World.SetPixel(x, y, new Color(66, 42, 20)); // Underground blocks Color
                        }
                    }
                    else if (Terrain.TerrainMap[x, y] == 4)
                    {
                        World.SetPixel(x, y, new Color(0, 0, 128)); // Water blocks Color
                    }
                    else if (Terrain.TerrainMap[x, y] == 9)
                    {
                        World.SetPixel(x, y, Color.CornflowerBlue); // Air blocks Color
                    }
                    else if (Terrain.TerrainMap[x, y] == 2)
                    {
                        World.SetPixel(x, y, new Color(138, 102, 66)); // Wood blocks Color
                    }
                    else if (Terrain.TerrainMap[x, y] == 3)
                    {
                        World.SetPixel(x, y, Color.DarkGreen); // Leaf blocks Color
                    }
                    else
                    {
                        World.SetPixel(x, y, Color.Red); // Render unknown blocks
                    }
                }
            }

            World.SetPixel(Player.PosX, Player.PosY, Color.Black);
            World.SetPixel(Player.PosX, Player.PosY - 1, Color.Black);

            AnsiConsole.Write(World);
        }
    }
}
