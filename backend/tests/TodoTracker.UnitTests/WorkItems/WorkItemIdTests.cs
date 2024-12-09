using FluentAssertions;
using TodoTracker.Domain.WorkManagement;

namespace TodoTracker.UnitTests.WorkItems;

public class WorkItemIdTests
{
    [Fact]
    public void New_Should_Create_New_WorkItemId()
    {
        // Arrange
        
        // Act
        var workItemId = WorkItemId.New;
        
        // Assert
        workItemId.Should().NotBeNull();
        workItemId.Value.GetType().Should().Be(typeof(Guid));
    }
    
    [Fact]
    public void From_Should_Create_WorkItemId_From_Guid()
    {
        // Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var workItemId = WorkItemId.From(guid);
        
        // Assert
        workItemId.Should().NotBeNull();
        workItemId.Value.Should().Be(guid);
    }
    
    [Fact]
    public void From_Should_Throw_Exception_When_Guid_Is_Empty()
    {
        // Arrange
        var guid = Guid.Empty;
        
        // Act & Assert
        Action act = () => WorkItemId.From(guid);
        act.Should().Throw<ArgumentException>();
    }
}