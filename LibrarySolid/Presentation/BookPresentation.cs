using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Presentations;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Presentation
{
    public class BookPresentation : IBookPresentation
    {
        private readonly IBookService _service;
        private ILibraryResult _result = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);
        private List<Book> _books = new List<Book>();

        public BookPresentation(IBookService service)
        {
            _service = service;
        }

        #region Public Methods

        public void BookRegister()
        {
            var book = new Book();
            Console.WriteLine("Insert the title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Insert the author: ");
            var author = Console.ReadLine();
            Console.WriteLine("Insert the year: ");
            var year = Console.ReadLine();

            book.Title = title;
            book.Author = author;
            book.Year = year;

            var result = _service.AddBook(book);
            ConsoleResult.Result(result);
        }

        public void ConsultBook()
        {
            Console.WriteLine("Select an option below:");
            Console.WriteLine("1 - Search by ID");
            Console.WriteLine("2 - Search by title");
            Console.WriteLine("3 - Search by author");
            Console.WriteLine("4 - Search by year");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Insert the ID:");
                    var readId = Console.ReadLine();
                    Guid.TryParse(readId, out Guid id);
                    var resultId = _service.GetBookById(id);
                    ConsoleResult.Result(resultId);
                    break;

                case "2":
                    Console.WriteLine("Insert the title:");
                    var title = Console.ReadLine(); 
                    var resultTitle = _service.GetBookByTitle(title);
                    ConsoleResult.Result(resultTitle);
                    break;

                case "3":
                    Console.WriteLine("Insert the author:");
                    var author = Console.ReadLine();
                    var resultAuthor = _service.GetBooksByAuthor(author);
                    ConsoleResult.Result(resultAuthor);
                    break;

                case "4":
                    Console.WriteLine("Insert the year:");
                    var year = Console.ReadLine();
                    var resultYear = _service.GetBooksByYear(year);
                    ConsoleResult.Result(resultYear);
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        public void ShowBooks()
        {
            Console.WriteLine("Select an option below:");
            Console.WriteLine("1 - List only active books");
            Console.WriteLine("2 - List all registred books");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _result = _service.GetAllActiveBooks();
                    _books = _result.Data as List<Book>;
                    ShowAllActiveBooks(_books);
                    break;
                case "2":
                    _result = _service.GetAllBooks();
                    _books = _result.Data as List<Book>;
                    ShowAllBooks(_books);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        public void RemoveBook()
        {
            Console.WriteLine("Insert the book ID:");
            Guid.TryParse(Console.ReadLine(), out Guid id);

            _result = _service.RemoveBook(id);
            ConsoleResult.Result(_result);
        }
       
        #endregion


        #region Private Methods

        private void ShowBook(Book book)
        {
            Console.WriteLine("ID = " + book.Id);
            Console.WriteLine("Title = " + book.Title);
            Console.WriteLine("Author = " + book.Author);
            Console.WriteLine("Year = " + book.Year);
            Console.WriteLine("ISBN = " + book.ISBN);
        }

        private void ShowAllBooks(List<Book> books)
        {
            if (books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID = " + book.Id);
                    Console.WriteLine("Title = " + book.Title);
                    Console.WriteLine("Author = " + book.Author);
                    Console.WriteLine("ISBN = " + book.ISBN);
                }
            }
            else
                Console.WriteLine("There are no books registered!");
        }

        private void ShowAllActiveBooks(List<Book> books)
        {
            books = books.Where(b => b.Active == true).ToList();
            if (books.Any())
            {
                foreach (var book in books)
                {
                    ShowBook(book);
                }
            }
            else
                Console.WriteLine("There are no books registered!");
        }

        #endregion
    }
}
