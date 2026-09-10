using System;
using Extra;

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
            Console.WriteLine(title);
            Console.ResetColor();
        }

        public static void WriteLineWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteLineInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteLineError(Error error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error code: {error.code}");
            if (!string.IsNullOrWhiteSpace(error.message))
            {
                Console.WriteLine($"Error message: {error.message}");
            }
            Console.ResetColor();
        }
    }
}
