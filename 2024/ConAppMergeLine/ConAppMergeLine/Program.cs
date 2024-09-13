namespace ConAppMergeLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> addresses = ReadAddressesFromFile("addressRemovetill467.txt");
            List<string> newlines = new List<string>();
            bool isStart = false;
            bool bypass = false;
            string prev = "";
            int count = 0;
            // Use the addresses list here
            foreach (string address in addresses)
            {
                //if (bypass)
                //{
                //    bypass = false;
                //}
                //else
                //{
                    isStart = LineStart(address);
                if (isStart)
                {
                    prev = newlines[count - 1];
                    newlines.Remove(newlines[count - 1]);
                    count--;
                    if (count > 0)
                    {
                        //newlines[count - 1] += address;
                        prev += " " + address;
                        //newlines.Add(newlines[count - 1]);
                        newlines.Add(prev);
                        //bypass = true;
                    }
                    else if (count == 0)
                    {
                        prev += " " + address;
                        //newlines[count] = prev;
                        //newlines.Add(newlines[count]);
                        newlines.Add(prev);
                    }
                }
                else
                {
                    newlines.Add(address);
                }
                //}
                count++;
            }
            foreach (string line in newlines)
            {
                Console.WriteLine(line);
            }
            WriteListToFile(newlines, "AddressOut.txt");
        }

        public static bool LineStart(string line)
        {
            return line.StartsWith(",");
        }

        public static List<string> ReadAddressesFromFile(string filePath)
        {
            List<string> addresses = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        addresses.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }

            return addresses;
        }

        // ...

        public static void WriteListToFile(List<string> list, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (string item in list)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }
    }
}
