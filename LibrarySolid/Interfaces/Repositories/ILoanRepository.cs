using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Loan GetById(Guid id);
        Loan GetByBookId(Guid bookId);
        List<Loan> GetByUserId(Guid userId);
        List<Loan> GetAll();
        List<Loan> GetAllActive();
        List<Loan> GetAllDisabled();
        bool Add(Loan loan);
        bool Update(Loan loan);
        bool Delete(Guid id);
        bool DeleteByBookId(Guid bookId);
    }
}
