using Ardalis.GuardClauses;

namespace TodoTracker.Shared.Domain.ValueObjects;

public record PersonName
{
    private PersonName()
    {
    }
    
    private PersonName(string firstName, string lastName)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public static PersonName New(string firstName, string lastName)
    {
        return new PersonName(firstName, lastName);
    }
    
    public static PersonName From(string firstName, string lastName)
    {
        return new PersonName(firstName, lastName);
    }
    
    public static PersonName From(PersonName personName)
    {
        return new PersonName(personName.FirstName, personName.LastName);
    }
    
    public override string ToString()
    {
        return FullName;
    }
}