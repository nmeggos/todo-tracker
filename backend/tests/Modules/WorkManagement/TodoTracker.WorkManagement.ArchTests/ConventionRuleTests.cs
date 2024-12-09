﻿using TodoTracker.Shared.Domain.Events;

namespace TodoTracker.WorkManagement.ArchTests;

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
}