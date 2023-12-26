using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book GetById(Guid id);
        Book GetByAuthor(string author);
        Book GetByTitle(string title);
        void Add(Book book);
        void Update(Book book);
        void RemoveById(Guid id);
    }
}
