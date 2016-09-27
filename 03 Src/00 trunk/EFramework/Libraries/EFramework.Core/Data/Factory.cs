using EFramework.Core.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EFramework.Core.Data
{
    public static class Factory
    {
        private static object _locker = new object();//锁对象
        private static IDataStrategy _Data = null;//日志策略

        static Factory()
        {
            Load();
        }

        public static IDataStrategy Instance
        {
            get { return _Data; }
        }

        private static void Load()
        {
            try
            {
                _Data = (IDataStrategy)Activator.CreateInstance(
                    Type.GetType(ConfigurationManager.AppSettings["DataStrategy"],
                    false, true));
            }
            catch
            {
                throw new Exception(Resource.FormatStrategyError("数据", "DataStrategy"));
            }
        }
    }
}
