using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Projekt_Minecraft
{
    internal static class Key
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // Tasten für Eingabe-Erfassung
        public const int VK_LEFT = 0x25;   // Pfeil-Links
        public const int VK_RIGHT = 0x27;  // Pfeil-Rechts
        public const int VK_ESCAPE = 0x1B; // ESC
        public const int VK_SPACE = 0x20;  // Leertaste
        public const int VK_C = 0x43;  // C

        // Tasten für Simulation
        public const byte VK_CONTROL = 0x11;
        public const byte VK_F11 = 0x7A;
        public const byte VK_OEM_MINUS = 0xBD;
        public const uint KEYEVENTF_KEYDOWN = 0x0000;
        public const uint KEYEVENTF_KEYUP = 0x0002;

        public static void SimulateF11()
        {
            keybd_event(VK_F11, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event(VK_F11, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        public static void SimulateCtrlMinus()
        {
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event(VK_OEM_MINUS, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
            keybd_event(VK_OEM_MINUS, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        public static bool IsKeyPressed(int keyCode)
        {
            return (GetAsyncKeyState(keyCode) & 0x8000) != 0;
        }
    }
}
