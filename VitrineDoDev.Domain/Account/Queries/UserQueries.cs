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

    }
}
