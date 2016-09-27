
using System;
namespace EFramework.Core.Logger
{
    public interface ILog
    {
        void Wirte(string log);
        void Wirte(Exception ex);

    }
}
