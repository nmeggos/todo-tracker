using System.Reflection;

namespace TodoTracker.Shared.Registrations;

public interface IAssemblyReference
{
    string Name { get; }
    Assembly Assembly { get; }
}