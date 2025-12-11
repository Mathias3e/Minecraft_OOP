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
        public static int PosX { get; private set; } = 1;
        public static int PosY { get; private set; } = 0;

        public static void Move(Direction direction) // Block dedettion einfügen
        {
            switch (direction)
            {
                case Direction.Left:
                    if (PosX > 0 && !CheckforBlock(direction))
                    {
                        PosX--;
                    }
                    break;

                case Direction.Right:
                    if (PosX < Game.Width - 1 && !CheckforBlock(direction))
                    {
                        PosX++;
                    }
                    break;
            }
        }

        public static void Jump(Direction direction)
        {
            PosY--;
            Move(direction);
        }

        private static bool CheckforBlock(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (Terrain.TerrainMap[PosX - 1, PosY] == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case Direction.Right:
                    if (Terrain.TerrainMap[PosX + 1, PosY] == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                default:
                    return false;
                    break;
            }
            //return false;
        }

        public static void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public static void SetToGround()
        {
            for (int posY = 0; posY < Game.Height - 1; posY++)
            {
                if (Terrain.TerrainMap[PosX, posY] == 1)
                {
                    SetPos(PosX, posY - 1);
                    return;
                }
            }
        }
    }
}
