using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoTracker.Shared.Domain;

namespace TodoTracker.Shared.Infrastructure.Persistence;

public class StronglyTypedIdValueConverter<TId, TValue> : ValueConverter<TId, TValue>
    where TId : StronglyTypedId<TValue>
    where TValue : notnull
{
    public StronglyTypedIdValueConverter(
        Func<TValue, TId> toId,
        Func<TId, TValue> fromId) 
        : base(id => id.Value, value => toId(value)) { }
}