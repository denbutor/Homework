using Homework.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homework.DataAccess;

public class HomeworkDbContext : DbContext
{
    public HomeworkDbContext(DbContextOptions<HomeworkDbContext> options) 
        : base(options)
    {
    }

    public DbSet<HomeEntity> Homes { get; set; }
}