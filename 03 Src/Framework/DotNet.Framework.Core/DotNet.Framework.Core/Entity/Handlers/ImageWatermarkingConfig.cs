using System;

namespace DotNet.Framework.Core.Entity.Handlers
{
    /// <summary>
    /// 图片水印Config实体，对应 bin/Config/ImageWatermarkingConfig.xml
    /// </summary>
    [Serializable]
    public class ImageWatermarkingConfig
    {
        /// <summary>
        /// 要添加水印的图片如果不存在，此处给定默认显示图片（非水印）
        /// </summary>
        public string NormalImage { get; set; }
        /// <summary>
        /// 水印内容， 文字水印的文字内容 或者 图片水印的水印图片地址
        /// </summary>
        public string Watermarking { get; set; }
        /// <summary>
        /// 水印相关属性
        /// </summary>
        public Property Property { get; set; }
    }

    /// <summary>
    /// 水印属性配置
    /// </summary>
    [Serializable]
    public class Property
    {
        /// <summary>
        /// 水印位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 水印类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 如果是文字水印，指定水印文字字体比如“宋体”
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// 如果是文字水印，指定水印位子字体大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 要添加水印的图片路径组，可包含多个，用|分割
        /// </summary>
        public string FilePathGroup { get; set; }
    }
}
