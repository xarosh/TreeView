using System.Collections.Generic;

namespace TreeView.Bootstrapping
{
    public class BootstrapParameters
    {
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, object> category { get; set; }

        public BootstrapParameters()
        {
            Parameters = new Dictionary<string, object>();
            category = new Dictionary<string, object>();
        }
        public object this[string key]
        {
            get
            {
                return Parameters[key];
            }
            set
            {
                Parameters[key] = value;
            }
        } 
    }
}
