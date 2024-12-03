namespace Homework.Core.Models;

public class Homework
{
    private Homework(Guid Id, string Title, string Description, string PhotoPath, string FirstName, string LastName, string PhoneNumber, string Price)
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
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    public static (Homework Homework, string Error) Create(Guid id, string Title, string Description, string PhotoPath, string FirstName, string LastName, string PhoneNumber, string Price)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(tittle) || tittle.Length > MAX_TITTLE_LENGTH)
        {
            error = "Tittle can't be empty or longer 250 symbols";
        }

        var homework = new Homework(id, title, description, photoPath, firstName, lastName, phoneNumber, price);
        return (homework, error);
    }
}