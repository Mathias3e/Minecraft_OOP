using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Minecraft
{
    internal static class Game
    {
        public static int Width { get; private set; } = 100;
        public static int Height { get; private set; } = 20 + 2; // platz für spieler durchgehen lassen
    }
}
