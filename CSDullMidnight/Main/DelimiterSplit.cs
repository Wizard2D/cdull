using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
namespace CSDullMidnight.Main
{
    class DelimiterSplit
    {
        public string[] delimiters()
        {
            string[] resl = { };
            string delimiters = "! ( ) < > [ ] { } - . , \n \r \t ;";
            if (delimiters != null)
            {
                resl = delimiters.Split(' ');
            }
            else
            {
                Console.WriteLine("wtf that's not suppost to happen.....");
            }
            return resl;
        }
        public string[] SplitInto(string code)
        {
            string[] block = { };
            string[] delimiters = this.delimiters();
            if(code != null)
            {
                for (int i = 0; i < delimiters.Length; i++)
                {
                    Regex rgx = new Regex("(?=" + "\\"+Char.Parse(delimiters[i]) + ")");
                    block = rgx.Split(code);
                }
            }
            return block;
        }
    }
}
