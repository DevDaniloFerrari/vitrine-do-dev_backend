using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Domain.Developer.Repositories;
using VitrineDoDev.Infra.Contexts;

namespace VitrineDoDev.Infra.Repositories
{
    public class ProgrammerRepository : IProgrammerRepository
    {
        private readonly DataContext _context;

        public ProgrammerRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Programmer programmer)
        {
            _context.Programmer.Add(programmer);
            _context.SaveChanges();
        }
    }
}
