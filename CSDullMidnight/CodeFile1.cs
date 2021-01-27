using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CSDullMidnight.Main;

namespace CSDullMidnight
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRun = "congrats start\n" +
            "log(\"Hello Worldefeq\");\n" +
            "var x = 50\n" +
            "end\n";
            Console.WriteLine(toRun);
            Tokenizer tknzr = new Tokenizer();
            List<tokens> tkn = tknzr.TokenizeWithKeywords(toRun);
            Parser parser = new Parser();
            AST tree = parser.parseTokens(tkn, toRun);
            Transpiler tspl = new Transpiler();
            Console.WriteLine(tspl.TranspileToCPP(tree));
        }
    }
}