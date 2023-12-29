using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Interfaces.Services;
using LibrarySolid.Models;
using LibrarySolid.Utils;
using System.Net;

namespace LibrarySolid.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _repository { get; set; }
        private LibraryResult libraryResult { get; set; } = new LibraryResult((int)HttpStatusCode.InternalServerError, string.Empty, null);

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public ILibraryResult GetUserById(Guid id)
        {
            var user = _repository.GetById(id);

            if (user != null)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "User found successfully!";
                libraryResult.Data = user;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Loan not found!";
                libraryResult.Data = user;
                return libraryResult;
            }
        }

        public ILibraryResult GetAllUsers()
        {
            var users = _repository.GetAll();

            if (users.Any())
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "Users found successfully!";
                libraryResult.Data = users;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "None user found!";
                libraryResult.Data = users;
                return libraryResult;
            }
        }

        public ILibraryResult AddUser(User user)
        {
            var isAdded = _repository.Add(user);

            if (isAdded)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "User added successfully!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Error when trying to add a new user!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
        }

        public ILibraryResult UpdateUser(User user)
        {
            var isAdded = _repository.Update(user);

            if (isAdded)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "User updated successfully!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Error when trying to update a user!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
        }

        public ILibraryResult RemoveUser(Guid id)
        {
            var user = _repository.GetById(id);

            if (user == null)
            {
                libraryResult.Status = (int)HttpStatusCode.NotFound;
                libraryResult.Message = "User not found!";
                libraryResult.Data = user;
                return libraryResult;
            }

            var isAdded = _repository.Delete(id);

            if (isAdded)
            {
                libraryResult.Status = (int)HttpStatusCode.OK;
                libraryResult.Message = "User removed successfully!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
            else
            {
                libraryResult.Status = (int)HttpStatusCode.NoContent;
                libraryResult.Message = "Error when trying to remove a user!";
                libraryResult.Data = isAdded;
                return libraryResult;
            }
        }

    }
}
