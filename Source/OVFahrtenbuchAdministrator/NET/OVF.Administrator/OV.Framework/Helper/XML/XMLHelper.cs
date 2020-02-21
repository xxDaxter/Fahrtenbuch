using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OV.Framework.Helper.XML
{
    public static class XMLHelper
    {
        #region "members"

        #endregion

        #region "methods"
        #region "public"

        public static bool CheckIfXmlExists(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            return true;
        }

        public static void ConvertObjectToXml(string path, object item)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }            

            try
            {
                XmlSerializer serializer = new XmlSerializer(item.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, item);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            System.IO.File.WriteAllText(path, sw.ToString());
        }

        public static object ConvertXmlToObjekt(string path, Type objectType)
        {
            if (!CheckIfXmlExists(path))
            {
                throw new Exception("Keine XML gefunden");
            }

            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            string textValue = System.IO.File.ReadAllText(path);

            try
            {
                strReader = new StringReader(textValue);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }

        #endregion

        #region "private"

        #endregion
        #endregion
    }
}
