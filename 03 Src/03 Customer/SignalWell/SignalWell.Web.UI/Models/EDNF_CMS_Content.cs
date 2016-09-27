using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalWell.Web.UI.Models
{
    public class EDNF_CMS_Content
    {
        [DataMapping("ContentID")]
        public int ContentID { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("Title")]
        public string Title { get; set; }

        [DataMapping("CreatedDate")]
        public string CreatedDate { get; set; }
        
    }
    public class Entity_About_LeftContent
    {
        [DataMapping("ContentID")]
        public int ContentID { get; set; }

        [DataMapping("ClassID")]
        public int ClassID { get; set; }

        [DataMapping("Title")]
        public string Title { get; set; }
    }
    public class Entity_Content
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("ContentID")]
        public int ContentID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("SubTitle")]
        public string SubTitle
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Summary")]
        public string Summary
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Description")]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("ImageUrl")]
        public string ImageUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("ThumbImageUrl")]
        public string ThumbImageUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("NormalImageUrl")]
        public string NormalImageUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("CreatedDate")]
        public DateTime CreatedDate
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("CreatedUserID")]
        public int CreatedUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("LastEditUserID")]
        public int? LastEditUserID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("LastEditDate")]
        public DateTime? LastEditDate
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("LinkUrl")]
        public string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("PvCount")]
        public int PvCount
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("State")]
        public bool State
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("ClassID")]
        public int ClassID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Keywords")]
        public string Keywords
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Sequence")]
        public int Sequence
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("IsRecomend")]
        public bool IsRecomend
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("IsHot")]
        public bool IsHot
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("IsColor")]
        public bool IsColor
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("IsTop")]
        public bool IsTop
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Attachment")]
        public string Attachment
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Remary")]
        public string Remary
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("TotalComment")]
        public int TotalComment
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("TotalSupport")]
        public int TotalSupport
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("TotalFav")]
        public int TotalFav
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("TotalShare")]
        public int TotalShare
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("BeFrom")]
        public string BeFrom
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("FileName")]
        public string FileName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Meta_Title")]
        public string Meta_Title
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Meta_Description")]
        public string Meta_Description
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("Meta_Keywords")]
        public string Meta_Keywords
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("SeoUrl")]
        public string SeoUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("SeoImageAlt")]
        public string SeoImageAlt
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("SeoImageTitle")]
        public string SeoImageTitle
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMapping("StaticUrl")]
        public string StaticUrl
        {
            set;
            get;
        }
    }
}