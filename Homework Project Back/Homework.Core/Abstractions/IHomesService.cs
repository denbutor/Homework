using  Homework.Core.Models;

namespace Homework.Application.Services;

public interface IHomesService
{
    Task<Guid> CreateHome(Home home);
    Task<Guid> DeleteHome(Guid id);
    Task<List<Home>> GetAllHomes();
    Task<Guid> UpdateHome(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price);
}