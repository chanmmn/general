using System;

namespace InterfaceSegregationPrinciple
{
    // ========================================
    // BAD EXAMPLE - Violating ISP
    // ========================================
    // This interface forces all workers to implement methods they might not need
    public interface IWorkerBad
    {
        void Work();
        void Eat();
        void Sleep();
    }

    public class HumanWorkerBad : IWorkerBad
    {
        public void Work()
        {
            Console.WriteLine("Human is working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating...");
        }

        public void Sleep()
        {
            Console.WriteLine("Human is sleeping...");
        }
    }

    public class RobotWorkerBad : IWorkerBad
    {
        public void Work()
        {
            Console.WriteLine("Robot is working...");
        }

        public void Eat()
        {
            // Problem: Robot doesn't eat, but forced to implement this method
            throw new NotImplementedException("Robots don't eat!");
        }

        public void Sleep()
        {
            // Problem: Robot doesn't sleep, but forced to implement this method
            throw new NotImplementedException("Robots don't sleep!");
        }
    }

    // ========================================
    // GOOD EXAMPLE - Following ISP
    // ========================================
    // Split the interface into smaller, more specific interfaces
    public interface IWorkable
    {
        void Work();
    }

    public interface IFeedable
    {
        void Eat();
    }

    public interface ISleepable
    {
        void Sleep();
    }

    // Human implements all interfaces as it needs all functionalities
    public class HumanWorker : IWorkable, IFeedable, ISleepable
    {
        public void Work()
        {
            Console.WriteLine("Human is working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating...");
        }

        public void Sleep()
        {
            Console.WriteLine("Human is sleeping...");
        }
    }

    // Robot only implements what it needs - no forced methods
    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working...");
        }
    }

    // Another example: A part-time worker who doesn't sleep at work
    public class PartTimeWorker : IWorkable, IFeedable
    {
        public void Work()
        {
            Console.WriteLine("Part-time worker is working...");
        }

        public void Eat()
        {
            Console.WriteLine("Part-time worker is eating lunch...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Interface Segregation Principle Demo ===\n");

            Console.WriteLine("--- BAD EXAMPLE (Violating ISP) ---");
            try
            {
                IWorkerBad robotBad = new RobotWorkerBad();
                robotBad.Work();
                robotBad.Eat(); // This will throw an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- GOOD EXAMPLE (Following ISP) ---");
            
            Console.WriteLine("\nHuman Worker:");
            HumanWorker human = new HumanWorker();
            human.Work();
            human.Eat();
            human.Sleep();

            Console.WriteLine("\nRobot Worker:");
            RobotWorker robot = new RobotWorker();
            robot.Work();
            // Robot only has Work() method - no unnecessary methods!

            Console.WriteLine("\nPart-Time Worker:");
            PartTimeWorker partTime = new PartTimeWorker();
            partTime.Work();
            partTime.Eat();
            // Part-time worker doesn't have Sleep() - perfectly fine!

            Console.WriteLine("\n=== Key Takeaway ===");
            Console.WriteLine("Interface Segregation Principle: Clients should not be forced");
            Console.WriteLine("to depend on interfaces they do not use. Split large interfaces");
            Console.WriteLine("into smaller, more specific ones.");
        }
    }
}
