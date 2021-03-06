using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


////maybe store all these private methods in a helper module
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Test
{
    class ParserWrapper
    {
        Dictionary<string, ParsedCHM> parsedCHMs;
        //ActiveAIDDB db;

        public ParserWrapper(string filePath)
        {
            parsedCHMs = new Dictionary<string, ParsedCHM>();
            parsedCHMs[filePath] = new ParsedCHM(filePath);
        }

        public ParserWrapper(List<string> filePaths)
        {
            foreach (string file in filePaths)
            {
                parsedCHMs[file] = new ParsedCHM(file);
            }
        }

      /* private void insertBlocksIntoDB(string filePath, List<List<Element>> blocks)
        {
            foreach (List<Element> block in blocks)
            {
                int blockCount = 0;
                foreach (Element element in block)
                {
                    if (element.name == "img")
                    {
                        //NEED A MEANS TO RETRIEVE ID
                        ;//db.insertIntoImages();
                    }
                    else
                    {
                        //NEED A MEANS TO RETRIEVE ID
                        db.insertIntoElements(filePath, blockCount, element.data);
                    }
                    ++blockCount;
                }
            }
        }

      private void insertHREFSOIntoDB(string filePath, List<string> hrefs)
        {
            foreach (string href in hrefs)
            {
                //NEED A MEANS TO RETRIEVE ID
                db.insertIntoHyperlinks(filePath, href);
            }
        }

        public void persistData()
        {
            ActiveAIDDB db = new ActiveAIDDB();
            db.insertIntoFiles(title, "");

            foreach (KeyValuePair<string, ParsedCHM> pair in parsedCHMs)
            {
                insertBlocksIntoDB(pair.Key, pair.Value.blocks);
                insertHREFSOIntoDB(pair.Value.title, pair.Value.hrefs);
            }
        }*/

        public void genModel()
        {
            List<List<string>> fileKeyWords = new List<List<string>>();
            List<string> responseFileNames = new List<string>();
            string response;
            foreach (var pair in parsedCHMs)
            {
                List<string> keywords = new List<string>(); 
                responseFileNames.Add(pair.Key);
                keywords.AddRange(KeyWordFinder.handleLineKeyWords(5,pair.Value.title));//keywords weighted by ordering in which they appear in list
                keywords.AddRange(KeyWordFinder.concatAllKeyWords(5, pair.Value.blocks, keywords));
                fileKeyWords.Add(keywords);
            }
            response = String.Join(";", responseFileNames.ToArray());
            //aggregateKeyWords(fileKeyWords)
            //Console.WriteLine(response);
            /*foreach (string keyword in keywords)
            {
                Console.WriteLine(keyword);
            }*/
        }
    }
}

