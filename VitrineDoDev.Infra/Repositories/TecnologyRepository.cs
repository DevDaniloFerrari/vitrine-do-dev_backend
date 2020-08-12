using VitrineDoDev.Domain.Technologies.Entities;
using VitrineDoDev.Domain.Technologies.Repositories;
using VitrineDoDev.Infra.Contexts;

namespace VitrineDoDev.Infra.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly DataContext _context;

        public TechnologyRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Technology techonology)
        {
            _context.Technology.Add(techonology);
            _context.SaveChanges();
        }
    }
}
