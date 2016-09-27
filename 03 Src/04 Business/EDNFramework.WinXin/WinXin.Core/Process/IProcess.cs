using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.WinXin.Core.Process
{
    public interface IProcess
    {
        string Process(WinXinMessage message, string sourceXml);
    }
}
