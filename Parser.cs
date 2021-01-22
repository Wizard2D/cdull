using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDullCS
{
    class Parser
    {
        public AST parseCode(List<tokens> tk, string code)
        {
            AST newAst = new AST();
            for (int i = 0; i < tk.Count(); i++)
            {
                Console.WriteLine(tk[i]);
                tokens Token = tk[i];
                if (i + 2 < tk.Count())
                {
                    tokens TokenF1 = tk[i + 1];
                    tokens TokenF2 = tk[i + 2];
                    
                    if(Token == tokens.NUMBER && TokenF1 == tokens.PLUS && TokenF2 == tokens.NUMBER)
                    {
                        Root rt = newAst.addRoot("Add");
                        rt.addNode("Number", int.Parse(char.ToString(code[i])));
                        rt.addNode("Number", int.Parse(char.ToString(code[i+2])));
                    }
                    if (Token == tokens.NUMBER && TokenF1 == tokens.MINUS && TokenF2 == tokens.NUMBER)
                    {
                        Root rt = newAst.addRoot("Subtract");
                        rt.addNode("Number", int.Parse(char.ToString(code[i])));
                        rt.addNode("Number", int.Parse(char.ToString(code[i + 2])));
                    }
                    if (Token == tokens.NUMBER && TokenF1 == tokens.DIVIDE && TokenF2 == tokens.NUMBER)
                    {
                        Root rt = newAst.addRoot("Divide");
                        rt.addNode("Number", int.Parse(char.ToString(code[i])));
                        rt.addNode("Number", int.Parse(char.ToString(code[i + 2])));
                    }
                    if (Token == tokens.NUMBER && TokenF1 == tokens.MULTI && TokenF2 == tokens.NUMBER)
                    {
                        Root rt = newAst.addRoot("Multi");
                        rt.addNode("Number", int.Parse(char.ToString(code[i])));
                        rt.addNode("Number", int.Parse(char.ToString(code[i + 2])));
                    }
                    if (Token == tokens.ASSIGN && TokenF1 == tokens.NUMBER)
                    {
                        Console.WriteLine("CGHH");
                        Root rt = newAst.addRoot("Assign");
                        rt.addNode(char.ToString(code[i-1]), 0);
                        rt.addNode("Number", int.Parse(char.ToString(code[i + 2])));
                    }
                }
            }
            return newAst;
        }
    }
}
