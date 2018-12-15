using System;

namespace GitIStage
{
    internal sealed class ConsoleCommand
    {
        public readonly Action Handler;
        public readonly ConsoleKey Key;
        public readonly string Description;
        public readonly ConsoleModifiers Modifiers;

        public ConsoleCommand(Action handler, ConsoleKey key, string description)
        {
            Handler = handler;
            Key = key;
            Description = description;
            Modifiers = 0;
        }

        public ConsoleCommand(Action handler, ConsoleKey key, ConsoleModifiers modifiers, string description)
        {
            Handler = handler;
            Key = key;
            Modifiers = modifiers;

            Description = description;
        }

        public void Execute()
        {
            Handler();
        }

        public bool MatchesKey(ConsoleKeyInfo keyInfo)
        {
            return Key == keyInfo.Key && Modifiers == keyInfo.Modifiers;
        }

        public string GetCommandShortcut()
        {
            string key = string.Empty;

            switch (Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    key = Key.ToString().Replace("Arrow", "");
                    break;
                case ConsoleKey.OemPlus:
                    key = "+";
                    break;
                case ConsoleKey.OemMinus:
                    key = "-";
                    break;
                case ConsoleKey.Oem4:
                    key = "[";
                    break;
                case ConsoleKey.Oem6:
                    key = "]";
                    break;
                case ConsoleKey.Oem7:
                    key = "'";
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                    key = Key.ToString().Replace("D", "");
                    break;
                default:
                    key = Key.ToString();
                    break;
            }

            if (Key == ConsoleKey.Oem2 && Modifiers == ConsoleModifiers.Shift)
                return "?";

            if (Modifiers != 0)
                return $"{Modifiers.ToString().Replace("Control", "Ctrl")} + {key}";
            else
                return key;
        }
    }
}