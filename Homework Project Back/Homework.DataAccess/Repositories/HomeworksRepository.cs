namespace Homework.DataAccess.Repositories;

public class HomeworksRepository : IHomeworksRepository
{
    private readonly (HomeworkDbContext _context)
    {
        _context = context;
    }

    public async Task<List<Core.Models.Homework>> Get()
    {
        var homeworkEntities = await _context.Homework
            .AsNoTracking()
            .ToListAsync();
        var homework = homeworkEntities
            .Select(b =>
                Homework.Create(b.Id, b.Title, b.Description, b.PhotoPath, b.FirstName, b.LastName, b.PhoneNumber, b.Price)
                    .Homework)
            .ToList();
        return homework;
    }

    public async Task<Guid> Create(Homework homework)
    {
        var homeworkEntity = new HomeworkEntity
        {
            Id = homework.Id,
            Title = homework.Title,
            Description = homework.Description,
            PhotoPath = homework.PhotoPath,
            FirstName = homework.FirstName,
            LastName = homework.LastName,
            PhoneNumber = homework.PhoneNumber,
            Price = homework.Price,
        };
        await _context.Homework.AddAsync(homeworkEntity);
        await _context.SaveChangesAsync();

        return homeworkEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price)
    {
        await _context.Homework
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.PhotoPath, b => photoPath)
                .SetProperty(b => b.FirstName, b => firstName)
                .SetProperty(b => b.LastName, b => lastName)
                .SetProperty(b => b.PhoneNumber, b => phoneNumber)
                .SetProperty(b => b.Price, b => price)
            )
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Homeworks
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync();
        return id;
    }
}