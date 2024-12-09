using TodoTracker.Shared.Registrations;

namespace TodoTracker.Infrastructure;

public class InfrastructureAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(InfrastructureAssemblyReference).Namespace!;
}