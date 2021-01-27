using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDullMidnight.Main
{
    class Scopes
    {
        Parser prs = new Parser();
        public IContext currentScopeContext = new IContext();
        public Scope currentScope = new Scope();
        public List<Scope> scopes = new List<Scope>();
        public void push(Scope sc)
        {
            currentScopeContext.SetContext(sc.scopeID.ToString());
            currentScope = sc;
        }
        public void pop_out()
        {
            currentScope = prs.globalScope;
            currentScopeContext.SetContext(prs.globalScope.scopeID);
        }
    }
    class Scope
    {
        public string scopeID;
        public string[] symbols;
        public List<string> variables = new List<string>();
        public Scope()
        {
           scopeID = Guid.NewGuid().ToString();
        }
    }
}
