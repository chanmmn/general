using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        ParseXmlFile();
    }

    private static void ParseXmlFile()
    {
        string xmlFilePath = "XMLFileRemoveUTF8.xml";

        // Create a new XmlDocument instance
        XmlDocument xmlDoc = new XmlDocument();

        try
        {
            // Load the XML file
            xmlDoc.Load(xmlFilePath);

            // TODO: Add your XML parsing logic here
            // Loop through all the elements in the XML file
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                // Check if the node is an element node
                if (node.NodeType == XmlNodeType.Element)
                {
                    // Get the value of the element
                    string value = node.InnerText;
                    
                    // TODO: Add your logic to process the value here
                    // Example: Get the element name
                    string elementName = node.Name;
                    Console.WriteLine("Element Name: " + elementName);
                    // Example: Print the value
                    Console.WriteLine("Value: " + value);
                }
            }
            // Example: Get the root element
            XmlElement rootElement = xmlDoc.DocumentElement;
            Console.WriteLine("Root element: " + rootElement.Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while parsing the XML file: " + ex.Message);
        }
    }
}