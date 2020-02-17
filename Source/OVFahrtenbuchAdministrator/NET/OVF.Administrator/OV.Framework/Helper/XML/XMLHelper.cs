using System.IO;
using System.Xml.Linq;


namespace OV.Framework.Helper.XML
{
    public class XMLHelper
    {
        #region "members"

        #endregion

        #region "methods"
        #region "public"
        public static void CreateMainConfigXML(string path, string server, string database, string user, string password, int port)
        {
            XElement xmlFile = new XElement("MainConfig",
                new XElement("Server", server),
                new XElement("database", database),
                new XElement("user", user),
                new XElement("password", password),
                new XElement("port", port)
                );
        }

        public static void CreateAdminConfigXML(string path, string password)
        {
            XElement xmlFile = new XElement("AdminConfig",
                new XElement("Password", password)
                );
        }

        public static bool CheckIfXmlExists(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region "private"

        #endregion
        #endregion
    }
}
