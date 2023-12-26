using LibrarySolid.Interfaces.Repositories;
using LibrarySolid.Models;

namespace LibrarySolid.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
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
                _context.Users.Remove(user);
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
