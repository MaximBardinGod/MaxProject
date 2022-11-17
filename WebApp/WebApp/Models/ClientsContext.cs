using WebApp.Controllers;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ClientsContext:DbContext
    {

        public ClientsContext()
        {
        }

        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Mentor> Mentors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=Client;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
