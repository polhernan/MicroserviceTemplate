using MediatR;
using MicroservicePHC.Application.Common.Models;
using MicroservicePHC.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Text.Json;

namespace MicroservicePHC.Application.EntityExample.Commands.CreateEntityExampleCommand
{
    public class CreateEntityExampleCommandHandler : IRequestHandler<CreateEntityExampleCommand, Common.Models.Result<Domain.Entities.EntityExample>>
    {


        private readonly ILogger<CreateEntityExampleCommandHandler> _logger;
        private readonly MicroservicePHCDbContext _context;

        public CreateEntityExampleCommandHandler(ILogger<CreateEntityExampleCommandHandler> logger, MicroservicePHCDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public async Task<Result<Domain.Entities.EntityExample>> Handle(CreateEntityExampleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return Result<Domain.Entities.EntityExample>.Failure("Empty Name");

            Domain.Entities.EntityExample entity = new Domain.Entities.EntityExample()
            {
                Name = request.Name,
            };

            _context.EntityExamples.Add(entity);

            await _context.SaveChangesAsync();

            _logger.LogInformation($"EntityExample Created: {request.Name}");

            return Result<Domain.Entities.EntityExample>.Success(entity);
        }
    }
}
