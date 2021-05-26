using Microsoft.EntityFrameworkCore;
using ASPDotNetRazorApp.Models;

namespace ASPDotNetRazorApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        public DbSet<Party> Parties { get; set; }
    }
}