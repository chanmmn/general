// Liskov Substitution Principle (LSP) Demo
// LSP states: Objects of a derived class should be able to replace objects 
// of the base class without breaking the application's correctness.

using System;

namespace LiskovSubstitutionPrinciple
{
    // ============================================
    // BAD EXAMPLE - Violates LSP
    // ============================================
    
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying");
        }
    }

    // This violates LSP because Penguin cannot fly, but inherits from Bird
    class Penguin : Bird
    {
        public override void Fly()
        {
            throw new NotSupportedException("Penguins cannot fly!");
        }
    }

    // ============================================
    // GOOD EXAMPLE - Follows LSP
    // ============================================
    
    abstract class Animal
    {
        public abstract void Move();
    }

    class FlyingBird : Animal
    {
        public override void Move()
        {
            Fly();
        }

        public virtual void Fly()
        {
            Console.WriteLine("Flying bird is flying");
        }
    }

    class Eagle : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Eagle is soaring high");
        }
    }

    class Dove : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Dove is flying gracefully");
        }
    }

    class FlightlessBird : Animal
    {
        public override void Move()
        {
            Walk();
        }

        public virtual void Walk()
        {
            Console.WriteLine("Flightless bird is walking");
        }
    }

    class GoodPenguin : FlightlessBird
    {
        public override void Walk()
        {
            Console.WriteLine("Penguin is waddling");
        }
    }

    class Ostrich : FlightlessBird
    {
        public override void Walk()
        {
            Console.WriteLine("Ostrich is running fast");
        }
    }

    // ============================================
    // Another practical example with Rectangles
    // ============================================

    // BAD: Violates LSP
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : Rectangle
    {
        private int _side;

        public override int Width
        {
            get => _side;
            set { _side = value; }
        }

        public override int Height
        {
            get => _side;
            set { _side = value; }
        }
    }

    // GOOD: Follows LSP
    interface IShape
    {
        int GetArea();
    }

    class GoodRectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class GoodSquare : IShape
    {
        public int Side { get; set; }

        public int GetArea()
        {
            return Side * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LISKOV SUBSTITUTION PRINCIPLE DEMONSTRATION ===\n");

            // BAD EXAMPLE - LSP Violation
            Console.WriteLine("--- BAD Example (Violates LSP) ---");
            try
            {
                Bird bird1 = new Sparrow();
                bird1.Fly(); // Works fine

                Bird bird2 = new Penguin();
                bird2.Fly(); // Throws exception - LSP violation!
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.WriteLine("This violates LSP - substitution broke the application!\n");
            }

            // GOOD EXAMPLE - LSP Followed
            Console.WriteLine("--- GOOD Example (Follows LSP) ---");
            Animal[] animals = new Animal[]
            {
                new Eagle(),
                new Dove(),
                new GoodPenguin(),
                new Ostrich()
            };

            foreach (var animal in animals)
            {
                animal.Move(); // All work correctly - LSP satisfied!
            }

            Console.WriteLine();

            // Rectangle/Square Example
            Console.WriteLine("--- Rectangle/Square Example ---");
            
            // BAD: Violates LSP
            Console.WriteLine("BAD (Violates LSP):");
            Rectangle rect = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine($"Rectangle area: {rect.GetArea()}"); // 50

            Rectangle sq = new Square();
            sq.Width = 5;
            sq.Height = 10; // This overwrites width too!
            Console.WriteLine($"Square area: {sq.GetArea()}"); // 100 (unexpected!)
            Console.WriteLine("Substituting Square for Rectangle gives unexpected results!\n");

            // GOOD: Follows LSP
            Console.WriteLine("GOOD (Follows LSP):");
            IShape shape1 = new GoodRectangle { Width = 5, Height = 10 };
            Console.WriteLine($"Rectangle area: {shape1.GetArea()}"); // 50

            IShape shape2 = new GoodSquare { Side = 5 };
            Console.WriteLine($"Square area: {shape2.GetArea()}"); // 25
            Console.WriteLine("Both shapes work correctly with the interface!");

            Console.WriteLine("\n=== KEY TAKEAWAY ===");
            Console.WriteLine("LSP ensures that derived classes extend base classes without");
            Console.WriteLine("changing their behavior in ways that violate expectations.");
            Console.WriteLine("Subtypes must be substitutable for their base types!");
        }
    }
}
