using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DotNet.Framework.DataAccess.Entity
{
    public class ParameterItem
    {
        public string ParameterName { get; set; }
        public object ParameterValue { get; set; }
        public DbType? DbType { get; set; }
        private ParameterDirection _Direction = ParameterDirection.Input;
        public int? Size { get; set; }
        public ParameterDirection Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }
    }
}
