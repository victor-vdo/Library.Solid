namespace LibrarySolid.Interfaces.Services
{
    public interface IBookService
    {
        ILibraryResult GetBookById(Guid id);
        ILibraryResult GetAllBooks();
        ILibraryResult GetAllActiveBooks();
    }
}
