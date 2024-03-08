using System.Text;

internal class Book
{

    private string title;
    private Author author;
    private decimal price;

    internal Book()
    {

    }

    internal Book(Author author)
    {
        Author = author;
    }
    internal Book(Author author, string title) : this(author)
    {
        Title = title;
    }
    internal Book(Author author, string title, decimal price) : this(author, title)
    {
        Price = price;
    }

    internal string Title
    {
        get
        {
            return title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters long!");
            }
            else
            {
                title = value;
            }
        }
    }
    internal Author Author
    {
        get
        {
            return author;
        }
        set
        {
            author = value;
        }
    }
    internal virtual decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value <= 0.00m)
            {
                throw new ArgumentException("Price must be of positive Integer type!");
            }
            else
            {
                price = value;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder stats = new();

        stats.AppendLine($"Type: {this.GetType().Name}");
        stats.AppendLine($"Title: {Title}");
        stats.AppendLine($"Author: {Author}");
        stats.AppendLine($"Price: {Price}");

        return stats.ToString();
    }
}