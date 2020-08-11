using VitrineDoDev.Domain.Account.ValueObjects;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Account.Entities
{
    public class User : Entity
    {
        public User() { }
        

        public User(string name, Email email, CellPhone cellPhone, Password password)
        {
            Name = name;
            Email = email.Address;
            CellPhone = cellPhone.Number;
            PasswordHash = password.PasswordHash;
            PasswordSalt = password.PasswordSalt;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }


    }
}
