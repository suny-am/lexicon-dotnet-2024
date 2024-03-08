// this class exist in order to bake in validation, sanitizing etc for all IO operations.

namespace MainMenu
{
    public static class IO
    {

        public static void Write(string text, int color = 8, bool newLine = true)
        {
            try
            {
                Console.ForegroundColor = (ConsoleColor)color;
                Console.Write(text);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                Console.ResetColor();
                if(newLine) Console.Write("\n");
            }
        }

        public static void Write(string text)
        {
            Write(text, 0);
        }

        public static uint? ReadUInt()
        {
            string input = Console.ReadLine();

            bool isUnsignedInt = uint.TryParse(input, out uint number);

            if (!isUnsignedInt) return null;
            return number;

        }

        public static string? Read()
        {
            string? input;
            try
            {
                input = Console.ReadLine();
            }
            catch (System.Exception)
            {
                throw;
            }
            return input;
        }

        public static void ClearAll()
        {
            // more cleanup logic can go here...
            Console.Clear();
        }
    }
}