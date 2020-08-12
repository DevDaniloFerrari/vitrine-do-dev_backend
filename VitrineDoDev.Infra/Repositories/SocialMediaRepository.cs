using VitrineDoDev.Domain.Social.Entities;
using VitrineDoDev.Domain.Social.Repositories;
using VitrineDoDev.Infra.Contexts;

namespace VitrineDoDev.Infra.Repositories
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly DataContext _context;

        public SocialMediaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(SocialMedia socialMedia)
        {
            _context.SocialMedia.Add(socialMedia);
            _context.SaveChanges();
        }
    }
}
