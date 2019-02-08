using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webservice2.Domain.Users;

namespace webservice2
{

    public interface IWebservice2DbContext
    {
        DbSet<User> Users { get; }

        void Commit();
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

        public void Commit()
        {
            this.Commit();
        }  
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=webservice2;User Id=sa;Password=paris=75;MultipleActiveResultSets=True;App=Authentication");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
        }
    }
}
