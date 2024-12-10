using System.Reflection;

namespace TodoTracker.Shared;

public interface IAssemblyReference
{
    string Name { get; }
    Assembly Assembly { get; }
}