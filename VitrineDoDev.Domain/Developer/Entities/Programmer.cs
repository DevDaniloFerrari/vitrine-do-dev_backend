using System.Collections.Generic;
using VitrineDoDev.Domain.Social.Entities;
using VitrineDoDev.Domain.Technologies.Entities;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Developer.Entities
{
    public class Programmer : Entity
    {
        public Programmer() { }

        public Programmer(string description, string actualPosition, bool hasJob, List<Technology> technologies, SocialMedia socialMedia)
        {
            Description = description;
            ActualPosition = actualPosition;
            HasJob = hasJob;
            Technologies = technologies;
            SocialMedia = socialMedia;
        }

        public string Photo { get; private set; }
        public string Description { get; private set; }
        public string ActualPosition { get; private set; }
        public bool HasJob { get; private set; }
        public List<Technology> Technologies { get; private set; }
        public SocialMedia SocialMedia { get; private set; }

    }
}
