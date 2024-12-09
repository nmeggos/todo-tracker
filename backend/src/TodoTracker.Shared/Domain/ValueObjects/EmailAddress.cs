using Ardalis.GuardClauses;
using TodoTracker.Shared.Guards;

namespace TodoTracker.Shared.Domain.ValueObjects;

public record EmailAddress
{
    public string Value { get; private set; }

    public static EmailAddress Create(string value)
    {
        return new EmailAddress
        {
            Value = Guard.Against.InvalidEmail(value)
        };
    }

    public void Deconstruct(out string value)
    {
        value = Value;
    }
}