using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            float flt1 = 0.0f;
            float flt2 = 0.0f;
            float flt3 = 0.0f;

            int total = 0;
            float fltTotal = 0.0f;

            InputValue(out num1, out num2, out num3);
            //InputValue( num1,  num2,  num3);
            InputValue(out flt1, out flt2, out flt3);
            total = Add(num1, num2, num3);
            fltTotal = Add(flt1, flt2, flt3);
            PrintTotal(total);
            PrintTotal(fltTotal);

            Console.ReadLine();
        }

        private static void PrintTotal(int total)
        {
            Console.WriteLine("Total = {0}", total);
        }

        private static void PrintTotal(float total)
        {
            Console.WriteLine("Total = {0}", total);
        }

        private static int Add(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        private static float Add(float num1, float num2, float num3)
        {
            return num1 + num2 + num3;
        }


        //private static void InputValue( int num1,  int num2,  int num3)
        private static void InputValue(out int num1, out int num2, out int num3)
        {
            num1 = 0;
            num2 = 0;
            num3 = 0;
            try
            {
                Console.WriteLine("Enter num1");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter num2");
                num2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter num3");
                num3 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //EventLog.CreateEventSource("Application", ex.Message);
                //WriteLog(ex.Message);
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                }
            }
            finally
            {
                if (num1 == 0)
                {
                    InputValue(out num1, out num2, out num3);
                }
            }
        }

        private static void InputValue(out float num1, out float num2, out float num3)
        {
            Console.WriteLine("Enter flt1");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter fkt2");
            num2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter flt3");
            num3 = float.Parse(Console.ReadLine());
        }

        public static void WriteLog(string msg)
        {
            string filename = "Log.txt";
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(DateTime.Now + "    " + msg);
            sw.Close();
        }
    }
}
