internal class Author
{
    private string firstName;
    private string lastName;

    internal Author()
    {

    }

    internal Author(string firstName, string lastName)
    {
        (FirstName, LastName) = (firstName, lastName);
    }

    internal string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            firstName = value;
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
            char firstChar = value.First();
            
            if (char.IsDigit(firstChar))
            {
                throw new ArgumentException("First character in Author's last name cannot be of Integer type!");
            }
            else
            {
                lastName = value;
            }
        }
    }
}