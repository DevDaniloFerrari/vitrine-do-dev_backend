using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using VitrineDoDev.Shared.Commands;

namespace VitrineDoDev.Domain.Developer.Commands
{
    public class CreateDeveloperProfileCommand : Notifiable, ICommand
    {
        public CreateDeveloperProfileCommand(string cellPhone, string photo, string description, string actualPosition, bool hasJob, string companyName, string gitHub, string linkedln, string portfolio, List<string> technologies, Guid user)
        {
            CellPhone = cellPhone;
            Photo = photo;
            Description = description;
            ActualPosition = actualPosition;
            HasJob = hasJob;
            CompanyName = companyName;
            GitHub = gitHub;
            Linkedln = linkedln;
            Portfolio = portfolio;
            Technologies = technologies;
            User = user;
        }

        public string CellPhone { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string ActualPosition { get; set; }
        public bool HasJob { get; set; }
        public string CompanyName { get; set; }
        public string GitHub { get; set; }
        public string Linkedln { get; set; }
        public string Portfolio { get; set; }
        public List<string> Technologies { get; set; }
        public Guid User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Description, 30, "Description", "No máximo 30 caracteres"));
        }
    }
}
