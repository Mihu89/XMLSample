using System;
using System.Xml;
using System.Xml.Linq;

namespace XMLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML Intro");
            //GenerateXML();
            // ReadXml();
            GenerateXml_Manipulations();
        }

        private static void GenerateXml_Manipulations()
        {
            // Manipulation (add new node + remove first node)
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // Create tag
            XmlElement user = xDoc.CreateElement("user");
            //create attribute
            XmlAttribute userAttr = xDoc.CreateAttribute("name");
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");

            // create info for tag
            XmlText nameText = xDoc.CreateTextNode("Jeff Bezos");
            XmlText companyText = xDoc.CreateTextNode("Amazon");
            XmlText ageText = xDoc.CreateTextNode("50");

            // matching tags, attributes, values
            userAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);

            user.Attributes.Append(userAttr);
            user.AppendChild(companyElem);
            user.AppendChild(ageElem);

            xRoot.AppendChild(user);
            xDoc.Save(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\users_v2.xml");

            // Remove node
            var firstNode = xRoot.FirstChild;
            xRoot.RemoveChild(firstNode);
            xDoc.Save(@"C:\Users\Mihu\Documents\XMLSample\XMLSample\users.xml");

            // Using Linq to create XML
            XDocument xdoc = new XDocument();
            XElement nokia = new XElement("mobile");
            XAttribute nokiaAttr = new XAttribute("name", "Nokia X3");
            XElement nokiaCompany = new XElement("company", "Nokia");
            XElement nokiaPrice = new XElement("price", "5000");
            // matching
            nokia.Add(nokiaAttr);
            nokia.Add(nokiaCompany);
            nokia.Add(nokiaPrice);

            // seccond node
             XElement galaxy = new XElement("mobile");
            XAttribute galaxyAttr = new XAttribute("name", "Samsung Galaxy S21");
            XElement galaxyCompany = new XElement("company", "Samsung");
            XElement galaxyPrice = new XElement("price", "25000");
            // matching
            galaxy.Add(galaxyAttr);
            galaxy.Add(galaxyCompany);
            galaxy.Add(galaxyPrice);

            // create root node
            XElement mobiles = new XElement("mobiles");
            // add nodes
            mobiles.Add(nokia);
            mobiles.Add(galaxy);

            // add root tag
            xdoc.Add(mobiles);

            // Save file
            xdoc.Save("mobiles.xml");

            // CompactVersion
            xdoc = new XDocument(new XElement("mobiles",
                new XElement("mobile", 
                    new XAttribute("name", "Microsoft 640XL"),
                    new XElement("company", "Microsoft"),
                    new XElement("price", "5500")
                ),
                new XElement("mobile", 
                    new XAttribute("name", "Google Pixel X5"),
                    new XElement("company", "Google"),
                    new XElement("price", "15500")
                )
            ));
            xdoc.Save("mobiles_v2.xml");
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
