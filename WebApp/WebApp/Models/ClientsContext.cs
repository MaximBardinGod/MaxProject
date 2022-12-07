using WebApp.Controllers;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ClientsContext:DbContext
    {
        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options) {}

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Mentor> Mentors { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
