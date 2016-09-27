using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Core.WebRuntime.ViewObject
{
    [Serializable]
    public class ViewQueryCondition<T>
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public T Condition { get; set; }

        /// <summary>
        /// 分页相关
        /// </summary>
        public ViewPagingInfo PagingInfo { get; set; }
    }
}
