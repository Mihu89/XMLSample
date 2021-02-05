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
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\student.xml", null);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            // add comments
            xmlTextWriter.WriteComment("My First comment in XML file");
            xmlTextWriter.WriteStartElement("Student");
            xmlTextWriter.WriteStartElement("r", "Record", "urn:record");

            //write other element
            xmlTextWriter.WriteStartElement("Name", "");
            xmlTextWriter.WriteString("Student 1");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("Address", "");
            xmlTextWriter.WriteString("Camin 2");
            xmlTextWriter.WriteEndElement();

            char[] chArray = new char[3];
            chArray[0]='a';
            chArray[1]='b';
            chArray[2]='c';
            xmlTextWriter.WriteStartElement("Char");
            xmlTextWriter.WriteChars(chArray, 0, chArray.Length);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();


        }
    }
}
