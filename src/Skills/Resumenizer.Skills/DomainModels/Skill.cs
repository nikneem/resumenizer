using HexMaster.DomainDrivenDesign;
using HexMaster.DomainDrivenDesign.ChangeTracking;
using Resumenizer.Core.Languages;
using Resumenizer.Skills.Abstractions.DomainModels;

namespace Resumenizer.Skills.DomainModels;

public class Skill : DomainModel<Guid>, ISkill
{

    private readonly List<Translation> _translations;

    public Guid? CategoryId { get; private set; }
    public string Key { get; }
    public IReadOnlyList<Translation> Translations => _translations.AsReadOnly();
    public string Description { get; private set; }
    public DateTimeOffset ActiveFrom { get; private set; }
    public DateTimeOffset? ActiveUntil { get; private set; }
    
    public void SetCategory(ISkillCategory value)
    {
        CategoryId = value.Id;
    }

    public void AddTranslation(Translation value)
    {
        if (_translations.Any(t => t.LanguageCode == value.LanguageCode))
        {
            AddValidationError("A translation in this language already exists");
        }

        if (string.IsNullOrWhiteSpace(value.TranslationText))
        {
            AddValidationError("Translation text cannot be empty");
        }

        _translations.Add(value);
        SetState(TrackingState.Modified);
    }

    public void RemoveTranslation(string value)
    {
        var translation = _translations.FirstOrDefault(t => t.LanguageCode == value);
        if (translation != null)
        {
            _translations.Remove(translation);
            SetState(TrackingState.Modified);
        }
    }

    public void UpdateTranslation(Translation value)
    {
        var existingTranslation = _translations.FirstOrDefault(t => t.LanguageCode == value.LanguageCode);
        if (existingTranslation != null)
        {
            _translations.Remove(existingTranslation);
        }

        AddTranslation(value);
    }

    public void SetDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            AddValidationError("The description for a skill cannot be null or empty, that would be user unfriendly");
        }

        if (!Equals(Description, value))
        {
            Description = value;
            SetState(TrackingState.Modified);
        }
    }

    public void SetActiveFrom(DateTimeOffset value)
    {
        if (!Equals(ActiveFrom, value))
        {
            ActiveFrom = value;
            SetState(TrackingState.Modified);
        }
    }

    public void SetActiveUntil(DateTimeOffset? value)
    {
        if (!Equals(ActiveUntil, value))
        {
            ActiveUntil = value;
            SetState(TrackingState.Modified);
        }
    }

    public Skill(Guid id, string key, Guid? category, List<Translation> translations, string description,
        DateTimeOffset activeFrom, DateTimeOffset? activeUntil) : base(id)
    {
        Key = key;
        CategoryId = category;
        Description = description;
        ActiveFrom = activeFrom;
        ActiveUntil = activeUntil;
        _translations = translations;
    }

    public Skill(string key, List<Translation> translations, string? description = null,
        DateTimeOffset? activeFrom = null, DateTimeOffset? activeUntil = null) : base(Guid.NewGuid(), TrackingState.New)
    {
        Key = key;
        Description = description ?? key;
        _translations = translations;
        ActiveFrom = activeFrom ?? DateTimeOffset.UtcNow;
        ActiveUntil = activeUntil;
    }
}
