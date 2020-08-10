﻿using VitrineDoDev.Domain.Account.Entities;

namespace VitrineDoDev.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(string user);
        void Register(User user);
        bool EmailExists(string email);
    }
}