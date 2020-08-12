using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Shared.Entities;

namespace VitrineDoDev.Domain.Social.Entities
{
    public class SocialMedia : Entity
    {
        public SocialMedia() { }
        public SocialMedia(string gitHub, string linkedln, string portfólio)
        {
            GitHub = gitHub;
            Linkedln = linkedln;
            Portfólio = portfólio;
        }

        public string GitHub { get; private set; }
        public string Linkedln { get; private set; }
        public string Portfólio { get; private set; }
        public Programmer Programmer { get; private set; }
    }
}
