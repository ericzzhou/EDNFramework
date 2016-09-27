using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Core.Web.Data.ViewObject
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResult<T>
    {
        /// <summary>
        /// 输出总数据条数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 分页相关
        /// </summary>
        public ViewPagingInfo PagingInfo { get; set; }

        /// <summary>
        /// 查询结果 ，一般是 IList
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 重写ToString() 方法，返回pqgrid需要的josn字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            PGGridDataSource source = new PGGridDataSource();
            source.totalRecords = this.TotalCount;

            if (this.PagingInfo == null)
            {
                this.PagingInfo = new ViewPagingInfo();
            }
            source.curPage = this.PagingInfo.PageIndex;

            source.data = this.Result;
            return ObjectJsonSerializer.Serialize_NewTon<PGGridDataSource>(source);
        }
    }

    [Serializable]
    public class PGGridDataSource
    {
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int totalRecords { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int curPage { get; set; }
        /// <summary>
        /// 查询结果
        /// </summary>
        public object data { get; set; }
    }
}
