using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

//using Trainer.

namespace Test
{
    public class Program
    {
        public static string backendCommand(string paragraph)
        {
            
            Func<string, string> func = new Func<string, string>((x) =>
            {
                var temp = x;
                new HTMLMessager().removeFromLine(ref temp);
                return temp;
            });
            SentenceBoiler sb = new SentenceBoiler();
			DataAccess dA = new DataAccessDB();
            //while (true)
            //{
                //var paragraph = Console.ReadLine();
                var sentences = paragraph.Split('.');
                var qHandler = new QueryHandler(dA,sb, func);
                int max = -99;
                string[] maxStrings = new string[] {""};
                var rString ="";
                Console.WriteLine(sentences.Count() + " "+paragraph.Count());
                foreach (var response in qHandler.handleQuery(sentences))
                {
                    string query = "";
                    foreach (var block in response)
                    {
                        query = block.Item1;
                        var kwList = KeyWordFinder.handleLineKeyWords(5, block.Item1);
                        int occurance = 0;
                        foreach (string s in block.Item2)
                        {
                            foreach (string kw in kwList)
                            {
                                occurance = occurance + Regex.Matches(s, kw).Count;
                            }

                        }
                        maxStrings = occurance > max ? block.Item2 : maxStrings;//average hits per element
                        max = occurance > max ? occurance : max;
                    }
                    Console.WriteLine("Hits for query: " + "\"" + query + "\"");
                    rString = rString + "Hits for query: " + "\"" + query + "\"\n";
                    foreach (string s in maxStrings)
                    {
                        rString = rString + s + "\n";
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    //return rString + "\n";
                //}   
            }
            return rString;
        }
    }
}
