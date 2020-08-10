using System.Collections.Generic;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Developer.Entities
{
    public class Developer : Entity
    {

        public string Description { get; private set; }
        public string ActualPosition { get; private set; }
        public bool HasJob { get; private set; }
        public List<Technology> Technologies { get; private set; }
        public SocialMedia SocialMedia { get; private set; }

    }
}
