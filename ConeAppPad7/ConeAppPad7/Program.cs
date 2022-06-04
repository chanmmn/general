using System;
using System.Collections.Generic;
using System.IO;

namespace ConeAppPad7
{
    class Program
    {
        static void Main(string[] args)
        {
            string strInFile = @"d:\test\cobol\hellocobproblem.cbl";
            string strOutFile = @"d:\test\cobol\hellocobproblem1.cbl";

            if (args[0] != null)
            {
                strInFile = args[0];
                strOutFile = NewOutFile(args[0]);
            }
            ReadWriteString(strInFile, strOutFile);
        }

        public static string NewOutFile(string strOutFile)
        {
            string strTemp = "";
            int index = strOutFile.IndexOf(".");
            strTemp = strOutFile.Substring(0, index);
            strTemp = strTemp + "1.cbl";
            return strTemp;
        }

        public static void ReadWriteString(string strInFile, string strOutFile)
        {
            String strLine;

            List<string> strList = new List<string>();
            StreamReader streamReader = new StreamReader(strInFile);
            StreamWriter sw = new StreamWriter(strOutFile);

            while (!streamReader.EndOfStream)
            {
                //Read line
                strLine = streamReader.ReadLine();

                strLine = "       " + strLine;
                //Write a line of text
                sw.WriteLine(strLine);
            }
            streamReader.Close();
            sw.Close();

        }
    }
}
