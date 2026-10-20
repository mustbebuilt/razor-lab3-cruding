using Microsoft.EntityFrameworkCore;
using rz.Models;

namespace rz.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<Staff> Staff { get; set; } = null!;
}