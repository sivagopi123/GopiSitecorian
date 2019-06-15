using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace LinQToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateSimpleXML();
            //ReadSimpleXML();
            CreateTypeInfo();

            //TransformXML();
        }

        private static void TransformXML()
        {
            XDocument doc = XDocument.Load("Employee-T.xml");

            XDocument transformed = new XDocument(
                                        new XElement("Employees",
                                            new XElement
                                                ("Developer",
                                                from d in doc.Descendants("Employee")
                                                where d.Attribute("Type").Value == "Developer"
                                                select new XElement("Dev-Employee", (string)d)),
                                            new XElement
                                                ("Sales",
                                                from s in doc.Descendants("Employee")
                                                where s.Attribute("Type").Value == "Sales"
                                                select new XElement("Sales-Employee", (string)s)
                                                )));

            Console.WriteLine(transformed);
        }

        private static void CreateTypeInfo()
        {
            XDocument doc = new XDocument(new XElement
                ("Type",
                Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Select(name => Assembly.Load(name))
                .SelectMany(assembly => assembly.GetTypes())
                .Select(type => new XElement("Type",
                                            type.FullName,
                                            new XAttribute("IsPublic", type.IsPublic))
                )));

            var assemblyTypes = new XDocument(new XElement
                ("Types", Assembly
                    .GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Select(assemblyref =>
                        Assembly.Load(assemblyref))
                    .SelectMany(assembly => assembly.GetTypes())
                    .Select(types => new XElement("Type", types.FullName)).Take(10)));

            Console.WriteLine(assemblyTypes);


        }

        private static void ReadSimpleXML()
        {
            XDocument doc = XDocument.Load("start.xml");
            XElement root = doc.Root;
            var elements = root.Descendants();
            foreach (var element in elements)
            {
                string value = (string)element;
                Console.WriteLine(value);
            }

        }

        private static void CreateSimpleXML()
        {
            //XDocument doc = new XDocument();
            //XElement root = new XElement("Modules");
            //XElement intro = new XElement("Module");
            //intro.Value = "Introduction to LINQ";
            //XElement cs = new XElement("Module");
            //cs.Value = "LINQ and C#";
            //root.Add(intro);
            //root.Add(cs);
            //doc.Add(root);


            //Refactored code

            XNamespace ns = "http://www.kia.com/Start";
            XNamespace ext = "http://www.kia.com/Start/Extention";

            XDocument docnew = new XDocument(new XElement
                                                (ns + "Modules",
                                                new XAttribute(XNamespace.Xmlns + "ext", ext),
                                                new XElement(ns + "Module",
                                                            "Introduction to LINQ"),
                                                new XElement(ns + "Module",
                                                            "LINQ and C#"),
                                                new XElement(ext + "Extra",
                                                            "Some other"),
                                                new XElement(ext + "Extra",
                                                            "Somem more stuff")));

            docnew.Save("start.xml");

            //XElement inline = XElement.Parse($"<?xml version='1.0' encoding='utf - 8'?>" +
            //                                    "<Modules>" +
            //                                      "<Module> Introduction to LINQ </Module>" +
            //                                      "<Module> LINQ and C#</Module>" +
            //                                    "</Modules>"
            //                                    );


            Console.WriteLine(docnew);
        }
    }
}
