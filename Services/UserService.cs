using Backend_Web.Models;

namespace Backend_Web.Services
{
    public class UserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void Create(User model)
        {
            // validate
            if (_context.Users.Any(x => x.UserName == model.UserName))
                throw new Exception("User with the name '" + model.UserName + "' already exists");
            User user = new User();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Avatar = model.Avatar;
            user.CreatedDate = DateTime.Now;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, User model)
        {
            var user = GetUserById(id);
            user.UserName = model.UserName;
            //user.Email = model.Email;
            user.Password = model.Password;
            user.Avatar = model.Avatar;
            user.CreatedDate = DateTime.Now;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        
    }
}
