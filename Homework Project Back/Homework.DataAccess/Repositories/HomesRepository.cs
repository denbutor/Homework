using Homework.Core.Models;
using Homework.DataAccess.Entities;
using Homework.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;


namespace Homework.DataAccess.Repositories;

public class HomesRepository : IHomesRepository
{
    private readonly HomeworkDbContext _context;

    public HomesRepository (HomeworkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Home>> Get()
    {
        var homeEntities = await _context.Homes
            .AsNoTracking()
            .ToListAsync();
        
        var homes = homeEntities
            .Select(b =>
                Home.Create(b.Id, b.Title, b.Description, b.PhotoPath, b.FirstName, b.LastName, b.PhoneNumber, b.Price)
                    .Home)
            .ToList();
        return homes;
    }

    public async Task<Guid> Create(Home home)
    {
        var homeEntity = new HomeEntity
        {
            Id = home.Id,
            Title = home.Title,
            Description = home.Description,
            PhotoPath = home.PhotoPath,
            FirstName = home.FirstName,
            LastName = home.LastName,
            PhoneNumber = home.PhoneNumber,
            Price = home.Price,
        };
        await _context.Homes.AddAsync(homeEntity);
        await _context.SaveChangesAsync();

        return homeEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price)
    {
        await _context.Homes
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.PhotoPath, b => photoPath)
                .SetProperty(b => b.FirstName, b => firstName)
                .SetProperty(b => b.LastName, b => lastName)
                .SetProperty(b => b.PhoneNumber, b => phoneNumber)
                .SetProperty(b => b.Price, b => price)
            );
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Homes
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}