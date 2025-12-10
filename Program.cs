using Spectre.Console;
using System;

namespace Projekt_Minecraft
{
    internal class Program
    {
        static void Main()
        {
            int width = 100 + 1;
            int height = 45 + 2;

            int playerX = 0;
            int playerY = height - 2;

            AnsiConsole.Clear();

            bool running = true;

            while (running)
            {
                World.SetSize(width, height);

                canvas.SetPixel(playerX, playerY, Color.Green);
                canvas.SetPixel(playerX, playerY + 1, Color.Green);

                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold yellow]Minecraft Demo[/]");
                AnsiConsole.Write(canvas);
                AnsiConsole.MarkupLine($"\n[grey]Position: X={playerX}, Y={playerY}[/]");

         
            }

            AnsiConsole.Clear();
        }
    }
}
