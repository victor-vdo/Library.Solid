using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace LibrarySolid.Interfaces
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        int SaveChanges();
        IDbContextTransaction BeginTransaction(IsolationLevel isolation);
    }
}
