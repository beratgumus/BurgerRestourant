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
        public static void KlasorYarat()
        {
            if(!Directory.Exists(MainDirectoryPath))
                 Directory.CreateDirectory(MainDirectoryPath);
        }

        public static void MenuDosyaYarat()
        {
            KlasorYarat();
            if(!File.Exists(MenuPath))
            {
                var file = File.Create(MenuPath);
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

        public static List<Menu> MenuleriOku()
        {
            if(File.Exists(MenuPath))
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
    }
}
