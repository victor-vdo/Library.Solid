using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Services
{
    public interface ILoanService
    {
        ILibraryResult GetLoanById(Guid id);
        ILibraryResult GetLoanByBookId(Guid bookId);
        ILibraryResult GetLoansByUserId(Guid userId);
        ILibraryResult AddLoan(Loan loan);
        ILibraryResult ReturnLoan(Guid bookId);
    }
}
