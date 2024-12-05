namespace Homework.API.Contracts;

public record HomesRequest(
    string Title,
    string Description,
    string PhotoPath,
    string FirstName,
    string LastName,
    string PhoneNumber,
    decimal Price);