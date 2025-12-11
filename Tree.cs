using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    public class Tree
    {
        public int PosX { get; private set; }
        public int Height { get; private set; }

        public Tree(int positionX, int height)
        {
            this.PosX = positionX;
            this.Height = height;
        }

        public void GenerateTree(int[,] TerrainMap, ref int x, ref int height, int seePos)
        {
            if (PosX + 2 >= seePos && PosX <= seePos + 6)
            {
                PosX = -1;
            }
            if (x == PosX && height > 3)
            {
                TerrainMap[x + 1, height - 4] = 3;
                TerrainMap[x + 1, height - 3] = 3;
                TerrainMap[x + 1, height - 1] = 2;
                TerrainMap[x + 1, height - 2] = 2;
                TerrainMap[x + 2, height - 3] = 3;
                TerrainMap[x, height - 3] = 3;
                TerrainMap[x + 2, height - 1] = 9;
                TerrainMap[x, height - 1] = 9;
                TerrainMap[x + 2, height - 2] = 9;
                TerrainMap[x, height - 2] = 9;
                TerrainMap[x + 2, height - 4] = 9;
                TerrainMap[x, height - 4] = 9;

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = height; j < Game.Height; j++)
                    {
                        TerrainMap[i, j] = 1;
                    }
                }

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = height - 5; j >= 0; j--)
                    {
                        TerrainMap[i, j] = 9;
                    }
                }

                x += 3;
            }
        }
    }
}
