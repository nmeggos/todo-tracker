using FluentAssertions;
using NetArchTest.Rules;
using TodoTracker.WorkManagement.Application;
using TodoTracker.workManagement.Domain;
using TodoTracker.WorkManagement.Infrastructure;

namespace TodoTracker.WorkManagement.ArchTests;

public class ProjectReferenceTests
{
    private readonly ApplicationAssemblyReference _applicationAssemblyReference;
    private readonly DomainAssemblyReference _domainAssemblyReference;
    private readonly InfrastructureAssemblyReference _infrastructureAssemblyReference;

    public ProjectReferenceTests()
    {
        _applicationAssemblyReference = new ApplicationAssemblyReference();
        _domainAssemblyReference = new DomainAssemblyReference();
        _infrastructureAssemblyReference = new InfrastructureAssemblyReference();
    }
    
    [Fact]
    public void DomainLayer_Should_NotHaveDependenciesOnDefinedProjectLayers()
    {
        // Arrange
        var assemblies = new[] { _applicationAssemblyReference.Name, _infrastructureAssemblyReference.Name };
        
        // Act
        var result = Types.InAssembly(_domainAssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOnAll(assemblies)
            .GetResult();
        
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_Should_NotHaveDependenciesOnDefinedProjectLayers()
    {
        // Arrange
        var assemblies = new[] { _infrastructureAssemblyReference.Name };
        
        // Act
        var result = Types.InAssembly(_applicationAssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOnAll(assemblies)
            .GetResult();
        
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureLayer_Should_NotHaveDependenciesOnDefinedProjectLayers()
    {
        // Arrange
        var assemblies = new[] { _applicationAssemblyReference.Name };
        
        // Act
        var result = Types.InAssembly(_infrastructureAssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOnAll(assemblies)
            .GetResult();
        
        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}