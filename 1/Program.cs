using System;
using System.Text;


public class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
public class Person
{
    private int age;
    private string name;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual int Age
    {
        get => this.age;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }

    public virtual string Name
    {
        get => this.name;
        protected set
        {
            if (value.Length < 3 || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            this.name = value;
        }
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

        return stringBuilder.ToString();
    }

}
public class Child : Person
{
    public Child(string name, int age)
        : base(name, age)
    {

    }

    public override int Age
    {
        get => base.Age;
        protected set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            base.Age = value;
        }
    }

}