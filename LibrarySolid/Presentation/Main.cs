using LibrarySolid.Interfaces.Presentations;

namespace LibrarySolid.Presentation
{
    public class Main
    {
        public readonly IBookPresentation _bookPresentation;
        public readonly ILoanPresentation _loanPresentation;
        public readonly IUserPresentation _userPresentation;
        public Main(IBookPresentation bookPresentation, ILoanPresentation loanPresentation, IUserPresentation userPresentation)
        {
            _bookPresentation = bookPresentation;
            _loanPresentation = loanPresentation;
            _userPresentation = userPresentation;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the library management system!");
            while (true)
            {
                MainMenu();
                var option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1":
                        _bookPresentation.BookRegister();
                        break;

                    case "2":
                        _bookPresentation.ConsultBook();
                        break;

                    case "3":
                        _bookPresentation.ShowBooks();
                        break;

                    case "4":
                        _bookPresentation.RemoveBook();
                        break;

                    case "5":
                        _userPresentation.UserRegister();
                        break;

                    case "6":
                        _loanPresentation.LoanRegister();
                        break;

                    case "7":
                        _loanPresentation.LoanReturn();
                        break;

                    case "8":
                        return;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option, try again!");
                        break;
                }

            }
        }

        private void MainMenu()
        {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Select an option below:");
                Console.WriteLine("1 - Register a book");
                Console.WriteLine("2 - Consult a book");
                Console.WriteLine("3 - Consult all books");
                Console.WriteLine("4 - Removing a book");
                Console.WriteLine("5 - Register a user");
                Console.WriteLine("6 - Register a loan");
                Console.WriteLine("7 - Return a book");
                Console.WriteLine("8 - Leave");
        }

    }
}
