using Homework.DataAccess.Repositories;

namespace Homework.Application.Services;

public class HomeworksService : IHomeworksService
{
    private readonly IHomeworksRepository _homeworksRepository;

    public HomeworksService(IHomeworksRepository homeworksRepository)
    {
        _homeworksRepository = homeworksRepository;
    }

    public async Task<List<Homework>> GetAllHomeworks()
    {
        return await _homeworksRepository.Get();
    }
    
    public async Task<Guid> CreateHomework(Homework homework)
    {
        return await _homeworksRepository.Create(homework);
    }
    
    public async Task<Guid> UpdateHomework(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price)
    {
        return await _homeworksRepository.Update(id, title, description, photoPath, firstName, lastName, phoneNumber, price);
    }
    
    public async Task<Guid> DeleteHomework(Guid id)
    {
        return await _homeworksRepository.Delete(id);
    }
}