using System.Text;

internal class Worker : Human
{
    private decimal salary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal salary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        (Salary, WorkHoursPerDay) = (salary, workHoursPerDay);
    }

    internal decimal Salary
    {
        get
        {
            return salary;
        }
        set
        {
            if (value < 10.00m)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            else
            {
                salary = value;
            }
        }
    }
    internal decimal WorkHoursPerDay
    {
        get
        {
            return workHoursPerDay;
        }
        set
        {
            if (value >= 1.00m && value <= 12.00m)
            {
                workHoursPerDay = value;
            }
            else
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder stats = new();

        stats.AppendLine($"First fame: {FirstName}");
        stats.AppendLine($"Last name: {LastName}");
        stats.AppendLine($"Week salary: {Salary}");
        stats.AppendLine($"Work hours per day: {WorkHoursPerDay.ToString("0.00")}");
        stats.AppendLine($"Salary Per Hour: {(Salary / 5 / WorkHoursPerDay).ToString("0.00")}");

        return stats.ToString();
    }
}