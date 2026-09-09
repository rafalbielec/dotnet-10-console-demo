using System;

static class ConsoleExtensions
{
    /*
     * New extension syntax without using this.
     */
    extension(Console)
    {
        public static void WriteLineIntro(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{title}");
            Console.ResetColor();
        }

        public static void WriteLineWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}
