using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDullCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string srl = "$Y=5";
            Tokenizer tknz = new Tokenizer();
            List<tokens> tk = tknz.Tokenize(srl, srl.Length);
            Parser parser = new Parser();
            AST parsedTree = parser.parseCode(tk, srl);
            Interpreter intp = new Interpreter();
            intp.InterpretTree(parsedTree);
        }
    }
}
