using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Xml.Serialization;


namespace DotNet.Framework.Core.HttpHandlers
{
    /// <summary>
    /// 图片水印Handler
    /// Web.config <Handler> 节点下添加
    /// <add name="ImageWatermarkingHandler" path="*.png" verb="*" type="DotNet.Framework.Core.HttpHandlers.ImageWatermarkingHandler,DotNet.Framework.Core"/>
    /// <add name="ImageWatermarkingHandler" path="*.jpg" verb="*" type="DotNet.Framework.Core.HttpHandlers.ImageWatermarkingHandler,DotNet.Framework.Core"/>
    /// 配置bin 目录下 Config/ImageWatermarkingConfig.xml
    /// 目前仅支持文字水印
    /// </summary>
    public class ImageWatermarkingHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Entity.Handlers.ImageWatermarkingConfig config = GetImageWatermarkingConfig(context);

            //获取请求的物理图片路径
            string imagePath = context.Request.PhysicalPath;

            Image image = null;
            if (File.Exists(imagePath))
            {
                if (config == null || config.Property == null)
                {
                    image = Image.FromFile(imagePath);
                }
                else
                {
                    string[] PathGroup = config.Property.FilePathGroup.Split('|');
                    foreach (var item in PathGroup)
                    {
                        if (!imagePath.Contains(item))
                        {
                            //定义水印文字
                            string text = config.Watermarking;
                            //水印文字字体
                            Font font = new Font(config.Property.FamilyName, config.Property.Size);
                            //根据图片物理地址加载图片
                            image = Image.FromFile(imagePath);
                            Graphics g = Graphics.FromImage(image);
                            //获取要绘制水印文字所需要的显示区域大小
                            SizeF size = g.MeasureString(text, font);
                            if (size.Width > image.Width || size.Height > image.Height)
                            {
                                //如果要显示的图片的尺寸都不足以显示按照指定字体来添加水印
                                //可以减小字体大小或者不添加水印（太小了没办法添加嘛）
                            }
                            else//添加水印文字
                            {
                                Brush brush = Brushes.Red;
                                //在图片上添加水印,绘制水印文字在图片的右下角
                                g.DrawString(text, font, brush, image.Width - size.Width, image.Height - size.Height);
                                g.Dispose();
                            }
                            break;
                        }
                        else
                            image = Image.FromFile(imagePath);
                    }
                }
            }
            else//如果不存在，指定一个默认图片进行显示
            {
                imagePath = context.Server.MapPath(config.NormalImage);
                image = Image.FromFile(imagePath);
            }
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);//将添加水印的图片输入到当前流中
        }

        private Entity.Handlers.ImageWatermarkingConfig GetImageWatermarkingConfig(HttpContext context)
        {
            Entity.Handlers.ImageWatermarkingConfig conf;
            var configPath = context.Server.MapPath("~/bin/Resource/DotNet.Framework.Core/Config/ImageWatermarkingConfig.xml");
            using (FileStream fs = new FileStream(configPath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Entity.Handlers.ImageWatermarkingConfig));
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    conf = (Entity.Handlers.ImageWatermarkingConfig)ser.Deserialize(sr);
                    sr.Close();
                    fs.Close();
                }
            }

            return conf;
        }
    }
}
