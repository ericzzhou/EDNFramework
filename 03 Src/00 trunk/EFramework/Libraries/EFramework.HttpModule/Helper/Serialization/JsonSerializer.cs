using System.Web.Script.Serialization;

namespace EFramework.HttpModule.Helper.Serialization
{
    public class JsonSerializer
    {
        public static string Serialize<T>(T t)
        {
            JavaScriptSerializer JsSerializer = new JavaScriptSerializer();

            return JsSerializer.Serialize(t);
        }

        public static T Deserialize<T>(string str)
        {
            JavaScriptSerializer JsSerializer = new JavaScriptSerializer();
            return JsSerializer.Deserialize<T>(str);
        }
    }
}
