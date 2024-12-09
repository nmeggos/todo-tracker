using System.Reflection;

namespace TodoTracker.Shared.Registrations;

public abstract class AssemblyReferenceBase : IAssemblyReference
{
    public abstract string Name { get; }
    public Assembly Assembly => GetType().Assembly;
}