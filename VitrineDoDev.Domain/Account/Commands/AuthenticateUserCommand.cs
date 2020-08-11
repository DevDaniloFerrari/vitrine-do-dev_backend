using Flunt.Notifications;
using Flunt.Validations;
using VitrineDoDev.Shared.Commands;

namespace VitrineDoDev.Domain.Account.Commands
{
    public class AuthenticateUserCommand : Notifiable, ICommand
    {
        public AuthenticateUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
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
