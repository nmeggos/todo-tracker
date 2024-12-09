using TodoTracker.Shared.Registrations;

namespace TodoTracker.WorkManagement.API;

public class ApiAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(ApiAssemblyReference).Namespace!;
}