using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Presentation
{
    public class BookPresentation
    {
        private readonly IBookService _service;
        private ILibraryResult _result = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);
        private List<Book> _books = new List<Book>();

        public BookPresentation(IBookService service)
        {
            _service = service;
        }

        public void ShowBooks()
        {
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.WriteLine("1 - Listar os livros ativos");
            Console.WriteLine("2 - Listar todos os livros cadastrados");
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

        private void ShowBook(Book book)
        {
            Console.WriteLine("ID = " + book.Id);
            Console.WriteLine("Título = " + book.Title);
            Console.WriteLine("Autor = " + book.Author);
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
                    Console.WriteLine("Título = " + book.Title);
                    Console.WriteLine("Autor = " + book.Author);
                    Console.WriteLine("ISBN = " + book.ISBN);
                }
            }
            else
                Console.WriteLine("Não existem livros cadastrados!");
        }

        private void ShowAllActiveBooks(List<Book> books)
        {
            books = books.Where(b => b.Active == true).ToList();
            if (books.Any())
            {
                foreach (var book in books)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID = " + book.Id);
                    Console.WriteLine("Título = " + book.Title);
                    Console.WriteLine("Autor = " + book.Author);
                    Console.WriteLine("ISBN = " + book.ISBN);
                }
            }
            else
                Console.WriteLine("Não existem livros cadastrados!");
        }

        private void ShowBookReturn(Book book, List<Book> books, List<Loan> loans)
        {
            Console.WriteLine("Insira o ID do livro:");
            var idBook = Console.ReadLine() ?? String.Empty;

            var id = Guid.TryParse(idBook, out Guid bookResult) ? bookResult : Guid.Empty;
            var result = _service.GetBookById(id);

            if (book is null)
                Console.WriteLine("Livro não encontrado na base!");

            //var isReturned = _service.BookReturn(book, loans);

            //if (isReturned)
            //    Console.WriteLine("Livro devolvido com sucesso!");
            //else
            //    Console.WriteLine("Houve um erro ao tentar devolver o livro!");
        }

    }
}
