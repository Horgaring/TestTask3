using System;
using Xunit;

namespace GeometryLibrary.Tests;

public class ShapeTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(2)]
    public void circle_should_calculate_area(double radius)
    {
        // Arrange
        var circle = new Circle(radius);
        double expectedArea = Math.PI * radius * radius;

        // Act
        double actualArea = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }

    [Fact]
    public void circle_with_negative_radius_should_throws_argument_exception()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Circle(-5));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(4, 5, 6)]
    [InlineData(5, 6, 7)]
    public void triangle_should_calculate_area(double sideA, double sideB, double sideC)
    {
        // Arrange
        var triangle = new Triangle(sideA, sideB, sideC);
        double expectedArea = Math.Sqrt(
            (sideA + sideB + sideC) * 
            (sideA + sideB - sideC) * 
            (sideA - sideB + sideC) * 
            (-sideA + sideB + sideC)) / 4; 

        // Act
        double actualArea = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }

    [Fact]
    public void triangle_with_invalid_sides_should_throws_argument_exception()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
    }

    [Fact]
    public void triangle_is_right_angled_should_returns_true_for_right_triangle()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);

        // Act & Assert
        Assert.True(triangle.IsRightAngled());
    }

    [Fact]
    public void triangle_is_right_angled_should_returns_false_for_non_right_triangle()
    {
        // Arrange
        var triangle = new Triangle(2, 3, 4);

        // Act & Assert
        Assert.False(triangle.IsRightAngled());
    }
}
