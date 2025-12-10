using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal class Player
    {
        private static int PlayerCount = 0;
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        private Player (int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
            PlayerCount++;
        }

        public static Player CreatePlayer(int posX, int posY)
        {
            if (PlayerCount >= 1)
            {
                throw new InvalidOperationException("Only one player instance is allowed.");
            }
            else
            {
                return new Player(posX, posY);
            }
        }

        public void SetPos(int posX, int posY) // Am Anfang auf terain platziren
        {
            this.PosX += posX;
            this.PosY += posY;
        }

        public void Move()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (PosY > 0)
                    {
                        PosY--;
                    }
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (PosY < World.Height - 2)
                    {
                        PosY++;
                    }
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (PosX > 0)
                    {
                        PosX--;
                    }
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (PosX < World.Width - 1)
                    {
                        PosX++;
                    }
                    break;
            }
        }
    }
}
