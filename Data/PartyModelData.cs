using Microsoft.EntityFrameworkCore;
using ASPDotNetRazorApp.Models;

namespace ASPDotNetRazorApp.Data
{
    public class PartyContext : DbContext
    {
        public PartyContext(DbContextOptions<PartyContext> options) : base(options)
        {
        }

        public DbSet<PartyModel> Party { get; set; }
    }
}