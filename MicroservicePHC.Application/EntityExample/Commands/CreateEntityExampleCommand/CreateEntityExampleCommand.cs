using MediatR;
using MicroservicePHC.Application.Common.Interfaces;

namespace MicroservicePHC.Application.EntityExample.Commands.CreateEntityExampleCommand
{
    public class CreateEntityExampleCommand : ICommand<Common.Models.Result<Domain.Entities.EntityExample>>
    {
        public string Name { get; init; }
        public string Surname { get; }

        public CreateEntityExampleCommand(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
