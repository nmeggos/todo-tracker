using TodoTracker.Shared.Registrations;

namespace TodoTracker.WorkManagement.Infrastructure;

public class InfrastructureAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(InfrastructureAssemblyReference).Namespace!;
}