using System;

namespace DotNet.Framework.Core.Web.Data.ViewObject
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ViewPagingInfo
    {
        ///// <summary>
        ///// 输出总数据条数
        ///// </summary>
        //public int TotalCount { get; set; }

        private int _PageIndex = 1;
        private int _PageSize = 10;
        private string _SortDir = "ASC";

        /// <summary>
        /// 当前页码（默认第一页是1）
        /// </summary>
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        /// <summary>
        /// 当前设置的页面大小
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }
        /// <summary>
        /// 排序字段名
        /// </summary>
        public string OrderField { get; set; }

        /// <summary>
        /// 排序方式 DESC/ASC
        /// </summary>
        public string SortDir
        {
            get { return _SortDir; }
            set { _SortDir = value; }
        }
    }
}
