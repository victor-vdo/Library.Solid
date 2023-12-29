using LibrarySolid.Interfaces.Presentations;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Interfaces;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Presentation
{
    public class UserPresentation : IUserPresentation
    {
        private readonly IUserService _service;
        private ILibraryResult _result = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);
        private List<Book> _books = new List<Book>();

        public UserPresentation(IUserService service)
        {
            _service = service;
        }

        public void UserRegister()
        {
            var user = new User(string.Empty, string.Empty);
            Console.WriteLine("Insert the name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Insert the email: ");
            var email = Console.ReadLine();

            user.Name = name;
            user.Email = email;

            _result = _service.AddUser(user);
            ConsoleResult.Result(_result);
        }

    }
}
