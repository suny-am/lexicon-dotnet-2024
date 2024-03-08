using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace MainMenu
{
    internal enum TextColor
    {
        defaultColor = 8,
        blue = 9,
        green = 10,
        magenta = 5,
        red = 12,
        yellow = 14,
    }

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

    internal class TextOption
    {
        public int optionKey;
        public string? text;
        public TextColor textColor;

    }

    internal class Program
    {
        private const int green = (int)TextColor.green;
        private const int yellow = (int)TextColor.yellow;
        private const int red = (int)TextColor.red;
        private const int blue = (int)TextColor.blue;
        private const int magenta = (int)TextColor.magenta;
        private const int defaultColor = (int)TextColor.defaultColor;

        private static AgeRange childRange = new(5, 20);
        private static AgeRange elderlyRange = new(64, 100);

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
        internal static readonly List<TextOption> textOptions = new()

    {
        new TextOption(){optionKey = 1, text="\"Child Or Elderly?\"", textColor=TextColor.yellow},
        new TextOption(){optionKey = 2, text="\"Repeat * 10!\"", textColor=TextColor.yellow},
        new TextOption(){optionKey = 3, text="\"The third word...\"", textColor=TextColor.yellow},
        new TextOption(){optionKey = 0, text="Quit", textColor=TextColor.red}
    };

        public static void Main()
        {
            do
            {
                IO.ClearAll();
                GenerateMenu();
                running = false;
            }
            while (running);
        }

        // Assignment 1
        private static void ChildOrElderly()
        {
            int totalPrice = 0;

            IO.Write("Welcome to the cinema! how many are you?:", green);

            int? visitorCount = (int?)IO.ReadUInt();

            if (visitorCount is null)
            {
                IO.Write("Please specify a count in digits", red);
                ChildOrElderly();
                return;
            }

            if (visitorCount < 2)
            {
                IO.Write("So only one of you? Alright!", green);
            }
            else
            {
                IO.Write($"Alright! {visitorCount} of you! We'll proceed with taking the age of each person.", green);
            }

            IO.Write("Please do note the special prices:");
            IO.Write($"children age bracket (ages {childRange.Start}-{childRange.End}): {(int)TicketPrices.childPrice}kr SEK.", blue);
            IO.Write($"elderly age bracket (ages {elderlyRange.Start}-{elderlyRange.End}): {(int)TicketPrices.elderlyPrice}kr SEK.", blue);
            IO.Write("People below 5 or over 100 can visit for free!", magenta);

            GetPrice(ref totalPrice, visitorCount);

            if (totalPrice == 0)
            {
                if (visitorCount > 2)
                {
                    IO.Write($"Looks like you are going for free!", yellow);
                }
                else
                {
                    IO.Write($"Looks like all {visitorCount} of you are going for free!", yellow);
                }
            }
            else
            {
                IO.Write($"the total price for you (visitor count: {visitorCount}) is {totalPrice}kr SEK!", yellow);
            }
            IO.Write("\n");
            BackOrContinue(1);
        }

        public static void GetPrice(ref int basePrice, int? visitorCount = 1)
        {
            for (int i = 0; i < visitorCount; i++)
            {
                CalculateTotal(i, visitorCount, ref basePrice);
            }
        }

        public static void CalculateTotal(int visitorIndex, int? visitorCount, ref int basePrice)
        {
            if (visitorCount < 2)
            {
                IO.Write($"Please specify your age in digits:", green);
            }
            else
            {
                IO.Write($"Please specify person {visitorIndex + 1}'s age in digits:", green);
            }

            int? ageInNumber = (int?)IO.ReadUInt();

            if (ageInNumber is null)
            {
                IO.Write("Please specify an age in numbers", red);
                GetPrice(ref basePrice, visitorCount);
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
        private static void RepeatTenTimes()
        {
            IO.Write("Please provide a sentence:", green);
            string input = IO.Read();
            IO.ClearAll();
            for (int i = 0; i < 10; i++)
            {
                if (input != null) IO.Write($"{input} ", green, false);
            }
            IO.Write("\n", defaultColor, false);
            BackOrContinue(2);
        }

        // Assignment 3
        private static void TheThirdWord()
        {
            int minimumWordCount = 3;

            Regex whitespaces = new Regex(@"\s");

            IO.Write("Please provide a sentence consisting of at least ", green, false);
            IO.Write($"{minimumWordCount}", defaultColor, false);
            IO.Write(" words:", green);

            string input = IO.Read();

            string[] stringArray = whitespaces.Split(input);

            if (stringArray.Length < 3)
            {
                IO.Write($"Please provide at least {minimumWordCount} words!", red);
                TheThirdWord();
                return;
            }
            IO.ClearAll();
            IO.Write("The third word is ", yellow, false);
            IO.Write($"\"{stringArray[2]}\"!", red);
            BackOrContinue(3);
        }

        public static void GenerateMenu()
        {
            string greetingMsg = "Hello! Please select an action from the options below (the given key followed by [Enter] key):";
            string errorMsg = "Something went wrong... :[";

            IO.Write(greetingMsg, green);

            IO.Write("Key", blue, false);
            IO.Write(" - ", defaultColor, false);
            IO.Write("Option", yellow);
            IO.Write("------------");
            foreach (TextOption option in textOptions)
            {
                IO.Write($"{option.optionKey}", option.optionKey == 0 ? red : blue, false);
                IO.Write(" - ", defaultColor, false);
                IO.Write($"{option.text}", option.optionKey == 0 ? red : yellow);
            }
            IO.Write("------------");

            string? input = IO.Read();

            switch (input)
            {
                case "0":
                    IO.Write("Exiting...", blue);
                    break;

                case "1":
                    IO.ClearAll();
                    ChildOrElderly();
                    break;

                case "2":
                    IO.ClearAll();
                    RepeatTenTimes();
                    break;

                case "3":
                    IO.ClearAll();
                    TheThirdWord();
                    break;

                default:
                    IO.ClearAll();
                    IO.Write(errorMsg, red);
                    GenerateMenu();
                    break;
            }
        }

        private static void BackOrContinue(int callerOption)
        {
            IO.Write("Go back or continue?", green);
            IO.Write("1", blue, false);
            IO.Write(" - ", defaultColor, false);
            IO.Write("Back", yellow);
            IO.Write("2", blue, false);
            IO.Write(" - ", defaultColor, false);
            IO.Write("Continue", yellow);

            ConsoleKeyInfo input = Console.ReadKey();

            IO.ClearAll();
            if (input.KeyChar.ToString() == "1")
            {
                GenerateMenu();
                return;
            }
            else if (input.KeyChar.ToString() == "2")
            {
                if (callerOption == 1)
                {
                    ChildOrElderly();
                }
                else if (callerOption == 2)
                {
                    RepeatTenTimes();
                }
                else
                {
                    TheThirdWord();
                }
            }
        }
    }
}