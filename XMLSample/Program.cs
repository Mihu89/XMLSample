using System;
using System.Xml;

namespace XMLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML Intro");
            //GenerateXML();
            ReadXml();
        }

        private static void ReadXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\users.xml");
            // get root node
            XmlElement xRoot = xDoc.DocumentElement;
            // parse nodes
            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes.Count > 0){
                    XmlNode attribute  = xNode.Attributes.GetNamedItem("name");
                    if(attribute != null){
                        System.Console.WriteLine(attribute.Value);
                    }
                    foreach(XmlNode childNode in xNode.ChildNodes){
                        if(childNode.Name =="company"){
                            System.Console.WriteLine($"Company: {childNode.InnerText}");
                        }
                        if(childNode.Name =="age"){
                            System.Console.WriteLine($"User age: {childNode.InnerText}");
                        }
                    }
                    System.Console.WriteLine();
                }
            }
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
