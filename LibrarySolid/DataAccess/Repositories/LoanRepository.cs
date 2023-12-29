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

        public bool Add(Loan loan)
        {
            loan.Active = true;
            loan.ReturnDate = DateTimeOffset.MinValue;

            using (var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                //var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable);
                _context.Loans.Add(loan);
                var isAdded = _context.SaveChanges();
                transaction.Commit();

                if (isAdded > 0)
                    return true;
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(Guid id)
        {
            var loan = _context.Loans.FirstOrDefault(u => u.Id == id);

            if (loan != null)
            {
                using(var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    // Soft delete
                    loan.Active = false;
                    _context.Loans.Update(loan);
                    var isDeleted = _context.SaveChanges();
                    transaction.Commit();

                    if (isDeleted > 0)
                        return true;
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return false;
        }

        public bool DeleteByBookId(Guid bookId)
        {
            var loan = _context.Loans.FirstOrDefault(u => u.BookId == bookId);

            if (loan != null)
            {
                using(var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    // Soft delete
                    loan.Active = false;
                    loan.ReturnDate = DateTimeOffset.Now;
                    _context.Loans.Update(loan);
                    var isDeleted = _context.SaveChanges();
                    transaction.Commit();

                    if (isDeleted > 0)
                        return true;
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return false;
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
        
        public bool Update(Loan loan)
        {
            using (var transaction = _context.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                _context.Loans.Update(loan);
                var isUpdated = _context.SaveChanges();
                transaction.Commit();

                if (isUpdated > 0)
                    return true;
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public Loan GetByBookId(Guid bookId)
        {
            var loan = _context.Loans.FirstOrDefault(w => w.BookId == bookId);
            return loan;
        }

        public List<Loan> GetByUserId(Guid userId)
        {
            var loan = _context.Loans.Where(w => w.UserId == userId).AsNoTracking();
            return loan.ToList();
        }
    }
}
