using FluentAssertions;
using TodoTracker.Domain.WorkManagement;

namespace TodoTracker.UnitTests.WorkItems;

public class WorkItemTests
{
    [Fact]
    public void WhenCreating_WithValidValues_ShouldCreate()
    {
        // Arrange
        var title = "Test WorkItem";
        var description = "Test Description";
        var dueDate = DateTime.UtcNow.AddDays(1);

        // Act
        var workItem = WorkItem.Create(title, description, dueDate);

        // Assert
        workItem.Should().NotBeNull();
        workItem.Title.Should().Be(title);
        workItem.Description.Should().Be(description);
        workItem.DueDate.UtcDateTime.Should().Be(dueDate);
        workItem.Status.Should().Be(Status.New);
        workItem.CreatedBy.Should().Be("System");
        workItem.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    }

    [Fact]
    public void WhenCreating_WithNoDescription_ShouldCreate()
    {
        // Arrange
        var title = "Test WorkItem";
        var dueDate = DateTime.UtcNow.AddDays(1);

        // Act
        var workItem = WorkItem.Create(title, null, dueDate);

        // Assert
        workItem.Should().NotBeNull();
        workItem.Title.Should().Be(title);
        workItem.Description.Should().BeEmpty();
        workItem.DueDate.UtcDateTime.Should().Be(dueDate);
        workItem.Status.Should().Be(Status.New);
        workItem.CreatedBy.Should().Be("System");
        workItem.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    }

    [Fact]
    public void WhenCreating_WithNoTitle_ShouldThrowException()
    {
        // Arrange
        var description = "Test Description";
        var dueDate = DateTime.UtcNow.AddDays(1);

        // Act & Assert
        Action act = () => WorkItem.Create(string.Empty, description, dueDate);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void WhenCreating_WithInvalidDueDate_ShouldThrowException()
    {
        // Arrange
        var title = "Test WorkItem";
        var description = "Test Description";

        // Act & Assert
        Action act = () => WorkItem.Create(title, description, default);
        act.Should().Throw<ArgumentException>();
    }
}