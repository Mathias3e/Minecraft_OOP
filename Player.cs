using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Projekt_Minecraft
{
    internal static class Player
    {
        public static int PosX { get; private set; } = 0;
        public static int PosY { get; private set; } = 0;

        public static void Move(Direction direction) // Block dedettion einfügen
        {
            switch (direction)
            {
                case Direction.Left:
                    if (PosX > 0)
                    {
                        PosX--;
                    }
                    break;

                case Direction.Right:
                    if (PosX < Game.Width - 1)
                    {
                        PosX++;
                    }
                    break;
            }
        }

        public static void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
