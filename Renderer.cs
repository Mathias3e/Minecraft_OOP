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
            World = new Canvas(Game.Width, Game.Height);
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
                    else
                    {
                        World.SetPixel(x, y, Color.Red); // Underground blocks Color
                    }
                }
            }
            /*
            int baumX = 50;
            int baumY = 7;

            World.SetPixel(baumX, baumY - 3, Color.DarkGreen);
            World.SetPixel(baumX, baumY -2, Color.DarkGreen);
            World.SetPixel(baumX, baumY, new Color(138, 102,66));
            World.SetPixel(baumX, baumY - 1, new Color(138, 102, 66));
            World.SetPixel(baumX + 1, baumY - 2, Color.DarkGreen);
            World.SetPixel(baumX - 1, baumY - 2, Color.DarkGreen);
            World.SetPixel(baumX + 1, baumY, Color.CornflowerBlue);
            World.SetPixel(baumX - 1, baumY, Color.CornflowerBlue);
            World.SetPixel(baumX + 1, baumY - 1, Color.CornflowerBlue);
            World.SetPixel(baumX - 1, baumY - 1, Color.CornflowerBlue);
            World.SetPixel(baumX + 1, baumY - 3, Color.CornflowerBlue);
            World.SetPixel(baumX - 1, baumY - 3, Color.CornflowerBlue);

            int seeX = 33;
            int seeY = 12;

            World.SetPixel(seeX, seeY, Color.Green);
            World.SetPixel(seeX + 1, seeY, new Color(0, 0, 128));
            World.SetPixel(seeX + 2, seeY, new Color(0, 0, 128));
            World.SetPixel(seeX + 3, seeY, new Color(0, 0, 128));
            World.SetPixel(seeX + 4, seeY, new Color(0, 0, 128));
            World.SetPixel(seeX + 5, seeY, new Color(0, 0, 128));
            World.SetPixel(seeX + 6, seeY, Color.Green);

            World.SetPixel(seeX, seeY + 1, new Color(66, 42, 20));
            World.SetPixel(seeX + 1, seeY + 1, new Color(66, 42, 20));
            World.SetPixel(seeX + 2, seeY + 1, new Color(0, 0, 128));
            World.SetPixel(seeX + 3, seeY + 1, new Color(0, 0, 128));
            World.SetPixel(seeX + 4, seeY + 1, new Color(0, 0, 128));
            World.SetPixel(seeX + 5, seeY + 1, new Color(66, 42, 20));
            World.SetPixel(seeX + 6, seeY + 1, new Color(66, 42, 20));
            */
            World.SetPixel(Player.PosX, Player.PosY, Color.Black);
            World.SetPixel(Player.PosX, Player.PosY - 1, Color.Black);

            AnsiConsole.Write(World);
        }
    }
}
