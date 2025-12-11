using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace Projekt_Minecraft
{
    internal static class Renderer
    {
        public static Canvas World;
        
        public static void InitializeCanvas()
        {
            World = new Canvas(Game.Width, Game.Height);
        }
        public static void RenderWorld()
        {
            AnsiConsole.Clear();

            for (int x = 0; x < Game.Width; x++)
            {
                for (int y = 0; y < Game.Height; y++)
                {
                    if (Terrain.TerrainMap[x, y] == 1)
                    {
                        if (y == 0 || Terrain.TerrainMap[x, y - 1] == 0)
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
                    else
                    {
                        World.SetPixel(x, y, Color.CornflowerBlue); // Air blocks Color
                    }
                }
            }

            World.SetPixel(5, 2, Color.DarkGreen);
            World.SetPixel(5, 3, Color.DarkGreen);
            World.SetPixel(5, 5, new Color(138, 102,66));
            World.SetPixel(5, 4, new Color(138, 102, 66));
            World.SetPixel(6, 3, Color.DarkGreen);
            World.SetPixel(4, 3, Color.DarkGreen);

            World.SetPixel(Player.PosX, Player.PosY, Color.Black);
            World.SetPixel(Player.PosX, Player.PosY - 1, Color.Black);

            AnsiConsole.Write(World);
        }
    }
}
