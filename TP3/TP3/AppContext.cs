using System.Collections.Generic;
using TP3.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace TP3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Mentor> Mentor { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
