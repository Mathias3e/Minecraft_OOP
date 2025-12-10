using Spectre.Console;
using System;

namespace Projekt_Minecraft
{
    internal class Program
    {
        static void Main()
        {
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

         
            }

            AnsiConsole.Clear();
        }
    }
}
