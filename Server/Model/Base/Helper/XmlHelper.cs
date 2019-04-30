using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Model.Base.Helper
{
    public static class XmlHelper
    {
        public static T ToObject<T>(string str)
        {
            T t = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (Stream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlStream))
                {
                    object obj = xmlSerializer.Deserialize(xmlReader);
                    t = (T)obj;
                }
            }
            return t;
        }

        public static string ToXml<T>(T obj)
        {
            string xmlString = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xmlString;
        }
    }
}
