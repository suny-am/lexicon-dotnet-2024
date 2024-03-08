using System.Diagnostics.CodeAnalysis;

internal class Person
{

    private int age;
    private string fName;
    private string lName;

    [SetsRequiredMembers]
    internal Person(int age, string fName, string lName)
    {
        (Age, FName, LName) = (age, fName, lName);
    }

    [SetsRequiredMembers]
    internal Person(int age, string fName, string lName, double? height, double? weight) : this(age, fName, lName)
    {
        (Height, Weight) = (height, weight);
    }

    internal required int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
            {
                age = value;
            }
            else
            {
                throw new ArgumentException("The age has to be a positive integer value.");
            }
        }
    }
    internal required string FName
    {
        get { return fName; }
        set
        {
            if (value.Length >= 2 && value.Length <= 10)
            {
                fName = value;
            }
            else
            {
                throw new ArgumentException("Given name limit is between 2 to 10 charaters.");
            }
        }
    }
    internal required string LName
    {
        get { return lName; }
        set
        {
            if (value.Length >= 3 && value.Length <= 15)
            {
                lName = value;
            }
            else
            {
                throw new ArgumentException("Surname limit is between 3 to 15 characters.");
            }
        }
    }
    internal double? Height { get; set; }
    internal double? Weight { get; set; }
}