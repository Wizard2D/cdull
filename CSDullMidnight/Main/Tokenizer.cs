using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace CSDullMidnight.Main
{
    enum tokens
    {
        PLUS,
        DIVIDE,
        MINUS,
        MULTI,
        MOD,
        POW,
        ASSIGN,
        QUOT,
        NUMBER,
        //Keywords:
        SCOPE_START,
        SCOPE_END,
        VOID,
        VARIABLE,
        LOG
    }

    class Tokenizer
    {
        IContext Context = new IContext();
        enum state
        {
            DEFAULT,
            STRING,
            COMMENT
        }
        public List<tokens> Tokenize(string code, int size)
        {
            Context.SetContext("0");
            List<tokens> tkn = new List<tokens>();
            state tknState = state.DEFAULT;
            for(int i=0; i<size; i++)
            {
                
                char c = code[i];
                if(c == '@')
                    tknState = state.COMMENT;
                if (c == '"')
                    tknState = state.STRING;
                    tkn.Add(tokens.QUOT);
                if (c != '@' && c != '"')
                    tknState = state.DEFAULT;
                switch (tknState) {
                    case state.STRING:
                        i++;
                        while(c != '"')
                            continue;
                        tkn.Add(tokens.QUOT);
                        break;
                    case state.DEFAULT:
                        int outp = 0;
                        if(int.TryParse(char.ToString(c), out outp) == true)
                            tkn.Add(tokens.NUMBER);
                        if(c == '+')
                            tkn.Add(tokens.PLUS);
                        if (c == '-')
                            tkn.Add(tokens.MINUS);
                        if (c == '*')
                            tkn.Add(tokens.MULTI);
                        if (c == '/')
                            tkn.Add(tokens.DIVIDE);
                        if (c == '^')
                            tkn.Add(tokens.POW);
                        if (c == '%')
                            tkn.Add(tokens.MOD);
                        if (c == '=')
                            tkn.Add(tokens.ASSIGN);
                        break;
                    case state.COMMENT:
                        while(c != '\n')
                            continue;
                        break;
                }
            }
            return tkn;
        }
        public List<tokens> TokenizeWithKeywords(string code)
        {
            List<tokens> tkn = new List<tokens>();
            state tknState = state.DEFAULT;
            for(int i = 0; i < code.Length; i++)
            {
                char c = code[i];
                if (c == '@')
                    tknState = state.COMMENT;
                if (c == '"')
                    tknState = state.STRING;
                    tkn.Add(tokens.QUOT);
                if (c != '@' && c != '"')
                    tknState = state.DEFAULT;
                switch (tknState) {
                    case state.STRING:
                        break;
                    case state.DEFAULT:
                        int outp = 0;
                        if (int.TryParse(char.ToString(c), out outp) == true)
                            tkn.Add(tokens.NUMBER);
                        if(i + 5 < code.Length)
                        {
                            string fivechars = "";
                            for(int x = 0; x < 5; x++)
                                fivechars += code[i + x];
                            string fourchars = "";
                            for (int x = 0; x < 4; x++)
                                fourchars += code[i + x];
                            string threechars = "";
                            for (int x = 0; x < 3; x++)
                                threechars += code[i + x];
              
                            if (fivechars.Contains("start"))
                                tkn.Add(tokens.SCOPE_START);
                            if (fourchars.Contains("void"))
                                tkn.Add(tokens.VOID);
                            
                            if (threechars.Contains("var"))
                                tkn.Add(tokens.VARIABLE);
                            if (threechars.Contains("log"))
                                tkn.Add(tokens.LOG);
                        }
                        if (c == '+')
                            tkn.Add(tokens.PLUS);
                        if (c == '~')
                            tkn.Add(tokens.SCOPE_END);
                        if (c == '-')
                            tkn.Add(tokens.MINUS);
                        if (c == '*')
                            tkn.Add(tokens.MULTI);
                        if (c == '/')
                            tkn.Add(tokens.DIVIDE);
                        if (c == '^')
                            tkn.Add(tokens.POW);
                        if (c == '%')
                            tkn.Add(tokens.MOD);
                        if (c == '=')
                            tkn.Add(tokens.ASSIGN);
                        if(c == '\n' || c == '\r' || c == '\t')
                            continue;
                        if (c == '"')
                            tkn.Add(tokens.QUOT);
                        if(c == '(')
                            continue;
                        if (c == ')')
                            continue;
        
                        break;
                    case state.COMMENT:
                        while (c != '\n')
                            continue;
                        break;
                }
            }
            return tkn;
        }
    }
}