namespace Resumenizer.Core.Abstractions;

public interface ILanguage
{
    byte Id { get; }
    string Code { get; }
    string NativeName { get; }
}