using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Services
{
    public interface IBookService
    {
        ILibraryResult GetBookById(Guid id);
        ILibraryResult GetBookByTitle(string title);
        ILibraryResult GetBooksByAuthor(string author);
        ILibraryResult GetBooksByYear(string year);
        ILibraryResult GetAllBooks();
        ILibraryResult GetAllActiveBooks();
        ILibraryResult AddBook(Book book);
        ILibraryResult RemoveBook(Guid id);
    }
}
