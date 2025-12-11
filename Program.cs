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
            Console.Write("Bitte geben sie einen Seed ein (für random seed leerlassen, string = random): ");
            int.TryParse(Console.ReadLine(), out int Seed);

            Terrain.InitializeTerrain();
            Renderer.InitializeCanvas();

            Terrain.GenerateTerrain(Seed);
            Player.SetToGround();
            Renderer.RenderWorld();

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
                    return;
                }

                Player.SetToGround();
                Renderer.RenderWorld();
            }
        }

        private static bool IsKeyPressed(int keyCode)
        {
            return (GetAsyncKeyState(keyCode) & 0x8000) != 0;
        }
    }
}
