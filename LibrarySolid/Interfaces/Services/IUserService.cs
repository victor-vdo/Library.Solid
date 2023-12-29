using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Services
{
    public interface IUserService
    {
        ILibraryResult GetUserById(Guid id);
        ILibraryResult GetAllUsers();
        ILibraryResult AddUser(User user);
        ILibraryResult UpdateUser(User user);
        ILibraryResult RemoveUser(Guid id);
    }
}
