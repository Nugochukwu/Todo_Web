using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
//adding an item set to the database context
    public DbSet<TodoItem> Items { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
{
base.OnModelCreating(builder);
// ...
}
}
