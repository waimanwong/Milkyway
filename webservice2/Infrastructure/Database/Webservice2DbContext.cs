using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webservice2.Domain.Users;

namespace webservice2
{

    public interface IWebservice2DbContext
    {
        DbSet<User> Users { get; }
    }

    public class Webservice2DbContext : DbContext, IWebservice2DbContext
    {

        public DbSet<User> Users { get; }
        
        public Webservice2DbContext()
        {
        }

        public Webservice2DbContext(DbContextOptions<Webservice2DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
        }
    }
}
