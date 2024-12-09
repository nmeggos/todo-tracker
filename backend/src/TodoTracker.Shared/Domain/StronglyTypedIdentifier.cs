namespace TodoTracker.Shared.Domain;

public abstract record StronglyTypedId<T> 
    where T : notnull
{
    public T Value { get; }

    protected StronglyTypedId(T value)
    {
        if (value == null || value.Equals(default(T)))
        {
            throw new ArgumentNullException(nameof(value));
        }
        Value = value;
    }

    public override string ToString() => Value.ToString()!;

    public static implicit operator T(StronglyTypedId<T> id) => id.Value;

    public static explicit operator StronglyTypedId<T>(T value) => (StronglyTypedId<T>)Activator.CreateInstance(typeof(StronglyTypedId<T>), value)!;
}