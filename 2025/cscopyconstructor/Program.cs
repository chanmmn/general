public class ShoppingCart : ICloneable
{
    public List<string> Items { get; set; } = new();
    public object Clone()
    {
        var clone = new ShoppingCart();
        clone.Items = new List<string>(Items); // Deep copy
        return clone;
    }
}
public class Program
{
    public static void Main()
    {
        var cart1 = new ShoppingCart();
        cart1.Items.Add("Laptop");
        var cart2 = (ShoppingCart)cart1.Clone();
        cart2.Items.Add("Phone");
        Console.WriteLine(string.Join(", ", cart1.Items)); // "Laptop"
        Console.WriteLine(string.Join(", ", cart2.Items)); // "Laptop, Phone"
    }
}
