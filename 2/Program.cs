using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}


public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Author
    {
        get => this.author;
        protected set
        {
            var indexOf = value.IndexOf(' ');
            if (char.IsDigit(value[indexOf + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    public string Title
    {
        get => this.title;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get => this.price;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"Title: {this.Title}")
        .AppendLine($"Author: {this.Author}")
        .AppendLine($"Price: {this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}
public class GoldenEditionBook : Book
{

    public GoldenEditionBook(string title, string author, decimal price)
        : base(title, author, price)
    {

    }

    public override decimal Price
    {
        get => base.Price * 1.3m;
    }
}

