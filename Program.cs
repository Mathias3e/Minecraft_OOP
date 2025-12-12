using Spectre.Console;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Projekt_Minecraft
{
    internal class Program
    {
        static void Main()
        {
            Key.SimulateF11();
            for (int i = 0; i < 5; i++)
            {
                Key.SimulateCtrlMinus();
            }

            Console.Write("Bitte geben sie eine ZAHL als Seed ein (für random seed leerlassen): ");
            int.TryParse(Console.ReadLine(), out int Seed);

            Console.TreatControlCAsInput = true;

            Terrain.InitializeTerrain();
            Renderer.InitializeCanvas();
            Terrain.GenerateTerrain(Seed);
            Player.SetToGround();
            Renderer.RenderWorld();

            bool running = true;
            while (running)
            {
                Console.ReadKey(true);
                if (Key.IsKeyPressed(Key.VK_LEFT) && Key.IsKeyPressed(Key.VK_SPACE))
                {
                    Player.Jump(Direction.Left);
                }
                else if (Key.IsKeyPressed(Key.VK_RIGHT) && Key.IsKeyPressed(Key.VK_SPACE))
                {
                    Player.Jump(Direction.Right);
                }
                else if (Key.IsKeyPressed(Key.VK_LEFT) && Player.PosX > 0)
                {
                    Player.Move(Direction.Left);
                }
                else if (Key.IsKeyPressed(Key.VK_RIGHT) && Player.PosX < Game.Width - 1)
                {
                    Player.Move(Direction.Right);
                }

                if (Key.IsKeyPressed(Key.VK_CONTROL) && Key.IsKeyPressed(Key.VK_C))
                {
                    Clipboard.CopyToClipboard(Game.Seed + "");
                }

                if (Key.IsKeyPressed(Key.VK_ESCAPE))
                {
                    running = false;
                    return;
                }

                /*
                // Seed Finder
                bool found = false;
                int i = 0;
                while (!found)
                {
                    i++;
                    Game.Seed = i;
                    Terrain.GenerateTerrain(Game.Seed);

                    //Console.Write(".");

                    for (int x = 0; x < Game.Width - 20; x++)
                    {
                        for (int y = 0; y < Game.Height - 1; y++)
                        {
                            if (Terrain.TerrainMap[x, y] == 2 && Terrain.TerrainMap[x + 3, y + 1] == 4 && Terrain.TerrainMap[x + 10, y] == 2 && Terrain.TerrainMap[x + 13, y + 1] == 4 && Terrain.TerrainMap[x + 20, y] == 2) // Key
                            {
                                found = true;
                                Renderer.RenderWorld();
                                return;
                            }
                        }
                    }
                }
                */

                Player.SetToGround();
                Renderer.RenderWorld();
            }
        }
    }
}