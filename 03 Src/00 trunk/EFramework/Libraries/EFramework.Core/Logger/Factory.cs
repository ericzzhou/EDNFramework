using System;
using System.Configuration;
using System.IO;

namespace EFramework.Core.Logger
{
    public static class Factory
    {
        private static object _locker = new object();//锁对象
        private static ILog _Log = null;//日志策略

        static Factory()
        {
            Load();
        }

        public static ILog Instance
        {
            get { return _Log; }
        }

        private static void Load()
        {
            try
            {
                _Log = (ILog)Activator.CreateInstance(
                    Type.GetType(ConfigurationManager.AppSettings["LogStrategy"], 
                    false, true));
            }
            catch
            {
                throw new Exception(Resource.FormatStrategyError("日志", "LogStrategy"));
            }
        }

    }
}
