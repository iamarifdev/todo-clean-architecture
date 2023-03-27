using Microsoft.EntityFrameworkCore;
using TodoCQRS.Domain.Entities;

namespace TodoCQRS.Infrastructure.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}