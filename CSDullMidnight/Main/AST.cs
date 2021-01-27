using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDullMidnight.Main
{
    class Node
    {
        public object hold;
        public Node(object holdS)
        {
            hold = holdS;
        }
    }
    class Root
    {
        public string name;
        public List<Node> nodes = new List<Node>();
        
        public Scope rootScope = new Scope();
        public void addNode(object hold)
        {
            nodes.Add(new Node(hold));
        }
        public Root(string nameS, Scope rootScopes)
        {
            name = nameS;
        }
    }
    class AST
    {
       
       public List<Root> roots = new List<Root>();
       public Root addRoot(string name, Scope rootScope)
        {
            Parser prs = new Parser();
            Scope useScope = new Scope();
            if(rootScope == null)
            {
                useScope = prs.globalScope;
            }
            if(rootScope != null)
            {
                useScope = rootScope;
            }
            Root rt = new Root(name, useScope);
            roots.Add(rt);
            return rt;
        }
    }
}
