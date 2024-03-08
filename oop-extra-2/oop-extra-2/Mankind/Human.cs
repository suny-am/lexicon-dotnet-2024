internal class Human
{
    protected string firstName;
    protected string lastName;

    internal Human() { }

    internal Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    internal string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            if (char.IsUpper(value.First()) == false)
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if (value.Length <= 3)
            {

                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
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
            if (char.IsUpper(value.First()) == false)
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length <= 2)
            {

                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            else
            {
                lastName = value;
            }
        }
    }


}