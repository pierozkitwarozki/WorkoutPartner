namespace WorkoutPartner.Test;

public class WeightWorkoutConverterTests
{
    [Theory]
    [InlineData("1x10", 1, "10")]
    [InlineData("100x10", 100, "10")]
    [InlineData("100x200", 100, "200")]
    [InlineData("100xM", 100, "M")]
    [InlineData("100xm", 100, "m")]
    public void ConvertWithoutWeight_ShouldBeValid(string schema, int sets, string reps)
    {
        // Arrange
        
        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().NotBeNull();
        foreach (var workout in response)
        {
            workout?.Sets.Should().Be(sets);
            workout?.Reps.Should().Be(reps);
            workout?.Weight.Should().BeNull();
            workout?.Unit.Should().BeNull();
        }
    }
    
    [Theory]
    [InlineData("1", "1")]
    [InlineData("100", "100")]
    [InlineData("200", "200")]
    [InlineData("M", "M")]
    public void ConvertWithoutSets_ShouldBeValid(string schema, string reps)
    {
        // Arrange
        
        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().NotBeNull();
        foreach (var workout in response)
        {
            workout?.Sets.Should().Be(1);
            workout?.Reps.Should().Be(reps);
            workout?.Weight.Should().BeNull();
            workout?.Unit.Should().BeNull();
        }
    }
    
    [Theory]
    [InlineData("10#40kg", "10", 40, "kg")]
    [InlineData("10#9999kg", "10", 9999, "kg")]
    [InlineData("100#9999lbs", "100", 9999, "lbs")]
    [InlineData("999#1kg", "999", 1, "kg")]
    public void ConvertWithoutSetsWithWeight_ShouldBeValid(
        string schema, string reps, int weight, string unit)
    {
        // Arrange

        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().NotBeNull();
        foreach (var workout in response)
        {
            workout?.Sets.Should().Be(1);
            workout?.Reps.Should().Be(reps);
            workout?.Weight.Should().Be(weight);
            workout?.Unit.Should().Be(unit);
        }
    }
    
    [Theory]
    [InlineData("1x10#40kg", 1, "10", 40, "kg")]
    [InlineData("10x999#400lbs", 10, "999", 400, "lbs")]
    public void ConvertWithSetsAndWeight_ShouldBeValid(string schema, int sets, string reps, int weight, string unit)
    {
        // Arrange

        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().NotBeNull();
        foreach (var workout in response)
        {
            workout?.Sets.Should().Be(sets);
            workout?.Reps.Should().Be(reps);
            workout?.Weight.Should().Be(weight);
            workout?.Unit.Should().Be(unit);
        }
    }
    
    [Fact]
    public void ConvertWithMultipleSetsAndWeight_ShouldBeValid()
    {
        // Arrange
        const string schema = "1x10#40kg,2x10#50kg,8#90kg,10,M#100lbs";
        WeightWorkout[] expectedWorkouts =
        [
            new WeightWorkout(1, "10", 40, "kg"),
            new WeightWorkout(2, "10", 50, "kg"),
            new WeightWorkout(1, "8", 90, "kg"),
            new WeightWorkout(1, "10", null, null),
            new WeightWorkout(1, "M", 100, "lbs"),
        ];
        
        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().NotBeNull();
        var i = 0;
        foreach (var workout in response)
        {
            workout?.Sets.Should().Be(expectedWorkouts[i].Sets);
            workout?.Reps.Should().Be(expectedWorkouts[i].Reps);
            workout?.Weight.Should().Be(expectedWorkouts[i].Weight);
            workout?.Unit.Should().Be(expectedWorkouts[i].Unit);
            i++;
        }
    }
    
    [Theory]
    [InlineData("-1x10#40kg")]
    [InlineData("test#random")]
    [InlineData("-8")]
    [InlineData("x")]
    public void ConvertWithInvalidSchema_ShouldBeInvalid(string schema)
    {
        // Arrange

        // Act
        var response = 
            WeightWorkoutConverter.Convert(schema)
                .ToImmutableArray();

        // Assert
        response.Should().BeEmpty();
    }
}