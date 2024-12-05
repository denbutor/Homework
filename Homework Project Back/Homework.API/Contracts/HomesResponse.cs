namespace Homework.API.Contracts;

public record HomesResponse(
    Guid Id,
    string Title,
    string Description,
    string PhotoPath,
    string FirstName,
    string LastName,
    string PhoneNumber,
    decimal Price);