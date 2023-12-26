using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Services
{
    public class BookService
    {
        public IBookRepository _repository { get; set; }
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public ILibraryResult GetAllBooks()
        {
            var books = _repository.GetAll();

            if(books != null)
                return new LibraryResult((int)HttpStatusCode.OK, "Livros encontrados!", books);
            else
                return new LibraryResult((int)HttpStatusCode.NoContent, "Nenhum livro encontrado na base!", books);
        }
    }
}
