using System;

namespace ConsAppWhereT
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public void Todo()
        { }
    }
    public class Machine
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public void Operate()
        { }
    }
    public class MyList<T> where T : new()
    {
        T value = new T();
        public MyList() 
        { }
    }
    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}
