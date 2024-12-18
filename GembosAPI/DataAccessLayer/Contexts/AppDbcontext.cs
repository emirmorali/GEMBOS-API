using GembosAPI.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GembosAPI.DataAccessLayer.Contexts
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
