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
            string input = File.ReadAllText("input.txt");
            /*"funfunc start\n" +
            "log(\"Hoowwwoooo\");\n" +
            ":\n" +
            "main start\n" +
                "log(\"Hello Worldefeq\");\n" +
                "call funfunc\n"+
            ":\n";*/


            string newStr = "";
            DelimiterSplit ds = new DelimiterSplit();
            string[] nbm = ds.SplitInto(input);
            Tokenizer tknzd = new Tokenizer();
            Parser prsr = new Parser();
            Transpiler trnsp = new Transpiler();
            for(int i=0; i<nbm.Length; i++)
            {
                Regex inc = new Regex("&in\\s+.*");
                Regex strIn = new Regex("[\"]");
                Regex incr = new Regex("&in\\s+");
                MatchCollection mth = inc.Matches(nbm[i]);
                for(int x = 0; x < mth.Count; x++) {
                    Console.WriteLine("HELLO1");
                    string filePathSTR = incr.Replace(mth[x].ToString(), "");
                    string filePath = Path.GetFullPath(strIn.Replace(filePathSTR, ""));
                    string fileContent = File.ReadAllText(filePath);
                    nbm[i] = inc.Replace(mth[x].ToString(), fileContent);
                    Console.WriteLine("HELLO2");
                }
                
                List<tokens> tknzl = tknzd.TokenizeWithKeywords(nbm[i]);
                AST tree = prsr.parseTokens(tknzl, nbm[i]);
                string output = trnsp.TranspileToCPP(tree);
                string.Concat(newStr, output);
                Regex imain = new Regex("auto\\s+main");
                newStr = imain.Replace(output, "int main");
                for(int p=0; p<nbm.Length; p++)
                    Console.WriteLine(nbm[p]);
                File.AppendAllText("output.txt", newStr);
            }

           
        }
    } 
}