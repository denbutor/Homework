namespace Homework.Application.Services;

public interface IHomeworksService
{
    Task<Guid> CreateHomework(Homework homework);
    Task<Guid> DeleteHomework(Guid id);
    Task<List<Homework>> GetAllHomeworks();
    Task<Guid> UpdateHomework(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price);
}