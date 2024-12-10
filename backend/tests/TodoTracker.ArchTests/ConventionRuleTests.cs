using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.CQRS.Queries;

namespace TodoTracker.ArchTests;

public class ConventionRuleTests
{
    [Fact]
    public void DomainEvents_ShouldHave_DomainEventSuffix()
    {
        var result = Types
            .InAssembly(new DomainAssemblyReference().Assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent<>))
            .Or()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Command_ShouldHave_CommandSuffix()
    {
        var result = Types
            .InAssembly(new ApplicationAssemblyReference().Assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void CommandHandler_ShouldHave_CommandHandlerSuffix()
    {
        var result = Types
            .InAssembly(new ApplicationAssemblyReference().Assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Query_ShouldHave_QuerySuffix()
    {
        var result = Types
            .InAssembly(new ApplicationAssemblyReference().Assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void QueryHandler_ShouldHave_QueryHandlerSuffix()
    {
        var result = Types
            .InAssembly(new ApplicationAssemblyReference().Assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
}