using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySolid.Interfaces
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        void SaveChanges();
    }
}
