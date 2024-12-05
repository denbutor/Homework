using  Homework.Core.Models;

namespace Homework.DataAccess.Repositories;


public interface IHomesRepository
{
    Task<Guid> Create(Home home);
    Task<Guid> Delete(Guid id);
    Task<List<Home>> Get();
    Task<Guid> Update(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price);
}