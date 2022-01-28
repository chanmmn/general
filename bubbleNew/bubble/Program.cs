using System;
class myclass

{
    static void Main()
    {
        Console.WriteLine("How many number to enter?");
        int time = int.Parse(Console.ReadLine());
        //int[] a = { 38, 6, 9, 66, 34, 45 };
        //int[] a = {4 ,5 ,6 ,3};
        int[] a = InputValue(time);
        int[] b = BubbleSort(a);

        Console.WriteLine("The Sorted array");
        foreach(int aa in b)
        {
            Console.WriteLine(aa + " ");
        }
        Console.WriteLine("The smallest number is {0}", b[0]);
        Console.WriteLine("The biggest number is {0}", b[b.Length-1]);
        //Console.Read();
    }

    public static int[] InputValue(int time)
    {
        int input = 0;
        int[] arr = new int[time];
        for (int i=0; i < time; i++)
        {
            Console.WriteLine("Enter number {0}", i);
            input = int.Parse(Console.ReadLine());
            arr[i] = input;
        }

        return arr;
    }

    private static int[] BubbleSort(int[] a)
    {
        int temp;
        for (int pass = 1; pass <= a.Length - 1; pass++)
        {
            for (int i = 0; i <= a.Length - 2; i++)
            {
                if (a[i] > a[i + 1])
                {
                    temp = a[i + 1];
                    a[i + 1] = a[i];
                    a[i] = temp;
                }
            }
        }
        return a;
    }
}
