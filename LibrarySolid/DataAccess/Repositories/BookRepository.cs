using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;

namespace LibrarySolid.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDataContext _context;
        public BookRepository(IDataContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book GetById(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);
            return book;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
