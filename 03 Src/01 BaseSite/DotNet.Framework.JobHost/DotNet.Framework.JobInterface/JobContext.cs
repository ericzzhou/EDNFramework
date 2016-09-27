using System.Collections.Generic;

namespace DotNet.Framework.JobInterface
{
    public class JobContext
    {
        public JobContext()
        {
            if (this._Properties == null)
            {
                this._Properties = new Dictionary<string, string>();
            }
        }

        private Dictionary<string, string> _Properties;

        public Dictionary<string, string> Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }
    }
}
