using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal class See
    {
        public int PosX { get; private set; }

        public See(int seePosX)
        {
            this.PosX = seePosX;
        }

        public void GenerateSee(ref int x, ref int height)
        {
            Terrain.TerrainMap[x, height] = 1;
            Terrain.TerrainMap[x + 1, height] = 4;
            Terrain.TerrainMap[x + 2, height] = 4;
            Terrain.TerrainMap[x + 3, height] = 4;
            Terrain.TerrainMap[x + 4, height] = 4;
            Terrain.TerrainMap[x + 5, height] = 4;
            Terrain.TerrainMap[x + 6, height] = 1;

            Terrain.TerrainMap[x, height + 1] = 1;
            Terrain.TerrainMap[x + 1, height + 1] = 1;
            Terrain.TerrainMap[x + 2, height + 1] = 4;
            Terrain.TerrainMap[x + 3, height + 1] = 4;
            Terrain.TerrainMap[x + 4, height + 1] = 4;
            Terrain.TerrainMap[x + 5, height + 1] = 1;
            Terrain.TerrainMap[x + 6, height + 1] = 1;

            for (int i = x; i < x + 7; i++)
            {
                for (int j = height + 2; j < Game.Height; j++)
                {
                    Terrain.TerrainMap[i, j] = 1;
                }
            }

            for (int i = x; i < x + 7; i++)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    Terrain.TerrainMap[i, j] = 9;
                }
            }

            x += 6;
        }
    }
}
