using System;
using System.Linq;

namespace GeometryLibrary;

public class Triangle : IShape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("All sides must be positive");

        if (!IsValidTriangle(sideA, sideB, sideC))
            throw new ArgumentException("Invalid triangle: sum of any two sides must be greater than the third side");

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double CalculateArea()
    {
        // Using Heron's formula
        double s = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
    }

    public bool IsRightAngled()
    {
        double[] sides = new[] { _sideA, _sideB, _sideC };
        Array.Sort(sides);
        
        const double epsilon = 1e-10;
        return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < epsilon;
    }

    private static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && b + c > a && a + c > b;
    }
}
