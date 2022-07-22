using System;
using System.Collections;

public class RandomDateTime
{
    DateTime start;
    Random gen;
    int range;

    public RandomDateTime()
    {
        start = new DateTime(1970, 1, 1);
        gen = new Random();
        range = (DateTime.Today - start).Days;
    }

    public DateTime Next()
    {
        return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
    }
}
public class BankTransaction : IComparable
{
    // The temperature value
    protected DateTime transactionDate;
    protected double AccountId;

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        BankTransaction otherTemperature = obj as BankTransaction;
        if (otherTemperature != null)
            return this.transactionDate.CompareTo(otherTemperature.transactionDate);
        else
            throw new ArgumentException("Object is not a Date");
    }

    public DateTime TransactionDate
    {
        get
        {
            return this.transactionDate;
        }
        set
        {
            this.transactionDate = value;
        }
    }

    public double AccID
    {
        get
        {
            return AccountId;
        }
        set
        {
            this.AccountId = value;
        }
    }
}

public class CompareTemperatures
{
    public static void Main()
    {
        ArrayList BankTrans = new ArrayList();
        // Initialize random number generator.
        RandomDateTime date = new RandomDateTime();

        // Generate 10 temperatures between 0 and 100 randomly.
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            DateTime transDate = date.Next();
            BankTransaction temp = new BankTransaction();
            temp.TransactionDate = transDate;
            BankTrans.Add(temp);
        }

        BankTrans.Sort();

        foreach (BankTransaction temp in BankTrans)
            Console.WriteLine(temp.TransactionDate);
    }
}
