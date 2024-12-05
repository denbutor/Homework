using Homework.Core.Models;
using Homework.DataAccess.Repositories;

namespace Homework.Application.Services;

public class HomesService : IHomesService
{
    private readonly IHomesRepository _homesRepository;

    public HomesService(IHomesRepository homesRepository)
    {
        _homesRepository = homesRepository;
    }

    public async Task<List<Home>> GetAllHomes()
    {
        return await _homesRepository.Get();
    }
    
    public async Task<Guid> CreateHome(Home home)
    {
        return await _homesRepository.Create(home);
    }
    
    public async Task<Guid> UpdateHome(Guid id, string title, string description, string photoPath, string firstName,
        string lastName, string phoneNumber, decimal price)
    {
        return await _homesRepository.Update(id, title, description, photoPath, firstName, lastName, phoneNumber, price);
    }
    
    public async Task<Guid> DeleteHome(Guid id)
    {
        return await _homesRepository.Delete(id);
    }
}