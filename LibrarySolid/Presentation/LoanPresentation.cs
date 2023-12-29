using LibrarySolid.Interfaces.Services;
using LibrarySolid.Interfaces;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;
using LibrarySolid.Interfaces.Presentations;

namespace LibrarySolid.Presentation
{
    public class LoanPresentation : ILoanPresentation
    {
        private readonly ILoanService _service;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private ILibraryResult _result = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);
        private List<Book> _books = new List<Book>();

        public LoanPresentation(ILoanService service, IUserService userService, IBookService bookService)
        {
            _service = service;
            _userService = userService;
            _bookService = bookService;
        }

        public void LoanRegister()
        {
            Console.WriteLine("Insert the book ID: ");
            Guid.TryParse(Console.ReadLine(), out Guid bookId);
            var book = _bookService.GetBookById(bookId);

            if(book == null)
                _result = new LibraryResult((int)HttpStatusCode.NotFound, "Book not found", null);

            Console.WriteLine("Insert the userId: ");
            Guid.TryParse(Console.ReadLine(), out Guid userId);
            var user = _userService.GetUserById(userId);

            if(user == null)
                _result = new LibraryResult((int)HttpStatusCode.NotFound, "User not found", null);

            var loan = new Loan(userId, bookId, DateTimeOffset.Now);
            loan.Active = true;

            _result = _service.AddLoan(loan);
            ConsoleResult.Result(_result);
        }

        public void LoanReturn()
        {
            Console.WriteLine("Insert the book ID: ");
            Guid.TryParse(Console.ReadLine(), out Guid bookId);

            _result = _service.ReturnLoan(bookId);
            ConsoleResult.Result( _result);
        }
    }
}
