using DotNet.Framework.dbJob;
using DotNet.Framework.JobInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DotNet.Framework.JobTestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            JobContext context = new JobContext();
            
            JobTest.JobTest jobfile = new JobTest.JobTest();
            jobfile.Run(context);

            //JobMain jobDb = new JobMain();
            //jobDb.Run(context);
        }
    }
}
