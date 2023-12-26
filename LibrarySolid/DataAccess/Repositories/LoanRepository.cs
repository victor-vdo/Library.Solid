using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySolid.DataAccess.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly IDataContext _context;
        public LoanRepository(IDataContext context)
        {
            _context = context;
        }

        public void Add(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var loan = _context.Loans.FirstOrDefault(u => u.Id == id);

            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }

        public Loan GetById(Guid id)
        {
            var loan = _context.Loans.FirstOrDefault(u => u.Id == id);
            return loan;
        }

        public List<Loan> GetAll()
        {
            var loans = _context.Loans.AsNoTracking();
            return loans.ToList();
        }

        public List<Loan> GetAllActive()
        {
            var loans = _context.Loans.Where(w => w.Active == true).AsNoTracking();
            return loans.ToList();
        }

        public List<Loan> GetAllDisabled()
        {
            var loans = _context.Loans.Where(w => w.Active == false).AsNoTracking();
            return loans.ToList();
        }
        
        public void Update(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }
    }
}
