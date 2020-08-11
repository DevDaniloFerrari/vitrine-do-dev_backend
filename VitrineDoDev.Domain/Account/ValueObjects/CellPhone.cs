using Flunt.Validations;
using VitrineDoDev.Shared.ValueObjects;

namespace VitrineDoDev.Domain.Account.ValueObjects
{
    public class CellPhone : ValueObject
    {
        public CellPhone(string number)
        {
            Number = number;

            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Number, 8,"CellPhone.number", "E-mail inválido"));
        }

        public string Number { get; private set; }
    }
}
