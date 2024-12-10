using TodoTracker.Shared;

namespace TodoTracker.API;

public class ApiAssemblyReference : AssemblyReferenceBase
{
    public override string Name => typeof(ApiAssemblyReference).Namespace!;
}