using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDebug
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteLog();
        }

        protected override void OnStop()
        {
        }

        public void WriteLog()
        {
            string strOutFile = @"d:\test\log.txt";
            string strLine = "Log line";
            StreamWriter sw = new StreamWriter(strOutFile);
            sw.WriteLine(strLine);
            sw.Close();
        }
    }
}
