using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    public class Tree
    {
        public int PosX { get; private set; }

        public Tree(Random random,int seePosX)
        {
            this.PosX = random.Next(3, Game.Width - 3 - 1);

            if (PosX == seePosX)
            {
                PosX = -1;
            }
        }

        public void GenerateTree(ref int x, ref int height, int seePosX)
        {
            if (height > 3)
            {
                Terrain.TerrainMap[x, height - 4] = 9;
                Terrain.TerrainMap[x + 1, height - 4] = 3;
                Terrain.TerrainMap[x + 2, height - 4] = 9;

                Terrain.TerrainMap[x, height - 3] = 3;
                Terrain.TerrainMap[x + 1, height - 3] = 3;
                Terrain.TerrainMap[x + 2, height - 3] = 3;

                Terrain.TerrainMap[x, height - 2] = 9;
                Terrain.TerrainMap[x + 1, height - 2] = 2;
                Terrain.TerrainMap[x + 2, height - 2] = 9;

                Terrain.TerrainMap[x, height - 1] = 9;
                Terrain.TerrainMap[x + 1, height - 1] = 2;
                Terrain.TerrainMap[x + 2, height - 1] = 9;

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = height; j < Game.Height; j++)
                    {
                        Terrain.TerrainMap[i, j] = 1;
                    }
                }

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = height - 5; j >= 0; j--)
                    {
                        Terrain.TerrainMap[i, j] = 9;
                    }
                }

                x += 2;
            }
        }
    }
}
