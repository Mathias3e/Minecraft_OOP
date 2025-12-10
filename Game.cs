using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal static class Game
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static void SetSize(int width = 10, int height = 10)
        {
            Width = width;
            Height = height + 2;
        }
    }
}
