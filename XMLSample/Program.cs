using System;
using System.Xml;

namespace XMLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML Intro");
            GenerateXML();

        }

        private static void GenerateXML()
        {
            // Generate Xml using XmlTextWriter
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\Users\Mihu\Desktop\XMLSample\student.xml", null);
            xmlTextWriter.WriteStartDocument();
            // add comments
            xmlTextWriter.WriteComment("My First comment in XML file");
        }
    }
}
