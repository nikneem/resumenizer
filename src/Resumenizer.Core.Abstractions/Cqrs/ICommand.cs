namespace Resumenizer.Core.Features;

public interface ICommand
{
    Guid CommandId { get; }
}