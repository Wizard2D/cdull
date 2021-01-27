﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
//Remember that lists start at 0, not 1....
namespace CSDullMidnight.Main
{
    class Transpiler
    {
        Parser psr = new Parser();
        public string TranspileToCPP(AST tree)
        {
            string fullCode = "#include <iostream>\n";
            for(int c = 0; c<tree.roots.Count; c++)
            {
                Console.WriteLine(tree.roots[c].name);
            }
            for(int i = 0; i < tree.roots.Count; i++)
            {
                List<Root> rts = tree.roots;
                if(rts[i].name == "function")
                {
                    if(String.Equals("main", rts[i].nodes[0].hold))
                    {
                        Console.WriteLine("Maine");
                        fullCode += "int main()\n";
                    }
                    fullCode += "auto " + rts[i].nodes[0].hold + "()\n";
                }
                if(rts[i].name == "Assign")
                {
                    fullCode += "auto " + rts[i].nodes[0].hold + " = " + rts[i].nodes[1].hold;
                }
                if(rts[i].name == "SoS")
                {
                    fullCode += "{\n";
                }
                if(rts[i].name == "Log")
                {
                    fullCode += "std::cout << \"" + rts[i].nodes[0].hold + "\";\n";
                }
                if (rts[i].name == "EoS")
                {
                    fullCode += "}\n";
                }
                if (rts[i].name == "Add")
                {
                    fullCode += "std::cout <<" + rts[i].nodes[0].hold + "+" + rts[i].nodes[1].hold+";\n";
                }
            }
            return fullCode;
        }
    }
}
