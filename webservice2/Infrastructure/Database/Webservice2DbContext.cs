using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webservice2.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;

namespace webservice2
{

    public interface IWebservice2DbContext
    {
        DbSet<User> Users { get; }

        Task Save();
    }

    public class Webservice2DbContext : DbContext, IWebservice2DbContext
    {

        public DbSet<User> Users { get; set; }
        
        public Webservice2DbContext()
        {
        }

        public Webservice2DbContext(DbContextOptions<Webservice2DbContext> options)
            : base(options)
        {
        }

        public Task Save()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=10.0.2.15,31979;Initial Catalog=webservice2;User Id=sa;Password=paris=75;MultipleActiveResultSets=True;App=Authentication");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }        
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }
}
