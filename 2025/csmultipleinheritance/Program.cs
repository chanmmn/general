using System;

// 1. First Base Class (Interface - equivalent to a pure abstract class in C++)
public interface IWorker
{
    void Work();
    string GetJobTitle();
}

// 2. Second Base Class (Interface)
public interface IEater
{
    void Eat();
    string GetFavoriteFood();
}

// 3. A concrete class that can be inherited from
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hello, I'm {Name} and I'm {Age} years old.");
    }
}

// 4. The derived class: INHERITS from one class, IMPLEMENTS multiple interfaces
public class Robot : Person, IWorker, IEater // Only one class, but multiple interfaces
{
    public string Model { get; set; }
    
    // Implement IWorker interface
    public void Work()
    {
        Console.WriteLine($"{Name} ({Model}) is working efficiently.");
    }

    public string GetJobTitle()
    {
        return "Automated Assistant";
    }
    
    // Implement IEater interface (though a robot doesn't really eat!)
    public void Eat()
    {
        Console.WriteLine($"{Name} is consuming electricity.");
    }

    public string GetFavoriteFood()
    {
        return "Lithium-ion batteries";
    }
    
    // Constructor must call the base class constructor
    public Robot(string name, int age, string model) : base(name, age)
    {
        Model = model;
    }
}

class Program
{
    static void Main()
    {
        Robot myRobot = new Robot("R2-D2", 5, "Astro-Mechanical");
        
        // Methods from the base class Person
        myRobot.Introduce();
        
        // Methods from the IWorker interface
        myRobot.Work();
        Console.WriteLine($"Job: {myRobot.GetJobTitle()}");
        
        // Methods from the IEater interface
        myRobot.Eat();
        Console.WriteLine($"Favorite Food: {myRobot.GetFavoriteFood()}");
        
        Console.WriteLine("\n--- Using Interface References ---");
        
        // Polymorphism: Treat the Robot as an IWorker
        IWorker worker = myRobot;
        worker.Work(); // Calls Robot's implementation
        
        // Polymorphism: Treat the Robot as an IEater
        IEater eater = myRobot;
        eater.Eat(); // Calls Robot's implementation
        
        // Both references point to the same object
        Console.WriteLine($"Same object? {worker == eater}"); // True
    }
}