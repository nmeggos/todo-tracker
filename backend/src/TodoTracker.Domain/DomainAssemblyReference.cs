using TodoTracker.Shared;

namespace TodoTracker.Domain;

public class DomainAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(DomainAssemblyReference).Namespace!;
}