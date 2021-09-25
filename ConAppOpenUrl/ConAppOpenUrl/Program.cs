using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;

namespace ConAppOpenUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            string browser = string.Empty;
            RegistryKey key = null;
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command");
                if (key != null)
                {
                    // Get default Browser
                    browser = key.GetValue(null).ToString().ToLower().Trim(new[] { '"' });
                }
                if (!browser.EndsWith("exe"))
                {
                    //Remove all after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe", StringComparison.InvariantCultureIgnoreCase) + 4);
                }
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            for (int i = 0; i < 50; i++)
            {
                // Open the browser.
                Process proc = Process.Start(browser, @"https://chanmingman.wordpress.com/");
                if (proc != null)
                {
                    Thread.Sleep(5000);
                    // Close the browser.
                    proc.Kill();
                }
            }
        }
    }
}
