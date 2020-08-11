using Flunt.Validations;
using VitrineDoDev.Shared.ValueObjects;

namespace VitrineDoDev.Domain.Account.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Address, "Email.address", "E-mail inválido"));
        }

        public string Address { get; private set; }
    }
}
