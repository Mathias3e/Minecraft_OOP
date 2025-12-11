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
                            World.SetPixel(x, y, Color.Green);
                        }
                        else
                        {
                            World.SetPixel(x, y, Color.DarkRed);
                        }
                    }
                    else
                    {
                        World.SetPixel(x, y, Color.CornflowerBlue);
                    }
                }
            }

            World.SetPixel(Player.PosX, Player.PosY, Color.Black);
            World.SetPixel(Player.PosX, Player.PosY - 1, Color.Black);

            AnsiConsole.Write(World);
        }
    }
}
