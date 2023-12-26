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

        public Book GetById(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);
            return book;
        }

        public Book GetByAuthor(string author)
        {
            var book = _context.Books.FirstOrDefault(u => u.Author.ToLower().Equals(author.ToLower()));
            return book;
        }

        public Book GetByTitle(string title)
        {
            var book = _context.Books.FirstOrDefault(u => u.Title.ToLower().Equals(title.ToLower()));
            return book;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void RemoveById(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);

            if (book != null)
            {
                // Soft delete
                book.Active = false;
                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            var books = _context.Books.ToList();
            return books;
        }
    }
}
