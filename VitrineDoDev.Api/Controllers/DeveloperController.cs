using Microsoft.AspNetCore.Mvc;
using VitrineDoDev.Domain.Developer.Commands;
using VitrineDoDev.Domain.Developer.Handlers;
using VitrineDoDev.Domain.GenericCommand;

namespace VitrineDoDev.Api.Controllers
{
    [ApiController]
    [Route("v1/developers")]
    public class DeveloperController : Controller
    {

        [HttpPost]
        [Route("profile")]
        public GenericCommandResult CreateDeveloperProfile(
            [FromServices] ProgrammerHandler handler,
            [FromBody] CreateDeveloperProfileCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
