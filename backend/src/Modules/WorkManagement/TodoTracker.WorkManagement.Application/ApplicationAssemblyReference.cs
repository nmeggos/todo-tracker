using TodoTracker.Shared.Registrations;

namespace TodoTracker.WorkManagement.Application;

public class ApplicationAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(ApplicationAssemblyReference).Namespace!;
}