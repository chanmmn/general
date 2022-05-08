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
            string value = "";
            if (InsertDelegate() == 0)
            {
                Console.WriteLine("Insert successfully.");
                value = QueueData.recordqueue.Dequeue();
                Console.WriteLine("Dequeue {0}", value);
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

        public int InsetData()
        {
            Console.WriteLine("Simulating Insert Record.");
            InsertStatus = 0;
            return InsertStatus;
        }
    }

    public class Tester
    {
        public void Run()
        {
            RecordStorage myRecordStorage = new RecordStorage();

            // instantiate the two media players
            AccountTable myAudioPlayer = new AccountTable();


            // instantiate the delegates
            RecordStorage.InsertTable audioPlayerDelegate = new
                   RecordStorage.InsertTable(myAudioPlayer.InsetData);

            // call the delegates
            while(QueueData.recordqueue.Count > 0)
            {
                myRecordStorage.ReportResult(audioPlayerDelegate);
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