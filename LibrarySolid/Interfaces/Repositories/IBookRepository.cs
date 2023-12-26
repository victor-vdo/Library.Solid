using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book GetById(Guid id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Guid id);
    }
}
