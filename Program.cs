using Spectre.Console;
using System;

namespace Projekt_Minecraft
{
    internal class Program
    {
        static void Main()
        {
            Game.SetSize(10, 10);
            Terrain.InitializeTerrain();
            Renderer.InitializeCanvas();

            Terrain.GenerateTerrain();
            Player.SetPos(3, 0);

            Renderer.RenderWorld();

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
    }
}
