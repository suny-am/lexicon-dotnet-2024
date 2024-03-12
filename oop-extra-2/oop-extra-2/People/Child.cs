using System.Text;

public class Child : Person
{

    public Child(string name, int age) : base(name, age) { }

    protected override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            else
            {
                base.Age = value;
            }
        }
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(string.Format("Name: {0}, Age: {1}", Name, Age));
        return stringBuilder.ToString();
    }
}