using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Core.WebRuntime.ViewObject
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

    }
}
