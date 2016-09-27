using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DotNet.Framework.Core.Extends;
namespace DotNet.Framework.Admin.Core.Entity
{
    public class PageInfoEntity
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderField { get; set; }
        public string SortDir { get; set; }

        public PageInfoEntity FormatPageInfo(HttpRequest request)
        {
            PageInfoEntity page = new PageInfoEntity()
            {
                PageIndex = request["pageindex"].ToInt(),
                PageSize = request["pagesize"].ToInt(),
                OrderField = request["orderField"],
                SortDir = request["sortDir"]
            };
            return page;

        }
    }
}
