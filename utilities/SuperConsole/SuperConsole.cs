using System.Text.RegularExpressions;

namespace SuperConsole
{
    public sealed class IO
    {
        private Dictionary<string, ConsoleColor>? textColors;

        public IO()
        {
            TextColors = new Dictionary<string, ConsoleColor>()
            {
                { "default", ConsoleColor.White },
                { "green", ConsoleColor.Green },
                { "blue", ConsoleColor.Blue },
                { "cyan", ConsoleColor.Cyan },
                { "magenta", ConsoleColor.Magenta },
                { "red", ConsoleColor.Red },
                { "yellow", ConsoleColor.Yellow },
                { "white", ConsoleColor.White },
                { "black", ConsoleColor.Black },
                { "gray", ConsoleColor.Gray }
            };
        }

        public IO(Dictionary<string, ConsoleColor> colors)
        {
            TextColors = colors;
        }

        public Dictionary<string, ConsoleColor>? TextColors
        {
            get { return textColors; }
            set
            {
                if (value is null)
                {
                    throw new TextColorException();
                }
                textColors = value;
            }
        }

        /// <summary>
        /// This method can clear the console and change colors of a given string directly.
        /// </summary>

        public void Write(
            string text,
            bool? clear = false,
            bool? newline = false,
            string? foreground = "white",
            string? background = null
        )
        {
            if (clear is true) Console.Clear();

            Console.ForegroundColor = TextColors[foreground];
            if (background is not null)
            {
                Console.BackgroundColor = TextColors[background];
            }

            Console.Write(text);

            if (newline is true)
            {
                Console.Write("\n");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// This method takes a preencoded string and writes colors the sequences based on the [$color] sequence signifier.
        /// </summary>

        public void WriteEncoded(string text, bool? clear = false, bool? newline = false)
        {
            if (TextColors is null)
                throw new TextColorNotSetException();

            if (clear is true)
                Console.Clear();

            string encoderPattern = @"(\[\w+\])";
            string colorMatchPattern = @"blue|yellow|magenta|cyan|red|green|white|black|gray";

            string[] stringList = Regex.Split(text, encoderPattern);

            bool nextColored = false;

            foreach (string str in stringList)
            {
                Match match = Regex.Match(str, encoderPattern);

                if (nextColored)
                {
                    if (match.Success)
                    {
                        nextColored = !nextColored;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(str);
                    }
                }
                else
                {
                    if (match.Success)
                    {
                        nextColored = !nextColored;

                        Match colorMatch = Regex.Match(str, colorMatchPattern);

                        string color = Regex.Replace(str, @"[\[\]]", "");

                        Console.ForegroundColor = TextColors[color];
                    }
                    else
                    {
                        Console.Write(str);
                    }
                    if (newline is true)
                    {
                        Console.Write("\n");
                    }
                }
            }
        }

        public void ClearAll()
        {
            Console.Clear();
        }

        public string ReadAndClear()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
