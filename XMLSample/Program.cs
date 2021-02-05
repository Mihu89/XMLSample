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

            //// Answer:
            xmlTextWriter = new XmlTextWriter(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\answer.xml", null);
            xmlTextWriter.Formatting = Formatting.Indented; 
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("UtilizatoriDatabase");
            xmlTextWriter.WriteStartElement("Utilizator");

            // write next element
            xmlTextWriter.WriteStartElement("Utilizator_ID","");
            xmlTextWriter.WriteString("123");
            xmlTextWriter.WriteEndElement();
            // write other element
            xmlTextWriter.WriteStartElement("Utilizator_password","");
            xmlTextWriter.WriteString("Aladin");
            xmlTextWriter.WriteEndElement();
            
            xmlTextWriter.WriteEndElement();


            xmlTextWriter.WriteStartElement("Utilizator");

            // write next element
            xmlTextWriter.WriteStartElement("Utilizator_ID","");
            xmlTextWriter.WriteString("456");
            xmlTextWriter.WriteEndElement();
            // write other element
            xmlTextWriter.WriteStartElement("Utilizator_password","");
            xmlTextWriter.WriteString("Qwerty");
            xmlTextWriter.WriteEndElement();
            
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
            System.Console.WriteLine("XML was generated");

        }
    }
}
