using HexMaster.DomainDrivenDesign.Abstractions;
using Resumenizer.Core.Languages;

namespace Resumenizer.Skills.Abstractions.DomainModels;

public interface ISkill : IDomainModel<Guid>
{
    Guid? CategoryId { get; }
    string Key { get; }
    IReadOnlyList<Translation> Translations { get; }
    string Description { get; }
    DateTimeOffset ActiveFrom { get; }
    DateTimeOffset? ActiveUntil { get; }

    void SetCategory(ISkillCategory value);

    void AddTranslation(Translation value);
    void RemoveTranslation(string value);
    void UpdateTranslation(Translation value);

    void SetDescription(string value);
    void SetActiveFrom(DateTimeOffset value);
    void SetActiveUntil(DateTimeOffset? value);
}