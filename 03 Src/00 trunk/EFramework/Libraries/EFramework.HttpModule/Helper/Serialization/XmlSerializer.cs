using System.IO;
using System.Text;

using xml = System.Xml.Serialization;
namespace EFramework.HttpModule.Helper.Serialization
{
    public class XmlSerializer
    {
        public static string Serialize<T>(T t)
        {
            StringBuilder sb = new StringBuilder();
            xml.XmlSerializer xmlSer = new xml.XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(sb))
            {
                xmlSer.Serialize(writer, t);
                return writer.ToString();
            }

        }

        /// <summary>
        /// string 序列化为 对象 T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string str)
        {
            xml.XmlSerializer xmlSer = new xml.XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(str))
            {
                T t = (T)xmlSer.Deserialize(reader);
                return t;
            }
        }
    }
}
