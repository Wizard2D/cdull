using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDullCS
{
    class Node
    {
        public string val;
        public int value;

        public Node(string valS, int valueS)
        {
            val = valS;
            value = valueS;
        }
    }
    class Root
    {
        public string name;
        public List<Node> nodes = new List<Node>() { };
        public void addNode(string val, int value)
        {
            nodes.Add(new Node(val, value));
        }
    }

    class AST
    {
        public List<Root> roots = new List<Root>(){};

        public Root addRoot(string name)
        {
            Root newRoot = new Root();
            newRoot.name = name;
            roots.Add(newRoot);
            return newRoot;
        }
    }
}
