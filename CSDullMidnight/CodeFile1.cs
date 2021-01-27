using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CSDullMidnight.Main;
using System.IO;
namespace CSDullMidnight
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRun = "congrats start\n" +
            "log(\"Hello Worldefeq\");\n" +
            "~\n";
            
            Console.WriteLine(toRun);
            Tokenizer tknzr = new Tokenizer();
            List<tokens> tkn = tknzr.TokenizeWithKeywords(toRun);
            Parser parser = new Parser();
            AST tree = parser.parseTokens(tkn, toRun);
            Transpiler tspl = new Transpiler();
            string str = tspl.TranspileToCPP(tree);
            str += "----Tokens----\n";
            for(int i = 0; i<tkn.Count; i++)
            {
                str += tkn[i] + "\n";
            }
            File.AppendAllText("output.txt", str);
            Console.ReadLine();
        }
    }
}