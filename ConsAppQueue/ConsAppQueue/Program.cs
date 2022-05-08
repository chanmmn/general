using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue_Delegates
{
    public class RecordStorage
    {
        public delegate int InsertTable();
        public void ReportResult(InsertTable InsertDelegate)
        {            
            if (InsertDelegate() == 0)
            {
                Console.WriteLine("Insert successfully.");                
            }
            else
            {
                Console.WriteLine("Insert not play successfully.");
            }
        }
    }

    public static class QueueData
    {
        public static Queue<string> recordqueue = new Queue<string>();
    }

    public class AccountTable
    {
        private int InsertStatus;
        string value = "";
        public int InsetData()
        {
            Console.WriteLine("Simulating Insert Record.");
            value = QueueData.recordqueue.Dequeue();
            Console.WriteLine("Dequeue {0}", value);
            InsertStatus = 0;
            return InsertStatus;
        }
    }

    public class Tester
    {
        public void Run()
        {
            RecordStorage myRecordStorage = new RecordStorage();

            // instantiate the Account Table
            AccountTable accountTable = new AccountTable();


            // instantiate the delegates
            RecordStorage.InsertTable InsertDelegate = new
                   RecordStorage.InsertTable(accountTable.InsetData);

            // call the delegates
            while(QueueData.recordqueue.Count > 0)
            {
                myRecordStorage.ReportResult(InsertDelegate);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QueueData.recordqueue.Enqueue("Record1");
            QueueData.recordqueue.Enqueue("Record2");
            QueueData.recordqueue.Enqueue("Record3");
            QueueData.recordqueue.Enqueue("Record4");
            QueueData.recordqueue.Enqueue("Record5");

            Tester t = new Tester();
            t.Run();
        }
    }
}