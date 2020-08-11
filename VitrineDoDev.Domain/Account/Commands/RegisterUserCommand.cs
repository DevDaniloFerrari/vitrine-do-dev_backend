﻿using Flunt.Notifications;
using Flunt.Validations;
using VitrineDoDev.Shared.Commands;

namespace VitrineDoDev.Domain.Account.Commands
{
    public class RegisterUserCommand : Notifiable, ICommand
    {
        public RegisterUserCommand(string name, string email, string cellPhone, string password)
        {
            Name = name;
            Email = email;
            CellPhone = cellPhone;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Email, "Email", "E-mail inválido"));
        }
    }
}
