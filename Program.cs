using Spectre.Console;
using System;

namespace Projekt_Minecraft
{
    internal class Program
    {
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
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {/*
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (Player.PosY > 0)
                            Player.PosY--;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (Player.PosY < height - 2)
                            Player.PosY++;
                        break;
                    */
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (Player.PosX > 0)
                            Player.Move(Direction.Left);
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (Player.PosX < Game.Width - 1)
                            Player.Move(Direction.Right);
                        break;

                    case ConsoleKey.Escape:
                        running = false;
                        break;
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
    }
}
