using System.Text.RegularExpressions;

namespace IO
{
    public sealed class Writer
    {
        private Dictionary<string, ConsoleColor>? textColors;

        public Writer()
        {
            TextColors = new Dictionary<string, ConsoleColor>()
            {
                { "[default]", ConsoleColor.White },
                { "[green]", ConsoleColor.Green },
                { "[blue]", ConsoleColor.Blue },
                { "[cyan]", ConsoleColor.Cyan },
                { "[magenta]", ConsoleColor.Magenta },
                { "[red]", ConsoleColor.Red },
                { "[yellow]", ConsoleColor.Yellow },
                { "[white]", ConsoleColor.White },
                { "[black]", ConsoleColor.Black },
                { "[gray]", ConsoleColor.Gray }
            };
        }

        public Writer(Dictionary<string, ConsoleColor> colors)
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
            ConsoleColor? foreground = (ConsoleColor)15,
            ConsoleColor? background = (ConsoleColor)0
        )
        {
            if (clear is true)
                Console.Clear();

            if (foreground is ConsoleColor fg)
            {
                Console.ForegroundColor = fg;
            }
            if (background is ConsoleColor bg)
            {
                Console.BackgroundColor = bg;
            }

            Console.Write(text);

            if (newline is true)
            {
                this.Write("\n");
            }
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

                        Console.ForegroundColor = TextColors[str];
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
    }
}
