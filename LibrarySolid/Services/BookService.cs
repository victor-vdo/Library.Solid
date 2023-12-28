using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Services
{
    public class BookService
    {
        public IBookRepository _repository { get; set; }
        private LibraryResult libraryResult { get; set; } = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public ILibraryResult GetBookById(Guid id)
        {
            var book = _repository.GetById(id);

            if (book != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Book found successfully!";
                libraryResult.Data = book;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Book not found!";
                libraryResult.Data = book;
                return libraryResult;
            }
        }

        public ILibraryResult GetBookByAuthor(string author)
        {
            var book = _repository.GetByAuthor(author);


            if (book != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Book found successfully!";
                libraryResult.Data = book;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Book not found!";
                libraryResult.Data = book;
                return libraryResult;
            }
        }

        public ILibraryResult GetBookByTitle(string title)
        {
            var book = _repository.GetByTitle(title);


            if (book != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Book found successfully!";
                libraryResult.Data = book;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Book not found!";
                libraryResult.Data = book;
                return libraryResult;
            }
        }

        public ILibraryResult GetAllBooks()
        {
            var books = _repository.GetAll();

            if (books != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Books founds successfully!";
                libraryResult.Data = books;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "None book was found!";
                libraryResult.Data = books;
                return libraryResult;
            }
        }

        public ILibraryResult GetAllActiveBooks()
        {
            var books = _repository.GetAllActive();

            if (books != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Books founds successfully!";
                libraryResult.Data = books;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "None book was found!";
                libraryResult.Data = books;
                return libraryResult;
            }
        }

        public ILibraryResult RemoveBook(Guid id)
        {
             var isRemoved = _repository.RemoveById(id);


            if (isRemoved)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Book deleted!";
                libraryResult.Data = isRemoved;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.BadRequest;
                libraryResult.Message = "An error occurred when deleting the book!";
                libraryResult.Data = isRemoved;
                return libraryResult;
            }
        }
    }
}
