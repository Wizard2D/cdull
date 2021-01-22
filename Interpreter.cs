using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDullCS
{
    class Interpreter
    {
        public bool InterpretTree(AST tree)
        {
            bool isOk = true;
            for (int i = 0; i < tree.roots.Count(); i++)
            {
                List<Root> roots = tree.roots;
                if (i < roots.Count)
                {
                    if (roots[i].name == "Add" && roots[i].nodes[0] != null && roots[i].nodes[1] != null)
                    {
                        Console.WriteLine(roots[i].nodes[1].value + roots[i].nodes[1].value);
                    }
                    if (roots[i].name == "Subtract" && roots[i].nodes[0] != null && roots[i].nodes[1] != null)
                    {
                        Console.WriteLine(roots[i].nodes[1].value - roots[i].nodes[1].value);
                    }
                    if (roots[i].name == "Multi" && roots[i].nodes[0] != null && roots[i].nodes[1] != null)
                    {
                        Console.WriteLine(roots[i].nodes[0].value * roots[i].nodes[1].value);
                    }
                    if (roots[i].name == "Divide" && roots[i].nodes[0] != null && roots[i].nodes[1] != null)
                    {
                        Console.WriteLine(roots[i].nodes[0].value / roots[i].nodes[1].value);
                    }
                    if (roots[i].name == "Assign" && roots[i].nodes[0] != null && roots[i].nodes[1] != null)
                    {
                        Console.WriteLine("CGHY");
                        Console.WriteLine("Assigned "+ roots[i].nodes[1].value+" to "+ roots[i].nodes[0].val);
                    }
                }

            }            return isOk;
        }
    }
}
