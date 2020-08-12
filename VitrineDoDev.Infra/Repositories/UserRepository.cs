using Microsoft.EntityFrameworkCore;
using System;
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
            return _context.User.AsNoTracking().FirstOrDefault(UserQueries.EmailExists(email));
        }

        public bool EmailExists(string email)
        {
            return _context.User.AsNoTracking().Any(UserQueries.EmailExists(email));
        }

        public User GetById(Guid id)
        {
            return _context.User.AsNoTracking().FirstOrDefault(UserQueries.GetById(id));
        }

        public void Register(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
