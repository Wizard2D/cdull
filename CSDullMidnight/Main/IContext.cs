using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDullMidnight.Main
{
    class IContext
    {
        public string currentContext;
        public int contextId;
        
        public void SetContext(string Context)
        {
            currentContext = Context;
            contextId = Context.Length / 2;
        }
    }
}
