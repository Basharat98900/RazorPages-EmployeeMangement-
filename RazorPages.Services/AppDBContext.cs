using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Services
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Employee>? Employees { get; set; }
    }
}
