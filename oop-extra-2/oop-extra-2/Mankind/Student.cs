using System.Text;

internal class Student : Human
{
    private int facultyNumber;

    public Student(string firstName, string lastName, int facultyNumber) : base(firstName, lastName)
    {

        FacultyNumber = facultyNumber;
    }


    internal int FacultyNumber
    {
        get
        {
            return facultyNumber;
        }
        set
        {
            if (value.ToString().Length >= 5 && value.ToString().Length <= 10)
            {
                facultyNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid faculty number!");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder stats = new();

        stats.AppendLine($"First fame: {FirstName}");
        stats.AppendLine($"Last name: {LastName}");
        stats.AppendLine($"Faculty number: {FacultyNumber}");

        return stats.ToString();
    }
}