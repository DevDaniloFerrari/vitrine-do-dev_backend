using System;
using System.Linq.Expressions;
using VitrineDoDev.Domain.Account.Entities;

namespace VitrineDoDev.Domain.Account.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> EmailExists(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<User, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

    }
}
