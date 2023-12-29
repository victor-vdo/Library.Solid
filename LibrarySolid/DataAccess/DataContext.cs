using LibrarySolid.Interfaces;
using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

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

        int IDataContext.SaveChanges()
        {
            return base.SaveChanges();
        }

        IDbContextTransaction IDataContext.BeginTransaction(IsolationLevel isolation)
        { 
            return base.Database.BeginTransaction(isolation);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}