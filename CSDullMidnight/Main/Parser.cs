using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace CSDullMidnight.Main
{
    class Parser
    {
        public Scope globalScope = new Scope();
        public AST parseTokens(List<tokens> tkns, string code)
        {
            AST tree = new AST();
            
            for (int i = 0; i<tkns.Count; i++)
            {
                if (i + 2 < tkns.Count)
                {
                    Scopes scp = new Scopes();
                    tokens curToken = tkns[i];
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.PLUS && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Add", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i+2]);
                        Console.WriteLine(tree.ToString());
                    }
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MINUS && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Sub", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i + 2]);
                        Console.WriteLine(tree.ToString());
                    }
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MULTI && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Multi", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i + 2]);
                        Console.WriteLine(tree.ToString());
                    }
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.DIVIDE && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Divide", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i + 2]);
                        Console.WriteLine(tree.ToString());
                    }
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.POW && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Pow", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i + 2]);
                        Console.WriteLine(tree.ToString());
                    }
                    if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MOD && tkns[i + 2] == tokens.NUMBER)
                    {
                        Root rtt = tree.addRoot("Mod", scp.currentScope);
                        rtt.addNode(code[i]);
                        rtt.addNode(code[i + 2]);
                        Console.WriteLine(tree.ToString());
                    }
                    
                    if(curToken == tokens.VARIABLE)
                    {
                        Console.WriteLine(tree.ToString());
                        Regex var = new Regex("var\\s*\\w*\\s*=[^=]*");
                        
                        MatchCollection mtcl = var.Matches(code);
                        List<string> found = new List<string>();
                        for(int t=0; t<mtcl.Count; t++)
                        {
                            found.Add(mtcl[t].ToString());
                        }
                        string variableName = "";
                        string varSet = "";
                        Regex rxb = new Regex("\\s=.*");
                        Regex rxbb = new Regex("\\s\\w.*");
                        for (int j = 0; j < found.Count; j++)
                        {
                            string chk = found[j].ToString();
                            string chkName = rxb.Replace(chk.Replace("var ", ""), "");
                            variableName = chkName;
                            string chkSet = rxbb.Replace(chk.Replace("var ", ""), "");
                            varSet = chkSet;
                            if (!scp.currentScope.variables.Contains(variableName))
                            {
                                scp.currentScope.variables.Add(variableName);
                                Root rtt = tree.addRoot("Assign", scp.currentScope);
                                rtt.addNode(variableName);
                                rtt.addNode(varSet);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Attempt to redefine variable " + variableName);
                                return null;
                            }

                        }
                        
                    }
                    if(curToken == tokens.SCOPE_START)
                    {
                        Console.WriteLine(tree.ToString()+"Loggo");
                        Regex funcN = new Regex("\\s*\\w+\\s*start\\s*");
                        Regex funcNT = new Regex("(?: start)");
                        MatchCollection matc = funcN.Matches(code);
                        Console.WriteLine(matc.Count);
                        for(int x = 0; x<matc.Count; x++)
                        {
                            Console.WriteLine(tree.ToString() + "Loggoh");
                            string trimmed = funcNT.Replace(matc[x].ToString(), "");
                            Root rtt = tree.addRoot("function", scp.currentScope);
                            rtt.addNode(trimmed);
                        }
                        
                    }
                    if (curToken == tokens.SCOPE_START)
                    {
                        Scope scope = new Scope();
                        scp.push(scope);
                        tree.addRoot("SoS", scp.currentScope);
                        Console.WriteLine(tree.ToString());
                    }
                   
                    if (curToken == tokens.LOG)
                    {
                        Console.WriteLine(tree.ToString()+"Log1");
                        Regex rgxrep = new Regex("[()\";]");
                        Console.WriteLine(tree.ToString() + "Log2");
                        Regex rgxcp = new Regex("log\\S*\\s*\\S*");
                        Console.WriteLine(tree.ToString() + "Log3");
                        MatchCollection trox = rgxcp.Matches(code);
                        Console.WriteLine(tree.ToString() + "Log4");
                        for (int k = 0; k<trox.Count; k++)
                        {
                            Console.WriteLine(tree.ToString() + "Log5");
                            string trm = trox[k].ToString().Replace("log", "");
                            Console.WriteLine(tree.ToString()+"Log6");
                            string trimmed = rgxrep.Replace(trm, ""); 
                            Console.WriteLine(tree.ToString() + "Log7");
                            Root rtt = tree.addRoot("Log", scp.currentScope);
                            Console.WriteLine(tree.ToString() + "Log9");
                            rtt.addNode(trimmed);
                            Console.WriteLine(tree.ToString() + "Log10");
                        }
                        Console.WriteLine(tree.ToString() + "Log11");
                    }
                    if (curToken == tokens.SCOPE_END)
                    {
                        tree.addRoot("EoS", scp.currentScope);
                        scp.pop_out();
                        
                        Console.WriteLine(tree.ToString() + "END");
                    }
                }

            }
            return tree;
        }
    }
}
