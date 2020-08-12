using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Technologies.Entities
{
    public class Technology : Entity
    {
        public Technology() { }
        public Technology(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Programmer Programmer { get; private set; }
    }
}

