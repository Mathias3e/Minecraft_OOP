using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

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
            int count = 0;
            for (int i = 0; i < World.TerrainMap.GetLength(1); i++)
            {
                if (World.TerrainMap[3, i] == 1)
                    count++;
            }

            this.PosX = 2;
            this.PosY = count;
        }

        public void Move(Direction direction)
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
                    if (PosX < World.Width - 1)
                    {
                        PosX++;
                    }
                    break;
            }
        }

        public void Render()
        {
            World.world.SetPixel(PosX, PosY, Color.Red);
            World.world.SetPixel(PosX, PosY + 1, Color.Red);
        }
    }
}
