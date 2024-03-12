using System.Text.RegularExpressions;
using SuperConsole;

namespace MainMenu
{
    internal enum TicketPrices
    {
        defaultPrice = 120,
        childPrice = 80,
        elderlyPrice = 90,
    }

    internal class AgeRange
    {
        private int start;
        private int end;

        public int Start
        {
            get { return start; }
            set
            {
                start = value < 0 ? 0 : value;
            }
        }

        public int End
        {
            get { return end; }
            set
            {
                end = value < start ? start + 1 : value; // make sure range is not single value'd
            }
        }

        public AgeRange(int start, int end)
        {
            Start = start;
            End = end;
        }
    }

    internal class Program
    {
        private readonly static AgeRange childRange = new(5, 20);
        private readonly static AgeRange elderlyRange = new(64, 100);

        private static bool IsChildBracket(int? age)
        {
            if (age >= childRange.Start && age <= childRange.End)
            {
                return true;
            }
            return false;
        }
        private static bool IsElderlyBracket(int? age)
        {
            if (age >= elderlyRange.Start && age <= elderlyRange.End)
            {
                return true;
            }
            return false;
        }

        private static bool FreeEntrance(int? age)
        {
            if (age <= childRange.Start || age >= elderlyRange.End)
            {
                return true;
            }
            return false;
        }

        internal static bool running = true;

        public static void Main()
        {
            IO io = new();
            do
            {
                GenerateMenu(io);
                running = false;
            }
            while (running);
        }

        // Assignment 1
        private static void ChildOrElderly(IO io)
        {
            int totalPrice = 0;

            io.Write("Welcome to the cinema! how many are you?:", foreground: "green", newline: true);

            int? visitorCount = int.Parse(io.ReadAndClear());

            if (visitorCount is null)
            {
                io.Write("Please specify a count in digits", foreground: "red");
                ChildOrElderly(io);
                return;
            }

            if (visitorCount < 2)
            {
                io.Write("So only one of you? Alright!", foreground: "green", newline: true);
            }
            else
            {
                io.Write($"Alright! {visitorCount} of you! We'll proceed with taking the age of each person.", foreground: "green", newline: true);
            }

            string encodedText = "Please do note the special prices:\n" +
                                  $"children age bracket (ages {childRange.Start}-{childRange.End}):" +
                                  $"{(int)TicketPrices.childPrice}kr SEK.\n" +
                                  $"elderly age bracket (ages {elderlyRange.Start}-{elderlyRange.End}):" +
                                  $"{(int)TicketPrices.elderlyPrice}kr SEK.\n" +
                                  "[magenta]People below 5 or over 100 can visit for free![magenta]";

            io.WriteEncoded(encodedText);

            GetPrice(ref totalPrice, io, visitorCount);

            if (totalPrice == 0)
            {
                if (visitorCount > 2)
                {
                    io.Write($"Looks like you are going for free!", foreground: "yellow");
                }
                else
                {
                    io.Write($"Looks like all {visitorCount} of you are going for free!", foreground: "yellow");
                }
            }
            else
            {
                io.Write($"the total price for you (visitor count: {visitorCount}) is {totalPrice}kr SEK!", foreground: "yellow");
            }
            io.Write("\n");
            BackOrContinue(1, io);
        }

        public static void GetPrice(ref int basePrice, IO io, int? visitorCount = 1)
        {
            for (int i = 0; i < visitorCount; i++)
            {
                CalculateTotal(i, visitorCount, ref basePrice, io);
            }
        }

        public static void CalculateTotal(int visitorIndex, int? visitorCount, ref int basePrice, IO io)
        {
            if (visitorCount < 2)
            {
                io.Write($"Please specify your age in digits:", foreground: "green", newline: true);
            }
            else
            {
                io.Write($"Please specify person {visitorIndex + 1}'s age in digits:", foreground: "green", newline: true);
            }

            int? ageInNumber = int.Parse(io.ReadAndClear());

            if (ageInNumber is null)
            {
                io.Write("Please specify an age in numbers", foreground: "red");
                GetPrice(ref basePrice, io, visitorCount);
                return;
            }
            else if (IsChildBracket(ageInNumber))
            {
                basePrice += (int)TicketPrices.childPrice;
            }
            else if (IsElderlyBracket(ageInNumber))
            {
                basePrice += (int)TicketPrices.elderlyPrice;
            }
            else if (!FreeEntrance(ageInNumber))
            {
                basePrice += (int)TicketPrices.defaultPrice;
            }
        }

        // Assignment 2
        private static void RepeatTenTimes(IO io)
        {
            io.Write(text: "Please provide a sentence:", foreground: "green", newline: true);
            string input = io.ReadAndClear();
            io.ClearAll();
            for (int i = 0; i < 10; i++)
            {
                if (input != null) io.Write(text: $"{input} ", foreground: "green");
            }
            io.Write("\n");
            BackOrContinue(2, io);
        }

        // Assignment 3
        private static void TheThirdWord(IO io)
        {
            int minimumWordCount = 3;

            Regex whitespaces = new Regex(@"\s");

            string encodedText = $"[green]Please provide a sentence consisting of at least[green] {minimumWordCount} [green]words[green]";

            io.Write(encodedText);

            string input = io.ReadAndClear();

            string[] stringArray = whitespaces.Split(input);

            if (stringArray.Length < 3)
            {
                io.Write($"Please provide at least {minimumWordCount} words!", foreground: "red");
                TheThirdWord(io);
                return;
            }
            io.ClearAll();
            encodedText = $"The third word is [magenta]{stringArray[2]}![magenta]";

            io.WriteEncoded(encodedText);
            BackOrContinue(3, io);
        }

        public static void GenerateMenu(IO io)
        {
            io.ClearAll();

            string greetingMsg = "Hello! Please select an action from the options below (the given key followed by [Enter] key):";
            string errorMsg = "Something went wrong... :[";

            io.Write(text: greetingMsg, foreground: "green", newline: true);

            string encodedText = @"--------------
[magenta]1.[magenta] Child or Elderly
[magenta]2.[magenta] Repeat * 10
[magenta]3.[magenta] The third word..
[red]0. Quit[red]
--------------
";

            io.WriteEncoded(encodedText);

            string? input = io.ReadAndClear();

            switch (input)
            {
                case "0":
                    io.Write("Exiting...", foreground: "blue");
                    break;

                case "1":
                    ChildOrElderly(io);
                    break;

                case "2":
                    RepeatTenTimes(io);
                    break;

                case "3":
                    TheThirdWord(io);
                    break;

                default:
                    io.Write(errorMsg, foreground: "red");
                    GenerateMenu(io);
                    break;
            }
        }

        private static void BackOrContinue(int callerOption, IO io)
        {

            string encodedText = @"[green]Go back or continue?[green]
[yellow]1.[yellow] - [blue]Back[blue]
[yellow]2.[yellow] - [blue]Continue[blue]";

            io.WriteEncoded(encodedText);

            ConsoleKeyInfo input = Console.ReadKey();

            io.ClearAll();
            if (input.KeyChar.ToString() == "1")
            {
                GenerateMenu(io);
                return;
            }
            else if (input.KeyChar.ToString() == "2")
            {
                if (callerOption == 1)
                {
                    ChildOrElderly(io);
                }
                else if (callerOption == 2)
                {
                    RepeatTenTimes(io);
                }
                else
                {
                    TheThirdWord(io);
                }
            }
        }
    }
}