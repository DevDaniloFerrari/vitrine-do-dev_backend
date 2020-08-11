using VitrineDoDev.Domain.Account.Entities;

namespace VitrineDoDev.Domain.Account.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
