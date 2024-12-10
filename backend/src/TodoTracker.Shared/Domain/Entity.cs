﻿using Ardalis.GuardClauses;

namespace TodoTracker.Shared.Domain;

public abstract class Entity<TId> 
{
    protected Entity()
    {
    }
    
    protected Entity(TId id)
    {
        Id = Guard.Against.Null(id, nameof(id));
    }
    
    public TId Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
        {
            return false;
        }
        
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        
        return Id.Equals(other.Id);
    }
    
    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);
    
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !(left == right);
}