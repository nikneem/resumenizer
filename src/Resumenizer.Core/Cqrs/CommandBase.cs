
using Resumenizer.Core.Features;

namespace Resumenizer.Core.Cqrs;

public record CommandBase : ICommand
{
    public Guid CommandId { get; init; } = Guid.NewGuid();
}