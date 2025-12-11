using System;
using TextCopy;

namespace Projekt_Minecraft
{
    internal class Clipboard
    {
        public static void CopyToClipboard(string text)
        {
            ClipboardService.SetText(text);
        }
    }
}