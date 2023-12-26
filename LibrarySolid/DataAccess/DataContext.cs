using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySolid.DataAccess
{
    public class DataContext :  DbContext
    {
        public DataContext()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}