using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Services
{
    public class LoanService : ILoanService
    {
        public ILoanRepository _repository { get; set; }
        private LibraryResult libraryResult { get; set; } = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);

        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public ILibraryResult GetLoanById(Guid id)
        {
            var loan = _repository.GetById(id);

            if (loan != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Loan found successfully!";
                libraryResult.Data = loan;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Loan not found!";
                libraryResult.Data = loan;
                return libraryResult;
            }
        }

        public ILibraryResult GetLoanByBookId(Guid bookId)
        {
            var loan = _repository.GetByBookId(bookId);

            if (loan != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Loan found successfully!";
                libraryResult.Data = loan;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Loan not found!";
                libraryResult.Data = loan;
                return libraryResult;
            }
        }

        public ILibraryResult GetLoansByUserId(Guid userId)
        {
            var loans = _repository.GetByUserId(userId);

            if (loans.Any())
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Loans found successfully!";
                libraryResult.Data = loans;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "None loan found!";
                libraryResult.Data = loans;
                return libraryResult;
            }
        }

        public ILibraryResult AddLoan(Loan loan)
        {
            loan.LoanDate = DateTimeOffset.Now;
            var isAdded = _repository.Add(loan);

            if (isAdded)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Loan added successfully!";
                libraryResult.Data = loan;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Error when trying to add a new loan!";
                libraryResult.Data = loan;
                return libraryResult;
            }
        }

        public ILibraryResult ReturnLoan(Guid bookId)
        {
            var isRemoved = _repository.DeleteByBookId(bookId);

            if (isRemoved)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Loan removed successfully!";
                libraryResult.Data = isRemoved;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.BadRequest;
                libraryResult.Message = "Error when trying to remove the loan!";
                libraryResult.Data = isRemoved;
                return libraryResult;
            }
        }
    }
}
