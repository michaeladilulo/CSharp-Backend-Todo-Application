using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoApplicationApi.TodoApplicationApi.DataModel.Models;

namespace TodoApplicationApi.TodoApplicationApi.DataModel;

public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
	public DbSet<Todo> Todos { get; set; }
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{}

    public override int SaveChanges()
    {
        DateTime currentTime = DateTime.UtcNow;

        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if(entry.Entity is BaseEntity entity)
            {
                if(entry.State == EntityState.Added)
                {
                    entity.CreatedAt = currentTime;
                }

                entity.UpdatedAt = currentTime;
            }
        }

        return base.SaveChanges();
    }
}
