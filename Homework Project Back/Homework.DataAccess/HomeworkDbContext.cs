using Homework.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homework.DataAccess;

public class HomeworkDbContext
{
    public HomeworkDbContext(DbContextOptions<HomeworkDbContext> options) 
        : base(options)
    {
    }

    public DbSet<HomeworkEntity> Homework { get; set; }
}