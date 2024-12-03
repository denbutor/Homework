namespace Homework.DataAccess.Repositories;

public interface IHomeworksRepository
{
    Task<Guid> Create(Homework homework);
    Task<Guid> Delete(Guid id);
    Task<List<Homework>> Get();
    Task<Guid> Update(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price);
}