// Open-Closed Principle (OCP) Demonstration
// OCP: Software entities should be open for extension but closed for modification

using System;
using System.Collections.Generic;

namespace OpenClosedPrincipleDemo
{
    // BAD Example - Violates OCP
    // Adding new shapes requires modifying existing code
    public class BadAreaCalculator
    {
        public double CalculateArea(object shape)
        {
            if (shape is BadRectangle rectangle)
            {
                return rectangle.Width * rectangle.Height;
            }
            else if (shape is BadCircle circle)
            {
                return Math.PI * circle.Radius * circle.Radius;
            }
            // Adding a new shape would require modifying this method!
            return 0;
        }
    }

    public class BadRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class BadCircle
    {
        public double Radius { get; set; }
    }

    // GOOD Example - Follows OCP
    // New shapes can be added without modifying existing code
    
    // Abstract base class - defines the contract
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Concrete implementations
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // New shape can be added without modifying existing code!
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }

    // This class is closed for modification but open for extension
    public class AreaCalculator
    {
        public double CalculateTotalArea(List<Shape> shapes)
        {
            double totalArea = 0;
            foreach (var shape in shapes)
            {
                totalArea += shape.CalculateArea();
            }
            return totalArea;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Open-Closed Principle Demonstration ===\n");

            // Create various shapes
            var shapes = new List<Shape>
            {
                new Rectangle(5, 10),
                new Circle(7),
                new Triangle(6, 8)
            };

            // Calculate total area
            var calculator = new AreaCalculator();
            double totalArea = calculator.CalculateTotalArea(shapes);

            Console.WriteLine("Individual Shape Areas:");
            Console.WriteLine($"Rectangle (5 x 10): {shapes[0].CalculateArea():F2}");
            Console.WriteLine($"Circle (radius 7): {shapes[1].CalculateArea():F2}");
            Console.WriteLine($"Triangle (base 6, height 8): {shapes[2].CalculateArea():F2}");
            Console.WriteLine($"\nTotal Area of All Shapes: {totalArea:F2}");

            Console.WriteLine("\n=== Key Benefits ===");
            Console.WriteLine("1. New shapes can be added without modifying AreaCalculator");
            Console.WriteLine("2. Existing code is stable and tested");
            Console.WriteLine("3. Follows polymorphism - each shape knows how to calculate its own area");
            Console.WriteLine("4. Easier to maintain and extend");
        }
    }
}
