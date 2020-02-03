using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Final.Helpers
{
    public static class XmlHelper
    {
        public static T XmlToObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return default(T);

            var xmlStream = new StreamReader(fileName);
            var serializer = new XmlSerializer(typeof(T));
            var returnObject = (T) serializer.Deserialize(xmlStream);
            return returnObject;
        }

        public static string ObjToXml<T>(T obj)
        {
            var xsSubmit = new XmlSerializer(typeof(T));
            string xml;
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    return xml = sww.ToString();
                }
            }
        }
    }
}