using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric.Framework.Account.Model
{
    public class PagedInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int DataCount { get; set; }
    }
}
