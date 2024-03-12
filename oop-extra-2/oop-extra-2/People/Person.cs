using System.Text;

public class Person
{

    protected string name;
    protected int age;

    public Person()
    {

    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    protected virtual string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length < 3)
            {

                throw new ArgumentException("Name must be at least 3 characters long!");
            }
            else
            {
                name = value;
            }
        }
    }
    protected virtual int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0)
            {


                throw new ArgumentException("Age must be of positive integer value!");
            }
            else
            {
                age = value;
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
