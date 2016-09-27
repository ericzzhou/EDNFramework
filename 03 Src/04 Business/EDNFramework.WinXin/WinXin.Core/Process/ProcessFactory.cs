using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.WinXin.Core.Model.Request.WXEvent;
using DotNet.Framework.WinXin.Core.Model.Request.WXMessage;
using DotNet.Framework.WinXin.Core.Utils;
using System;
using System.Xml.Linq;

namespace DotNet.Framework.WinXin.Core.Process
{
    public class ProcessFactory
    {
        public static string Reply(string xml)
        {
            IProcess instance = null;
            WinXinMessage entity = null;
            XElement root = XElement.Parse(xml);
            string msgType = root.Element("MsgType").Value;

            WXLog.Write(msgType, xml);

            switch (msgType)
            {
                case "text":
                    instance = GetInstance("message_text");
                    entity = ObjectXmlSerializer.Deserialize<RequestTextMessage>(xml);
                    break;
                case "image":
                    instance = GetInstance("message_image");
                    entity = ObjectXmlSerializer.Deserialize<RequestImageMessage>(xml);
                    break;
                case "voice":
                    instance = GetInstance("message_voice");
                    entity = ObjectXmlSerializer.Deserialize<RequestVoiceMessage>(xml);
                    break;
                case "video":
                    instance = GetInstance("message_video");
                    entity = ObjectXmlSerializer.Deserialize<RequestVideoMessage>(xml);
                    break;
                case "location":
                    instance = GetInstance("message_location");
                    entity = ObjectXmlSerializer.Deserialize<RequestLocationMessage>(xml);
                    break;
                case "link":
                    instance = GetInstance("message_link");
                    entity = ObjectXmlSerializer.Deserialize<RequestLinkMessage>(xml);
                    break;
                case "event":
                    switch (root.Element("Event").Value)
                    {
                        case "subscribe":
                            if (root.Element("EventKey") != null)
                            {
                                instance = GetInstance("event_subscribe");
                                entity = ObjectXmlSerializer.Deserialize<RequestWinXinEvent>(xml);
                            }
                            else
                            {
                                instance = GetInstance("event_qrcode_subscribe");
                                entity = ObjectXmlSerializer.Deserialize<RequestQRCodeEvent>(xml);
                            }
                            break;
                        case "SCAN":
                            instance = GetInstance("event_qrcode_scan");
                            entity = ObjectXmlSerializer.Deserialize<RequestQRCodeEvent>(xml);
                            break;
                        case "LOCATION":
                            instance = GetInstance("event_LOCATION");
                            entity = ObjectXmlSerializer.Deserialize<RequestLocationEvent>(xml);
                            break;
                        case "CLICK":
                            instance = GetInstance("event_CLICK");
                            entity = ObjectXmlSerializer.Deserialize<RequestMenuEvent>(xml);
                            break;
                        case "VIEW":
                            instance = GetInstance("event_VIEW");
                            entity = ObjectXmlSerializer.Deserialize<RequestMenuEvent>(xml);
                            break;
                        default:
                            break;
                    }
                    //instance = GetInstance("event");
                    //entity = ObjectXmlSerializer.Deserialize<TextMessage>(xml);
                    break;

                default:
                    break;
            }
            if (instance != null)
            {
                return instance.Process(entity, xml);
            }
            else
            {
                return " ";
                throw new Exception("接口未实行");
            }
        }
        public static IProcess GetInstance(string str)
        {
            return null;
        }
    }
}
