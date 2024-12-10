using System.Reflection;

namespace TodoTracker.Shared;

public abstract class AssemblyReferenceBase : IAssemblyReference
{
    public abstract string Name { get; }
    public Assembly Assembly => GetType().Assembly;
}