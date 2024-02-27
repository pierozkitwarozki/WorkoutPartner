using NetArchTest.Rules;
using WorkoutPartner.Application.Services;
using WorkoutPartner.Infrastructure.Services;

namespace WorkoutPartner.Test.Architecture;

public class ArchitectureTests
{
    [Fact]
    public void DomainAssembly_ShouldNotDependOnAny()
    {
        // Arrange

        // Act
        var result = Types.InAssembly(typeof(WeightWorkoutSet).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "WorkoutPartner.Application",
                "WorkoutPartner.Infrastructure",
                "WorkoutPartner.API")
            .GetResult();

        // Assert
        result?.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationAssembly()
    {
        // Arrange

        // Act
        var result = Types.InAssembly(typeof(IDateTimeService).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "WorkoutPartner.API",
                "WorkoutPartner.Infrastructure")
            .GetResult();

        // Assert
        result?.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureAssembly()
    {
        // Arrange

        // Act
        var result = Types.InAssembly(typeof(DateTimeService).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "WorkoutPartner.API")
            .GetResult();

        // Assert
        result?.IsSuccessful.Should().BeTrue();
    }
}