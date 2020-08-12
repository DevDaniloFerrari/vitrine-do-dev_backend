using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Social.Entities
{
    public class SocialMedia : Entity
    {
        public SocialMedia() { }
        public SocialMedia(string gitHub, string linkedln, string portfolio)
        {
            GitHub = gitHub;
            Linkedln = linkedln;
            Portfolio = portfolio;
        }

        public string GitHub { get; private set; }
        public string Linkedln { get; private set; }
        public string Portfolio { get; private set; }
        public Programmer Programmer { get; private set; }
    }
}
