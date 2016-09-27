using System;

namespace DotNet.Framework.Core.Web.Data.ViewObject
{
    /// <summary>
    /// 带分页参数查询条件接收实体
    /// </summary>
    /// <typeparam name="T">查询条件实体</typeparam>
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
