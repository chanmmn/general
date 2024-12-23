using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000); // Simulate asynchronous work
            yield return i;
        }
    }

    static async Task Main(string[] args)
    {
        await foreach (var number in GenerateNumbersAsync())
        {
            Console.WriteLine(number);
        }
    }
}
