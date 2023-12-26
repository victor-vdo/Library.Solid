using LibrarySolid.Interfaces;
using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySolid.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        private const string ConnectionString = 
            "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=library";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        void IDataContext.SaveChanges()
        {
            base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}