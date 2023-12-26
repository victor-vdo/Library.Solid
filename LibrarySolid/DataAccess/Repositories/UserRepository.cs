using LibrarySolid.Interfaces;
using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;

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

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                // Soft delete
                user.Active = false;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
