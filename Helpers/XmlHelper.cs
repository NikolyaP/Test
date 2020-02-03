using System.IO;
using System.Xml.Serialization;
using WCFApp.Models;

namespace WCFApp.Helpers
{
    public static class XmlHelper
    {
        public static T XmlToObject<T>(string fileName) where T: IHttpModel
        {
            if (string.IsNullOrEmpty(fileName)) return default(T);

                var xmlStream = new StreamReader(fileName);
                var serializer = new XmlSerializer(typeof(T));
                var returnObject = (T)serializer.Deserialize(xmlStream);
            return returnObject;
        }
    }
}