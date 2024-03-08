using System.Text.RegularExpressions;

namespace IO;

sealed public class Writer
{
    public enum TextColor
    {
        defaultColor = 8,
        blue = 9,
        green = 10,
        cyan = 11,
        magenta = 5,
        red = 12,
        yellow = 14,
        white = 15,
        black = 0,
        gray = 7,
    }

    /// <summary>
    /// This method can clear the console and change colors of a given string directly.
    /// </summary>

    public void Write(string text, bool? clear = false, bool? newline = false, ConsoleColor? foreground = (ConsoleColor)15, ConsoleColor? background = (ConsoleColor)0)
    {
        if (clear is true) Console.Clear();

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
        if (clear is true) Console.Clear();

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
                    switch (colorMatch.Value)
                    {
                        case "blue":
                            Console.ForegroundColor = (ConsoleColor)TextColor.blue;
                            break;
                        case "yellow":
                            Console.ForegroundColor = (ConsoleColor)TextColor.yellow;
                            break;
                        case "magenta":
                            Console.ForegroundColor = (ConsoleColor)TextColor.magenta;
                            break;
                        case "cyan":
                            Console.ForegroundColor = (ConsoleColor)TextColor.cyan;
                            break;
                        case "red":
                            Console.ForegroundColor = (ConsoleColor)TextColor.red;
                            break;
                        case "green":
                            Console.ForegroundColor = (ConsoleColor)TextColor.green;
                            break;
                        case "white":
                            Console.ForegroundColor = (ConsoleColor)TextColor.white;
                            break;
                        case "black":
                            Console.ForegroundColor = (ConsoleColor)TextColor.black;
                            break;
                        case "gray":
                            Console.ForegroundColor = (ConsoleColor)TextColor.gray;
                            break;
                        default:
                            Console.ForegroundColor = (ConsoleColor)TextColor.defaultColor;
                            break;
                    }
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