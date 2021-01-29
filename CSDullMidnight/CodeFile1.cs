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
            string input =
            "funfunc start\n" +
            "log(\"Hoowwwoooo\");\n" +
            ":\n" +
            "main start\n" +
                "log(\"Hello Worldefeq\");\n" +
                "call funfunc\n"+
            ":\n";

            List<tokens> tokens = new Tokenizer().TokenizeWithKeywords(input);
            
            AST ast = new Parser().parseTokens(tokens, input);
            string output = new Transpiler().TranspileToCPP(ast);
            string newStr =  output.Replace("auto main", "int main");
            File.AppendAllText("output.txt", newStr);
        }
    }
}