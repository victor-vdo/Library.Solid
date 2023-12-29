using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;
using System.Data;

namespace LibrarySolid.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;
        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public User GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public List<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public bool Add(User user)
        {
            using(var transaction = _context.BeginTransaction(IsolationLevel.Serializable))
            {
                _context.Users.Add(user);
                var isAdded = _context.SaveChanges();
                transaction.Commit();

                if (isAdded > 0)
                    return true;
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                using (var transaction = _context.BeginTransaction(IsolationLevel.Serializable))
                {
                    // Soft delete
                    user.Active = false;
                    _context.Users.Update(user);
                    var isUpdated = _context.SaveChanges();
                    transaction.Commit();

                    if (isUpdated > 0)
                        return true;
                    return false;
                }
            }
            return false;
        }

        public bool Update(User user)
        {
            using (var transaction = _context.BeginTransaction(IsolationLevel.Serializable))
            {
                _context.Users.Update(user);
                var isDeleted = _context.SaveChanges();
                transaction.Commit();

                if (isDeleted > 0)
                    return true;
                return false;
            }
        }
    }
}
