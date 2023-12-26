using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Loan GetById(Guid id);
        List<Loan> GetAll();
        List<Loan> GetAllActive();
        List<Loan> GetAllDisabled();
        void Add(Loan loan);
        void Update(Loan loan);
        void Delete(Guid id);
    }
}
