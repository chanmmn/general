namespace ConAppPolymprphism
{
    interface IDrivable
    {
        void Drive();
    }

    class Person : IDrivable
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Drive()
        {
            Console.WriteLine($"{Name} is driving a vehicle.");
        }
    }

    class Employee : Person
    {
        public int EmployeeID { get; set; }

        public Employee(string name, int employeeID) : base(name)
        {
            EmployeeID = employeeID;
        }
    }

    class Manager : Employee
    {
        public string Department { get; set; }

        public Manager(string name, int employeeID, string department) : base(name, employeeID)
        {
            Department = department;
        }
    }

    class Driver : IDrivable
    {
        public string LicenseNumber { get; set; }

        public Driver(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }

        public void Drive()
        {
            Console.WriteLine($"Driver with license {LicenseNumber} is operating a vehicle.");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            IDrivable[] vehicles = new IDrivable[]
{
            new Person("Alice"),
            new Employee("Bob", 1001),
            new Manager("Charlie", 1002, "Sales"),
            new Driver("DL12345")
};

            foreach (var vehicle in vehicles)
            {
                vehicle.Drive();
            }
        }
    }
}