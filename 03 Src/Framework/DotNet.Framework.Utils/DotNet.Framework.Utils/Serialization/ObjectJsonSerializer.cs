
using System.IO;
namespace DotNet.Framework.Utils.Serialization
{
    public class ObjectJsonSerializer //: IObjectSerializer
    {
        public static string Serialize<T>(T t)
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(t);
            System.Web.Script.Serialization.JavaScriptSerializer JsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            return JsSerializer.Serialize(t);
        }

        public static T Deserialize<T>(string str)
        {
            System.Web.Script.Serialization.JavaScriptSerializer JsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return JsSerializer.Deserialize<T>(str);
        }

        public static T Deserialize_NewTon<T>(string str)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
        }

        public static string Serialize_NewTon<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }

        //public static T Json2EntityFromAjaxRequest<T>()
        //{
        //    return Deserialize<T>(new StreamReader(Request.InputStream).ReadToEnd());
        //}

        /// <summary>
        /// 自动转换jquery ajax 请求数据为实体对象，需传输正确的json格式，用 Jons2.js JSON.stringify()方法进行转换
        /// Exam:
        ///  $("#btn_Insert").click(function () {
        ///    _self.LoadData();
        ///    $.AjaxPost('?ajax=AddData', true, JSON.stringify(_self.data));
        ///  });
        /// </summary>
        /// <typeparam name="T">要转换的目标实体对象</typeparam>
        /// <param name="Request">当前请求Request</param>
        /// <returns>返回转换后的实体（已附加数据）</returns>
        public static T Json2EntityFromAjaxRequest<T>(System.Web.HttpRequest Request)
        {
            return Deserialize<T>(new StreamReader(Request.InputStream).ReadToEnd());
        }
    }
}
