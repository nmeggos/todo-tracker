using TodoTracker.Shared.Registrations;

namespace TodoTracker.API;

public class ApiAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(ApiAssemblyReference).Namespace!;
}