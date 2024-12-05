using Homework.DataAccess.Entities;
using Homework.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Homework.DataAccess.Configurations;

public class HomeConfiguration : IEntityTypeConfiguration<HomeEntity>
{
    public void Configure(EntityTypeBuilder<HomeEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title)
            .HasMaxLength(Home.MAX_TITTLE_LENGTH)
            .IsRequired();
        
        builder.Property(b => b.Description)
            .IsRequired();
        
        builder.Property(b => b.PhotoPath)
            .IsRequired();
        
        builder.Property(b => b.FirstName)
            .IsRequired();
        
        builder.Property(b => b.LastName)
            .IsRequired();
        
        builder.Property(b => b.PhoneNumber)
            .IsRequired();
        
        builder.Property(b => b.Price)
            .IsRequired();
    }
}