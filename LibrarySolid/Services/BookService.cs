using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Services
{
    public class BookService : IBookService
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
            var books = _repository.GetByAuthor(author);


            if (books != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Books found successfully!";
                libraryResult.Data = books;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Books not found!";
                libraryResult.Data = books;
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

        public ILibraryResult GetBooksByAuthor(string author)
        {
            var books = _repository.GetByAuthor(author);


            if (books != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Books found successfully!";
                libraryResult.Data = books;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "None book found!";
                libraryResult.Data = books;
                return libraryResult;
            }
        }

        public ILibraryResult GetBooksByYear(string year)
        {
            var book = _repository.GetByYear(year);


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

        public ILibraryResult AddBook(Book book)
        {
            book.ISBN = GenerateISBN();
            book.Active = true;
            var isAdded = _repository.Add(book);

            if (isAdded)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Book added successfully!";
                libraryResult.Data = book;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.BadRequest;
                libraryResult.Message = "Book not added!";
                libraryResult.Data = book;
                return libraryResult;
            }
        }

        public string GenerateISBN()
        {
            Random random = new Random();
            int[] numbers = new int[12];

            for (int i = 0; i < 12; i++)
            {
                numbers[i] = random.Next(0, 10);
            }

            // Calcular o último dígito (dígito de verificação)
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int multiplier = i % 2 == 0 ? 1 : 3;
                sum += numbers[i] * multiplier;
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            var digits = string.Join("", numbers);

            var isbn = string.Concat(digits, checkDigit.ToString());

            return isbn;
        }

    }
}
