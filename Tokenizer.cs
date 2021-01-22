using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDullCS
{
    enum state
    {
        STATE_DEF,
        STATE_STR,
        STATE_COM
    };
    class Tokenizer
    {
        public List<tokens> Tokenize(string Rd, int size)
        {
            List<tokens> tks = new List<tokens> { };
            state state = state.STATE_DEF;
            for (int i = 0; i < size; i++)
            {
                
                    char c = Rd[i];
                 //[Three chars further]
                if (c == '@')
                {
                    state = state.STATE_COM;
                }
                if (c == '"')
                {
                    state = state.STATE_STR;
                }
                if (c != '@' && c != '"')
                {
                    state = state.STATE_DEF;
                }

                    switch (state)
                    {
                        case state.STATE_DEF:
                        if (i + 1 <= Rd.Length)
                        {
                            int res = 0;
                            if (int.TryParse(char.ToString(c), out res) == true)
                            {
                                Console.WriteLine("CGahfH");
                                tks.Add(tokens.NUMBER);
                            }
                            if (c == '+')
                            {
                                tks.Add(tokens.PLUS);
                            }
                            if (c == '-')
                            {
                                tks.Add(tokens.MINUS);
                            }
                            if (c == '*')
                            {
                                tks.Add(tokens.MULTI);
                            }
                            if (c == '/')
                            {
                                tks.Add(tokens.DIVIDE);
                            }
                            if(c == '$')
                            {
                                continue;
                            }
                                if (Rd[i - 1] == '$')
                                {
                                    
                                continue;
                                }
                            if (c == '=')
                            {
                                tks.Add(tokens.ASSIGN);
                            }
                            if (c == ' ')
                            {
                                i++;
                                continue;
                            }
                    }
                        break;
                    case state.STATE_COM:
                        int nI = i;
                        while(c != '\n')
                        {
                            nI++;
                            c = Rd[nI];
                        }
                        i = nI;
                        break;
                }
            }
            return tks;
        }
    }
}
