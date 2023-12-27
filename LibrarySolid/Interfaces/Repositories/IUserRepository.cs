using LibrarySolid.Models;

namespace LibrarySolid.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        List<User> GetAll();
        bool Add(User user);
        bool Update(User user);
        bool Delete(Guid id);
    }
}