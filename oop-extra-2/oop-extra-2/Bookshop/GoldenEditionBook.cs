internal class GoldenEditionBook : Book
{

    internal GoldenEditionBook(Author author, string title, decimal price) : base(author, title, price) { }

    internal override decimal Price
    {
        get => base.Price * 1.30m;
        set => base.Price = value;
    }
}