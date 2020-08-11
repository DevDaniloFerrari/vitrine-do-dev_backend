using Microsoft.EntityFrameworkCore;
using System.Linq;
using VitrineDoDev.Domain.Account.Entities;
using VitrineDoDev.Domain.Account.Queries;
using VitrineDoDev.Domain.Account.Repositories;
using VitrineDoDev.Infra.Contexts;

namespace VitrineDoDev.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string email)
        {
            return _context.User.FirstOrDefault(UserQueries.EmailExists(email));
        }

        public bool EmailExists(string email)
        {
            return _context.User.AsNoTracking().Any(UserQueries.EmailExists(email));
        }

        public void Register(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }
    }
}
