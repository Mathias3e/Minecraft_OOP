using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal class See
    {
        public int PosX { get; private set; }
        public int Height { get; private set; }

        public See(int positionX, int height)
        {
            this.PosX = positionX;
            this.Height = height;
        }

        public void GenerateSee(int[,] TerrainMap, ref int x, ref int height)
        {
            if (x == PosX)
            {
                TerrainMap[x, height] = 1;
                TerrainMap[x + 1, height] = 4;
                TerrainMap[x + 2, height] = 4;
                TerrainMap[x + 3, height] = 4;
                TerrainMap[x + 4, height] = 4;
                TerrainMap[x + 5, height] = 4;
                TerrainMap[x + 6, height] = 1;

                TerrainMap[x, height + 1] = 1;
                TerrainMap[x + 1, height + 1] = 1;
                TerrainMap[x + 2, height + 1] = 4;
                TerrainMap[x + 3, height + 1] = 4;
                TerrainMap[x + 4, height + 1] = 4;
                TerrainMap[x + 5, height + 1] = 1;
                TerrainMap[x + 6, height + 1] = 1;

                for (int i = x; i < x + 7; i++)
                {
                    for (int j = height + 2; j < Game.Height; j++)
                    {
                        TerrainMap[i, j] = 1;
                    }
                }

                for (int i = x; i < x + 7; i++)
                {
                    for (int j = height - 1; j >= 0; j--)
                    {
                        TerrainMap[i, j] = 9;
                    }
                }

                x += 6;

            }
        }
    }
}
