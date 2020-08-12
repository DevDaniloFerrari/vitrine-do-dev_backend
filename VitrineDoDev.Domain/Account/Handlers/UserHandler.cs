using Flunt.Notifications;
using VitrineDoDev.Domain.Account.Commands;
using VitrineDoDev.Domain.Account.Entities;
using VitrineDoDev.Domain.Account.Repositories;
using VitrineDoDev.Domain.Account.Services;
using VitrineDoDev.Domain.Account.ValueObjects;
using VitrineDoDev.Domain.GenericCommand;
using VitrineDoDev.Shared.Commands;
using VitrineDoDev.Shared.Handlers;

namespace VitrineDoDev.Domain.Account.Handlers
{
    public class UserHandler : Notifiable, IHandler<RegisterUserCommand>, IHandler<AuthenticateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public ICommandResult Handle(RegisterUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro com os dados", command.Notifications);

            // Verificar se o E-mail já existe
            if (_userRepository.EmailExists(command.Email))
                return new GenericCommandResult(false, "E-mail já cadastrado", command.Email);

            // Gerar o VO's
            var password = new Password(command.Password);
            var email = new Email(command.Email);

            // Agrupar validações
            AddNotifications(password, email);

            // Checar notificações
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro com os dados", Notifications);

            // Gerar as senhas criptografadas
            password.CreatePasswordHash(command.Password);

            // Gerar a entidade
            var user = new User(command.Name, email, password);

            // Salvar no banco
            _userRepository.Register(user);

            // Retornar informações
            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", user);
        }

        public ICommandResult Handle(AuthenticateUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro com os dados", command.Notifications);

            // Recuperar o usuário
            var user = _userRepository.Authenticate(command.Email);

            // Verificar se o usuário existe
            if (user == null)
                return new GenericCommandResult(false, "Usuário não existe", command.Email);

            // Verificar a senha criptografada
            var password = Password.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt);

            // Verificar se as senhas são iguais
            if (!password)
                return new GenericCommandResult(false, "Senha incorreta", Notifications);

            // Gerar o Token
            var token = _tokenService.GenerateToken(user);

            // Retornar informações
            return new GenericCommandResult(true, "Usuário autenticado com sucesso", token);
        }
    }
}
