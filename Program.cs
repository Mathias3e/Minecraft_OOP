using Spectre.Console;
using System;
using System.Runtime.InteropServices;

namespace Projekt_Minecraft
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private const int VK_LEFT = 0x25;   // Pfeil-Links
        private const int VK_RIGHT = 0x27;  // Pfeil-Rechts
        private const int VK_ESCAPE = 0x1B; // ESC
        private const int VK_SPACE = 0x20;  // Leertaste


        static void Main()
        {
            Game.SetSize(100, 20);
            Terrain.InitializeTerrain();
            Renderer.InitializeCanvas();

            Terrain.GenerateTerrain();
            Player.SetToGround();
            Renderer.RenderWorld();

            /*for (int i = Player.PosX; i < Game.Width - 2; i++)
            {
                Thread.Sleep(500);
                Player.Move(Direction.Right);
                Player.SetToGround();
                Renderer.RenderWorld();
            }*/
            bool running = true;

            while (running)
            {
                Console.ReadKey(true);

                if (IsKeyPressed(VK_LEFT) && IsKeyPressed(VK_SPACE))
                {
                    Player.Jump(Direction.Left);
                }
                else if (IsKeyPressed(VK_RIGHT) && IsKeyPressed(VK_SPACE))
                {
                    Player.Jump(Direction.Right);
                }
                else if (IsKeyPressed(VK_LEFT) && Player.PosX > 0)
                {
                    Player.Move(Direction.Left);
                }
                else if (IsKeyPressed(VK_RIGHT) && Player.PosX < Game.Width - 1)
                {
                    Player.Move(Direction.Right);
                }

                if (IsKeyPressed(VK_ESCAPE))
                {
                    running = false;
                }

                Player.SetToGround();
                Renderer.RenderWorld();
            }
            /*
            int width = 100;
            int height = 45;

            int playerX = 0;
            int playerY = height - 2;

            AnsiConsole.Clear();

            bool running = true;

            while (running)
            {
                World.SetSize(width, height);

                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold yellow]Minecraft Demo[/]");
                World.RenderWorld();
                AnsiConsole.MarkupLine($"\n[grey]Position: X={playerX}, Y={playerY}[/]");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (playerY > 0)
                            playerY--;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (playerY < height - 2)
                            playerY++;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0)
                            playerX--;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (playerX < width - 1)
                            playerX++;
                        break;

                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }

            AnsiConsole.Clear();
        */
        }

        private static bool IsKeyPressed(int keyCode)
        {
            return (GetAsyncKeyState(keyCode) & 0x8000) != 0;
        }
    }
}
