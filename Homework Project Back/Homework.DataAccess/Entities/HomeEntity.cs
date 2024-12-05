using Homework.Core.Models;
using Homework.DataAccess.Entities;
using Homework.DataAccess.Configurations;

namespace Homework.DataAccess.Entities;

public class HomeEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }
}