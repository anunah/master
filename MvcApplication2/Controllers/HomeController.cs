using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Linq;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        //
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult XmlReader()
        {
            System.Xml.Serialization.XmlSerializer reader =
        new System.Xml.Serialization.XmlSerializer(typeof(head));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"D:\xmlfile.xml");
            head xmlfile = new head();
            xmlfile = (head)reader.Deserialize(file);
            var xmlfind = xmlfile.Items.Where(el => el.subElement1[0].Value == "2222");
            foreach (var it in xmlfind)
            {
                string st = it.subElement1[0].subnumber;
            }
            file.Close();
            return View(xmlfile);
        }
        public ActionResult XmlReader2()
        {
            XElement root = XElement.Load(@"D:\xmlfile.xml");
            IEnumerable<XElement> test = from el in root.Descendants("subElement2")
                                         /*where (string)el.Attribute("subnumber") == "2"*/
                                         select el;
            foreach (var it in test)
            {
                var item = it.Value;
            }
            ViewBag.test = test;
            return View(test);
        }
        public ActionResult XmlReader3()
        {
            XElement root = XElement.Load(@"D:\xml.xml");
            var test = from el in root.Elements("Address")
                       where (string)el.Element("Zip") == "95819"
                       select el.Element("Name").Value;
            foreach (var it in test)
            {
                var item = it;
            }
            ViewBag.test = test;
            return View(test);
        }
        public ActionResult XmlEdit()
        {
            XElement root = XElement.Load(@"D:\xml.xml");
            var test = (from el in root.Elements("Address")
                        where (string)el.Element("Zip") == "10999"
                        select el).FirstOrDefault();
            var test1 = (from el in root.Elements("Address")
                        where (string)el.Element("Zip") == "10999"
                         select el.Element("Street")).FirstOrDefault();
            var test2 = (from el in root.Elements("Address")
                         where (string)el.Element("Zip") == "10999"
                         select el.Element("phone")).FirstOrDefault();
            

            if (test1 != null)

            {
                test.Element("Street").Remove();
            }
            int countp = (from el2 in root.Descendants("phone")
                          //where (string)el2.Element("Zip") == "95819"
                          select el2.Element("phone")).Count();
            if (test2 == null)
            {
                test.Add(new XElement("phone", "234-234-2344"));
            }
            root.Save(@"D:\xml.xml");
            /*foreach (var it in test)
            {
                var item = it;
            }*/
            //jhkjhk
            ViewBag.test = test;
            return View(test);
        }
        public ActionResult XmlWrite()
        {
            System.Xml.Serialization.XmlSerializer write =
        new System.Xml.Serialization.XmlSerializer(typeof(head));
            System.IO.StreamWriter filew = new System.IO.StreamWriter(@"D:\xmlfile.xml");
            head xmlfile = new head();
            headElement subhead = new headElement();
            headElement subheadd = new headElement();
            headElementSubElement1 subhead1 = new headElementSubElement1();
            headElementSubElement1 subhead2 = new headElementSubElement1();
            headElementSubElement2 subhead3 = new headElementSubElement2();
            subhead1.Value = "2222";
            subhead1.subnumber = "1";
            subhead2.Value = "33333";
            subhead2.subnumber = "2";
            subhead3.Value = "44444";
            subhead3.subnumber = "3";
            headElementSubElement1[] itemsub1 = { subhead1 };
            headElementSubElement1[] itemsub2 = { subhead2 };
            headElementSubElement2[] itemsub3 = { subhead3 };
            subhead.subElement1 = itemsub1;
            subhead.subElement2 = itemsub3;
            subheadd.subElement1 = itemsub2;
            headElement[] itemsub = { subhead, subheadd };
            // headElement [] itemsubb = { subheadd };
            xmlfile.Items = itemsub;
            //xmlfile.Items = itemsubb;
            //
            //
            write.Serialize(filew, xmlfile);
            filew.Close();
            return View();
        }
        public ActionResult XmlWrite2()
        {
            string path = @"D:\xml2.xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            using (XmlWriter xml = XmlWriter.Create(path, settings))
            {
                xml.WriteStartElement("head");
                xml.WriteEndElement();

            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode el = doc.CreateElement("element");
            doc.DocumentElement.AppendChild(el);
            XmlAttribute att = doc.CreateAttribute("number");
            att.Value = "1";
            el.Attributes.Append(att);


            XmlNode el1 = doc.CreateElement("element");
            doc.DocumentElement.AppendChild(el1);
            XmlAttribute att1 = doc.CreateAttribute("number");
            att1.Value = "2";
            el1.Attributes.Append(att1);
            el1.InnerText = "123";

            XmlNode sub = doc.CreateElement("sub");
            el.AppendChild(sub);
            sub.InnerText = "123";

            doc.Save(path);
            return View();
        }
        public ActionResult XmlWrite3()
        {
            XDocument doc = new XDocument();

            XElement el1 = new XElement("element");
            XAttribute att = new XAttribute("num", "1");
            XElement subel = new XElement("subelement", "123");
            el1.Add(att);
            el1.Add(subel);
            XElement el2 = new XElement("element");
            XAttribute att2 = new XAttribute("num", "2");
            XElement subel2 = new XElement("subelement", "234");
            el2.Add(att2);
            el2.Add(subel2);

            XElement head = new XElement("head");
            head.Add(el1);
            head.Add(el2);

            doc.Add(head);
            doc.Save(@"D:\xml3.xml");

            return View();
        }
    }

}
