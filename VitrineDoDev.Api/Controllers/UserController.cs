using Microsoft.AspNetCore.Mvc;
using VitrineDoDev.Domain.Account.Commands;
using VitrineDoDev.Domain.Account.Handlers;
using VitrineDoDev.Domain.GenericCommand;

namespace VitrineDoDev.Api.Controllers
{

    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("register")]
        public GenericCommandResult Register(
            [FromServices] UserHandler handler,
            [FromBody] RegisterUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [HttpPost]
        [Route("authenticate")]
        public GenericCommandResult Authenticate(
           [FromServices] UserHandler handler,
           [FromBody] AuthenticateUserCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }





    }
}
