using VitrineDoDev.Domain.Social.Entities;

namespace VitrineDoDev.Domain.Social.Repositories
{
    public interface ISocialMediaRepository
    {
        void Create(SocialMedia socialMedia);
    }
}