using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WFAHamburgerci
{
    public static class FileHelper
    {
        private static string MainDirectoryPath = @"C:\WFAHamburgerci";
        private static string MenuPath = Path.Combine(MainDirectoryPath, "Menuler.xml");
        private static string MalzemePath = Path.Combine(MainDirectoryPath, "Malzemeler.xml");

        public static void KlasorYarat()
        {
            if (!Directory.Exists(MainDirectoryPath))
                Directory.CreateDirectory(MainDirectoryPath);
        }

        public static void MenuDosyaYarat()
        {
            KlasorYarat();
            if (!File.Exists(MenuPath))
            {
                var file = File.Create(MenuPath);
                file.Close();
            }
        }
        public static void MalzemeDosyaYarat()
        {
            KlasorYarat();
            if (!File.Exists(MalzemePath))
            {
                var file = File.Create(MalzemePath);
                file.Close();
            }

        }

        public static void MenuIlkDegerleriniDoldur()
        {

            MenuSchema menuSchema = new MenuSchema();

            List<MenuSchemaMenu> menuItemList = new List<MenuSchemaMenu>
            {
                new MenuSchemaMenu() {MenuAdi="Steakhouse",Fiyati=18.25M},
                new MenuSchemaMenu() {MenuAdi = "Big king", Fiyati = 4M},
                new MenuSchemaMenu() {MenuAdi = "King Chicken", Fiyati = 5M},
            };

            menuSchema.menu = menuItemList.ToArray();

            XmlSerializer xs = new XmlSerializer(typeof(MenuSchema));
            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, menuSchema);
                    xml = sw.ToString();

                }
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            xmlDoc.Save(MenuPath);
        }

        public static void MalzemeIlkDegerleriniDoldur()
        {
            MalzemeSchema malzemeSchema = new MalzemeSchema();

            List<MalzemeSchemaMalzeme> malzemeItemList = new List<MalzemeSchemaMalzeme>()
            {
                new MalzemeSchemaMalzeme(){MalzemeAdi = "Ketcap",Fiyati=1},
                new MalzemeSchemaMalzeme(){MalzemeAdi = "Mayonez",Fiyati=1},
                new MalzemeSchemaMalzeme(){MalzemeAdi = "Ranch",Fiyati=1}
            };

            malzemeSchema.malzeme = malzemeItemList.ToArray();

            XmlSerializer xs = new XmlSerializer(typeof(MalzemeSchema));
            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, malzemeSchema);
                    xml = sw.ToString();
                }
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            xmlDoc.Save(MalzemePath);
        }

        public static List<Menu> MenuleriOku()
        {
            if (File.Exists(MenuPath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(MenuPath);

                XmlNode menuNode = xmlDoc.ChildNodes[1];

                List<Menu> menuList = new List<Menu>();

                foreach (XmlNode item in menuNode)
                {
                    menuList.Add(new Menu()
                    {
                        MenuAdi = item["MenuAdi"].InnerText.Trim(),
                        Fiyati = Convert.ToDecimal(item["Fiyati"].InnerText.Trim())
                    });
                }
                return menuList;


            }
            return new List<Menu>();

        }
        public static List<Extra> MalzemeleriOku()
        {
            if (File.Exists(MalzemePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(MalzemePath);

                XmlNode malzemeNode = xmlDoc.ChildNodes[1];

                List<Extra> malzemeList = new List<Extra>();

                foreach (XmlNode item in malzemeNode)
                {
                    malzemeList.Add(new Extra()
                    {
                        ExtraAdi = item["MalzemeAdi"].InnerText.Trim(),
                        Fiyati = Convert.ToDecimal(item["Fiyati"].InnerText.Trim())
                    });
                }
                return malzemeList;
            }
            return new List<Extra>();
        }

        public static void MenuEkle(String MenuAdi, decimal Fiyati)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(MenuPath);
            XmlNode menuNode = doc.CreateElement("menu");
            XmlNode menu = doc.CreateElement("MenuAdi");
            menu.InnerText = MenuAdi;
            XmlNode fiyati = doc.CreateElement("Fiyati");
            fiyati.InnerText = Fiyati.ToString();

            menuNode.AppendChild(menu);
            menuNode.AppendChild(fiyati);

            doc.ChildNodes[1].AppendChild(menuNode);
            doc.Save(MenuPath);

        }
        public static void MalzemeEkle(String MalzemeAdi,decimal Fiyati)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(MalzemePath);

            XmlNode malzemeNode = doc.CreateElement("malzeme");
            XmlNode malzemeAdi = doc.CreateElement("MalzemeAdi");
            malzemeAdi.InnerText = MalzemeAdi;
            XmlNode malzemeFiyati = doc.CreateElement("Fiyati");
            malzemeFiyati.InnerText = Fiyati.ToString();

            malzemeNode.AppendChild(malzemeAdi);
            malzemeNode.AppendChild(malzemeFiyati);

            doc.ChildNodes[1].AppendChild(malzemeNode);
            doc.Save(MalzemePath);
        }
    }
    
}