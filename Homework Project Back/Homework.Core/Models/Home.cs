namespace Homework.Core.Models;

public class Home
{
    public const int MAX_TITTLE_LENGTH = 250;
    private Home(Guid id, string title, string description, string photoPath, string firstName, string lastName, string phoneNumber, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        PhotoPath = photoPath;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Price = price;
    }
    public Guid Id { get; }
    public string Title { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public string PhotoPath { get; } = string.Empty;
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public string PhoneNumber { get; } = string.Empty;
    public decimal Price { get; }
    //public DateTime CreatedAt { get; }

    public static (Home Home, string Error) Create(Guid id, string title, string description, string photoPath, string firstName, string lastName, string phoneNumber, decimal price)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITTLE_LENGTH)
        {
            error = "Tittle can't be empty or longer 250 symbols";
        }

        var home = new Home(id, title, description, photoPath, firstName, lastName, phoneNumber, price);
        return (home, error);
    }
}