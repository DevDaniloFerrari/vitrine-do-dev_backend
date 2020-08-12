using VitrineDoDev.Domain.Developer.Entities;

namespace VitrineDoDev.Domain.Developer.Repositories
{
    public interface IProgrammerRepository
    {
        void Create(Programmer programmer);
    }
}
