using Flunt.Notifications;
using VitrineDoDev.Domain.Account.Repositories;
using VitrineDoDev.Domain.Account.ValueObjects;
using VitrineDoDev.Domain.Developer.Commands;
using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Domain.Developer.Repositories;
using VitrineDoDev.Domain.GenericCommand;
using VitrineDoDev.Domain.Social.Repositories;
using VitrineDoDev.Domain.Technologies.Entities;
using VitrineDoDev.Domain.Technologies.Repositories;
using VitrineDoDev.Shared.Commands;
using VitrineDoDev.Shared.Handlers;

namespace VitrineDoDev.Domain.Developer.Handlers
{
    public class ProgrammerHandler : Notifiable, IHandler<CreateDeveloperProfileCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProgrammerRepository _programmerRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;

        public ProgrammerHandler(IUserRepository userRepository, IProgrammerRepository programmerRepository, ITechnologyRepository technologyRepository, ISocialMediaRepository socialMediaRepository)
        {
            _userRepository = userRepository;
            _programmerRepository = programmerRepository;
            _technologyRepository = technologyRepository;
            _socialMediaRepository = socialMediaRepository;
        }

        public ICommandResult Handle(CreateDeveloperProfileCommand command)
        {
            // Fail Fast Validation 
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro com os dados", command.Notifications);

            // Recuperar o usuário
            var user = _userRepository.GetById(command.User);

            // Verificar se o usuário existe
            if (user == null)
                return new GenericCommandResult(false, "Usuário não existe", command.User);

            // Gerar o VO
            var cellPhone = new CellPhone(command.CellPhone);

            // Adicionar o telefone
            user.AddCelPhone(cellPhone);

            // Gerar o perfil do desenvolvedor
            var programmer = new Programmer(command.Photo, command.Description, command.ActualPosition, command.HasJob, command.CompanyName);

            // Adicionar as redes sociais
            programmer.AddSocialMedia(command.GitHub, command.Linkedln, command.Portfolio);

            // Adicionar as tecnologias
            foreach(var technology in command.Technologies)
            {
                programmer.AddTechnology(technology);
            }

            // Salvar o telefone do usuário no banco
            _userRepository.Update(user);

            // Salvar as redes sociais no banco
            _socialMediaRepository.Create(programmer.SocialMedia);

            // Salvar as tecnologias no banco
            foreach (var technology in programmer.Technologies)
            {
                _technologyRepository.Create(technology);
            }

            // Salvar o desenvolvedor no banco
            _programmerRepository.Create(programmer);
            
            // Retornar informações
            return new GenericCommandResult(true, "Desenvolvedor cadastrado com sucesso", programmer);
        }
    }
}
