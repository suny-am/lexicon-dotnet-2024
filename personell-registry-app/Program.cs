using System.Text.RegularExpressions;

namespace PersonellRegisterApp
{
    public class Program
    {
        static void Main()
        {
            CreateEmployees();
        }

        private static List<Employee> EmployeeList = new List<Employee>();

        public static void PrintEmployees()
        {
            Console.WriteLine("\nFinished creating new employee entries. Fetching data...");
            Console.WriteLine("Summarized list of employees in registry:");
            foreach (Employee e in EmployeeList)
            {
                Console.WriteLine("---");
                Console.WriteLine(e.FirstName);
                Console.WriteLine(e.LastName);
                Console.WriteLine(e.Wage);
            }
        }

        public static void CreateEmployees()
        {
            string pattern = @"[^a-zA-Z]";

            Console.WriteLine("\nplease enter the given name of the new employee:");
            string firstName = Console.ReadLine();
            Console.WriteLine("please enter the surname of the new employee:");
            string lastName = Console.ReadLine();

            if (firstName.Length == 0 || lastName.Length == 0)
            {
                Console.WriteLine("A name must be entered.");
                CreateEmployees();
                return;
            }

            Match m1 = Regex.Match(firstName, pattern);
            Match m2 = Regex.Match(lastName, pattern);

            // escape non alphabetical chars
            if (m1.Success || m2.Success)
            {
                Console.WriteLine("only alphabetical characters are allowed in the employee name");
                CreateEmployees();
                return;
            }

            // escape non digits for salary
            Console.WriteLine("please enter the salary of the new employee:");

            var input = Console.ReadLine();

            bool success = int.TryParse(input, out int wage);
            if (!success)
            {
                Console.WriteLine("Setting wage to 0 since nothing else was specified.");
                wage = 0;
            }

            Employee employee = new Employee();

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Wage = wage;

            EmployeeList.Add(employee);

            Console.WriteLine("employee created!");

            Console.WriteLine("Add another employee? press [Enter] to continue. Press any other key to finish adding employees.");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                CreateEmployees();
                return;
            }
            else if
                (EmployeeList.Count > 0)
            {
                PrintEmployees();
            }
            else
            {
                CreateEmployees();
                return;
            }
        }

    }
}