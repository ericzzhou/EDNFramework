using System;

namespace DotNet.Framework.Core.Web.Data.ViewObject
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ViewPagingInfo
    {
        /// <summary>
        /// 输出总数据条数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 当前页码（默认第一页是1）
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 当前设置的页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 排序字段名
        /// </summary>
        public string OrderField { get; set; }
        /// <summary>
        /// 排序方式 DESC/ASC
        /// </summary>
        public string SortDir { get; set; }
    }
}
