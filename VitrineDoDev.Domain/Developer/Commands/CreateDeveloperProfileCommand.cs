using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using VitrineDoDev.Shared.Commands;

namespace VitrineDoDev.Domain.Developer.Commands
{
    public class CreateDeveloperProfileCommand : Notifiable, ICommand
    {
        public CreateDeveloperProfileCommand(string cellPhone, string photo, string description, string actualPosition, bool hasJob, string companyName, string gitHub, string linkedln, string portfólio, List<string> technologies)
        {
            CellPhone = cellPhone;
            Photo = photo;
            Description = description;
            ActualPosition = actualPosition;
            HasJob = hasJob;
            CompanyName = companyName;
            GitHub = gitHub;
            Linkedln = linkedln;
            Portfólio = portfólio;
            Technologies = technologies;
        }

        public string CellPhone { get; private set; }
        public string Photo { get; private set; }
        public string Description { get; private set; }
        public string ActualPosition { get; private set; }
        public bool HasJob { get; private set; }
        public string CompanyName { get; private set; }
        public string GitHub { get; private set; }
        public string Linkedln { get; private set; }
        public string Portfólio { get; private set; }
        public List<string> Technologies { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Description, 30, "Description", "No máximo 30 caracteres"));
        }
    }
}
