using System.Text;

internal class Person
{

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    internal Person() { }

    internal Person(string firstName, string lastName, int age)
    {
        (FirstName, LastName, Age) = (firstName, lastName, age);
    }

    internal Person(string firstName, string lastName, int age, decimal salary)
    {
        (FirstName, LastName, Age, Salary) = (firstName, lastName, age, salary);
    }

    internal string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name must be at least 3 characters long!");
            }
            else
            {
                firstName = value;
            }
        }
    }

    internal string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name must be at least 3 characters long!");
            }
            else
            {
                lastName = value;
            }
        }
    }

    internal int Age
    {
        get
        {
            return age;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer!");
            }
            else
            {
                age = value;
            }
        }
    }

    internal decimal Salary
    {
        get
        {
            return salary;
        }
        set
        {
            decimal threshold = 460.0m;
            if (value < threshold)
            {
                throw new ArgumentException("Salary cannot be less than 460 dollars!");
            }
            else
            {
                salary = value;
            }
        }
    }


    public override string ToString()
    {
        return $"{FirstName} {LastName} is {Age} years old and receives {salary} dollars in salary.";
    }

    internal void IncreaseSalary(decimal percentage)
    {
        Salary += Salary * percentage;
    }
}