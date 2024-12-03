namespace Homework.Contracts;

public record HomeworkResponse(
    Guid Id,
    string Title,
    string Description,
    string PhotoPath,
    string FirstName,
    string LastName,
    string PhoneNumber,
    decimal Price);