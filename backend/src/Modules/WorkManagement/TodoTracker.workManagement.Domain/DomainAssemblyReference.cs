using TodoTracker.Shared.Registrations;

namespace TodoTracker.workManagement.Domain;

public class DomainAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(DomainAssemblyReference).Namespace!;
}