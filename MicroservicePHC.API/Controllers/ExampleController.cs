using MediatR;
using MicroservicePHC.Application.Common.Models;
using MicroservicePHC.Application.EntityExample.Commands.CreateEntityExampleCommand;
using MicroservicePHC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;

namespace MicroservicePHC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {

        private readonly ILogger<ExampleController> _logger;
        private readonly IMediator _bus;

        public ExampleController(ILogger<ExampleController> logger, IMediator bus)
        {
            /* Dependency injection example */
            _logger = logger;
            _bus = bus;
        }

        [HttpPost(Name = "Example get")]
        public async Task<Result<EntityExample>> Create(CreateEntityExampleCommand command)
        {
            return await _bus.Send(command);
        }
    }
}
