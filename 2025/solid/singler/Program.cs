using System;
using System.Collections.Generic;
using System.IO;

// ============================================================
// BAD EXAMPLE: Violating Single Responsibility Principle
// ============================================================
// This class has multiple responsibilities:
// 1. Managing user data
// 2. Validating user data
// 3. Saving user data to a file
// 4. Sending email notifications

class UserManagerBad
{
    public string Name { get; set; }
    public string Email { get; set; }

    public UserManagerBad(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // Responsibility 1: Validation
    public bool ValidateEmail()
    {
        return Email.Contains("@") && Email.Contains(".");
    }

    // Responsibility 2: Data Persistence
    public void SaveToFile(string filePath)
    {
        File.WriteAllText(filePath, $"{Name},{Email}");
        Console.WriteLine($"Saved user {Name} to file");
    }

    // Responsibility 3: Email Notification
    public void SendWelcomeEmail()
    {
        Console.WriteLine($"Sending welcome email to {Email}");
        // Email sending logic here
    }
}

// ============================================================
// GOOD EXAMPLE: Following Single Responsibility Principle
// ============================================================
// Each class has a single, well-defined responsibility

// Responsibility 1: Representing user data
class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public override string ToString()
    {
        return $"User: {Name} ({Email})";
    }
}

// Responsibility 2: Validating user data
class UserValidator
{
    public bool IsValid(User user)
    {
        return !string.IsNullOrWhiteSpace(user.Name) && IsValidEmail(user.Email);
    }

    public bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && 
               email.Contains("@") && 
               email.Contains(".");
    }

    public List<string> GetValidationErrors(User user)
    {
        var errors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(user.Name))
            errors.Add("Name is required");
        
        if (!IsValidEmail(user.Email))
            errors.Add("Invalid email format");
        
        return errors;
    }
}

// Responsibility 3: Persisting user data
class UserRepository
{
    private readonly string _filePath;

    public UserRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(User user)
    {
        try
        {
            var content = $"{user.Name},{user.Email}";
            File.AppendAllText(_filePath, content + Environment.NewLine);
            Console.WriteLine($"✓ User '{user.Name}' saved to database");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Failed to save user: {ex.Message}");
        }
    }

    public List<User> LoadAll()
    {
        var users = new List<User>();
        
        if (!File.Exists(_filePath))
            return users;

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                users.Add(new User(parts[0], parts[1]));
            }
        }
        
        return users;
    }
}

// Responsibility 4: Sending email notifications
class EmailService
{
    public void SendWelcomeEmail(User user)
    {
        Console.WriteLine($"✓ Welcome email sent to {user.Email}");
        // In a real application, this would send an actual email
        Console.WriteLine($"  Subject: Welcome {user.Name}!");
        Console.WriteLine($"  Body: Thank you for joining us.");
    }

    public void SendNotification(User user, string message)
    {
        Console.WriteLine($"✓ Notification sent to {user.Email}: {message}");
    }
}

// Orchestrator class that uses all the single-responsibility classes
class UserService
{
    private readonly UserValidator _validator;
    private readonly UserRepository _repository;
    private readonly EmailService _emailService;

    public UserService(UserValidator validator, UserRepository repository, EmailService emailService)
    {
        _validator = validator;
        _repository = repository;
        _emailService = emailService;
    }

    public bool RegisterUser(User user)
    {
        Console.WriteLine($"\nRegistering user: {user}");
        
        // Validate
        if (!_validator.IsValid(user))
        {
            Console.WriteLine("✗ Validation failed:");
            var errors = _validator.GetValidationErrors(user);
            foreach (var error in errors)
            {
                Console.WriteLine($"  - {error}");
            }
            return false;
        }
        
        // Save
        _repository.Save(user);
        
        // Notify
        _emailService.SendWelcomeEmail(user);
        
        return true;
    }
}

// ============================================================
// DEMONSTRATION
// ============================================================
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("SINGLE RESPONSIBILITY PRINCIPLE DEMONSTRATION");
        Console.WriteLine("=".PadRight(60, '='));
        
        Console.WriteLine("\n--- BAD EXAMPLE: Multiple Responsibilities ---");
        var badUser = new UserManagerBad("John Doe", "john@example.com");
        if (badUser.ValidateEmail())
        {
            badUser.SaveToFile("bad_users.txt");
            badUser.SendWelcomeEmail();
        }
        Console.WriteLine("⚠ Problem: UserManagerBad class does too many things!");
        Console.WriteLine("  - Hard to test individual features");
        Console.WriteLine("  - Changes to one feature affect others");
        Console.WriteLine("  - Difficult to maintain and extend");
        
        Console.WriteLine("\n--- GOOD EXAMPLE: Single Responsibilities ---");
        
        // Create instances with single responsibilities
        var validator = new UserValidator();
        var repository = new UserRepository("users.txt");
        var emailService = new EmailService();
        var userService = new UserService(validator, repository, emailService);
        
        // Test with valid user
        var user1 = new User("Alice Smith", "alice@example.com");
        userService.RegisterUser(user1);
        
        // Test with another valid user
        var user2 = new User("Bob Johnson", "bob@company.com");
        userService.RegisterUser(user2);
        
        // Test with invalid user
        var user3 = new User("", "invalid-email");
        userService.RegisterUser(user3);
        
        Console.WriteLine("\n✓ Benefits of Single Responsibility Principle:");
        Console.WriteLine("  - Each class has one reason to change");
        Console.WriteLine("  - Easy to test each component independently");
        Console.WriteLine("  - Easy to maintain and extend");
        Console.WriteLine("  - Better code organization and readability");
        Console.WriteLine("  - Components can be reused in different contexts");
        
        // Show all saved users
        Console.WriteLine("\n--- All Saved Users ---");
        var allUsers = repository.LoadAll();
        foreach (var user in allUsers)
        {
            Console.WriteLine($"  {user}");
        }
        
        Console.WriteLine("\n" + "=".PadRight(60, '='));
    }
}
