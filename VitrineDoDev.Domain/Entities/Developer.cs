using System.Collections.Generic;

namespace VitrineDoDev.Domain.Entities
{
    public class Developer : User
    {
        public Developer()
        {
        }


        public string Description { get; private set; }
        public string ActualPosition { get; private set; }
        public bool HasJob { get; private set; }
        public List<Technology> Technologies { get; private set; }
        public SocialMedia SocialMedia { get; private set; }

    }
}
