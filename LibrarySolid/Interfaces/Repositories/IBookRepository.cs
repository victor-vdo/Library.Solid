using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book GetById(Guid id);
        Book GetByAuthor(string author);
        Book GetByTitle(string title);
        List<Book> GetAll();
        List<Book> GetAllActive();
        bool Add(Book book);
        bool Update(Book book);
        bool RemoveById(Guid id);
    }
}
