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
            
            for (int i = 0; i < tkns.Count; i++)
            {
                Console.WriteLine(tkns[i]);
                Scopes scp = new Scopes();
                tokens curToken = tkns[i];

                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.PLUS && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Add", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }
                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MINUS && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Sub", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }
                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MULTI && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Multi", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }
                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.DIVIDE && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Divide", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }
                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.POW && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Pow", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }
                if (curToken == tokens.NUMBER && tkns[i + 1] == tokens.MOD && tkns[i + 2] == tokens.NUMBER)
                {
                    Root rtt = tree.addRoot("Mod", scp.currentScope);
                    rtt.addNode(code[i]);
                    rtt.addNode(code[i + 2]);
                }

                if (curToken == tokens.VARIABLE)
                {
                    Regex var = new Regex("var\\s*\\w*\\s*=[^=]*");

                    MatchCollection mtcl = var.Matches(code);
                    List<string> found = new List<string>();
                    for (int t = 0; t < mtcl.Count; t++)
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

                            return null;
                        }

                    }

                }
                if (curToken == tokens.SCOPE_START)
                {
                    Regex funcN = new Regex("\\s*\\w+\\s*start\\s*");
                    Regex funcNT = new Regex("(?: start)");
                    Regex funcParam = new Regex("\\S+\\s+start\\:.*");
                    Regex funcParam1 = new Regex("\\s*\\w+\\s*start\\s*\\:\\s+");
                    Regex omitParenthesis = new Regex("[()]");
                    Regex varName = new Regex("var\\s+");
                    MatchCollection matc = funcN.Matches(code);
                    for (int x = 0; x < matc.Count; x++)
                    {
                        Root rtt = tree.addRoot("function", scp.currentScope);
                        
                        string trimmed = funcNT.Replace(matc[x].ToString(), "");
                        
                        rtt.addNode(trimmed);
                        if (funcParam.IsMatch(code) == true)
                        {
                            string almThere = funcParam1.Replace(code, "");
                            string closer = omitParenthesis.Replace(almThere, "");
                            string oooh = closer.Replace(',', ' ');
                            string[] split = oooh.Split(' ');
                            for (int q = 0; q < split.Length; q++)
                            {
                                string vName = varName.Replace(split[q], "");
                                rtt.addNode(vName);
                            }
                        }
                    }

                }
                if (curToken == tokens.SCOPE_START)
                {
                    Scope scope = new Scope();
                    scp.push(scope);
                    tree.addRoot("SoS", scp.currentScope);
                }
                if (curToken == tokens.CALLFUNC)
                {
                    Regex cbbb = new Regex("(?:call\\s*\\S*)");
                    Regex cbmf = new Regex("(?:call\\s*)");
                    MatchCollection mcl = cbbb.Matches(code);
                    for(int b = 0; b<mcl.Count; b++)
                    {
                        string funcName = cbmf.Replace(mcl[b].ToString(), "");
                        Root rtt = tree.addRoot("Call", scp.currentScope);
                        rtt.addNode(funcName);
                    }
                }
                if (curToken == tokens.LOG)
                {
                    Regex rgxrep = new Regex("[()\";]");
                    Regex rgxcp = new Regex("log\\S*\\s*\\S*");
                    MatchCollection trox = rgxcp.Matches(code);
                    
                        string trm = trox[0].ToString().Replace("log", "");

                        string trimmed = rgxrep.Replace(trm, "");

                        Root rtt = tree.addRoot("Log", scp.currentScope);
                       
                        rtt.addNode(trimmed);

                    

                }

                if (curToken == tokens.SCOPE_END)
                {
                    tree.addRoot("EoS", scp.currentScope);

                    scp.pop_out();
                }
                if(curToken == tokens.CINCLUDE)
                {
                    tree.addRoot("cinc", scp.currentScope);
                }
            }
            
            return tree;
        }
    }
}