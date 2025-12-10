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

        public void SetPos(int posX, int posY)
        {
            this.PosX += posX;
            this.PosY += posY;
        }
    }
}
