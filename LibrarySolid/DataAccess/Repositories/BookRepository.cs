using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;
using System.Data;

namespace LibrarySolid.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDataContext _context;
        public BookRepository(IDataContext context)
        {
            _context = context;
        }

        public bool Add(Book book)
        {
            var transaction = _context.BeginTransaction(IsolationLevel.Serializable);
            _context.Books.Add(book);
            int isUpdated = _context.SaveChanges();
            transaction.Commit();

            if (isUpdated > 0)
                return true;
            return false;
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

        public bool Update(Book book)
        {
            var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable);
            _context.Books.Update(book);
            var isUpdated = _context.SaveChanges();
            transaction.Commit();

            if(isUpdated > 0) 
                return true;
            return false;

        }

        public bool RemoveById(Guid id)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == id);

            if (book != null)
            {
                // Soft delete
                book.Active = false;

                var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable);
                _context.Books.Update(book);
                var isUpdated = _context.SaveChanges();
                transaction.Commit();

                if (isUpdated > 0)
                    return true;
                return false;
            }
            return false;
        }

        public List<Book> GetAll()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public List<Book> GetAllActive()
        {
            var books = _context.Books.Where(w=>w.Active.Equals(true)).ToList();
            return books;
        }
    }
}
