using Microsoft.Security.Application;

namespace DotNet.Framework.Utils.Web
{
    public class XssHelper
    {
        public static string CssEncode(string input)
        {
            return Encoder.CssEncode(input);
        }

        public static string HtmlAttributeEncode(string input)
        {
            return Encoder.HtmlAttributeEncode(input);
        }

        public static string HtmlEncode(string input)
        {
            return Encoder.HtmlEncode(input);
        }

        /// <summary>
        /// Encodes input strings for use in HTML.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="useNamedEntities">Value indicating if the HTML 4.0 named entities should be used.</param>
        /// <returns></returns>
        public static string HtmlEncode(string input, bool useNamedEntities)
        {
            return Encoder.HtmlEncode(input, useNamedEntities);
        }

        /// <summary>
        /// Encodes input strings for use in application/x-www-form-urlencoded form submissions.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input)
        {
            return Encoder.HtmlFormUrlEncode(input);
        }

        /// <summary>
        /// Encodes input strings for use in application/x-www-form-urlencoded form submissions.
        /// </summary>
        /// <param name="input">String to be encoded.</param>
        /// <param name="codePage">Codepage number of the input.</param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input, int codePage)
        {
            return Encoder.HtmlFormUrlEncode(input, codePage);
        }

        /// <summary>
        /// Encodes input strings for use in application/x-www-form-urlencoded form submissions.
        /// </summary>
        /// <param name="input">String to be encoded.</param>
        /// <param name="inputEncoding">Input encoding type.</param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input, System.Text.Encoding inputEncoding)
        {
            return Encoder.HtmlFormUrlEncode(input, inputEncoding);
        }

        public static string JavaScriptEncode(string input)
        {
            return Encoder.JavaScriptEncode(input);
        }

        public static string JavaScriptEncode(string input, bool emitQuotes)
        {
            return Encoder.JavaScriptEncode(input, emitQuotes);
        }

        /// <summary>
        /// Encodes input strings for use in XML.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string XmlEncode(string input)
        {
            return Encoder.XmlEncode(input);
        }

        /// <summary>
        /// Encodes input strings for use in XML attributes.
        /// </summary>
        /// <param name="input">String to be encoded</param>
        /// <returns></returns>
        public static string XmlAttributeEncode(string input)
        {
            return Encoder.XmlAttributeEncode(input);
        }

        /// <summary>
        /// Encodes input strings for use in universal resource locators (URLs).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlEncode(string input)
        {
            return Encoder.UrlEncode(input);
        }

        /// <summary>
        /// Encodes input strings for use in universal resource locators (URLs).
        /// </summary>
        /// <param name="input"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public static string UrlEncode(string input, int codePage)
        {
            return Encoder.UrlEncode(input, codePage);
        }

        /// <summary>
        /// Encodes input strings for use in universal resource locators (URLs).
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputEncoding"></param>
        /// <returns></returns>
        public static string UrlEncode(string input, System.Text.Encoding inputEncoding)
        {
            return Encoder.UrlEncode(input, inputEncoding);
        }

        /// <summary>
        ///  URL-encodes the path section of a URL string and returns the encoded string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlPathEncode(string input)
        {
            return Encoder.UrlPathEncode(input);
        }
    }
}
