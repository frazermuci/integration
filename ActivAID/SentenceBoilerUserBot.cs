﻿using System.Threading.Tasks;
using Syn.Bot.Siml;
using System.IO;
using System;

namespace Test
{
    public class SentenceBoilerUserBot : SentenceBoiler
    {
        public override string boilDown(string sentence)
        {
            int max = -1;
            string maxFile = "";
            string path = "SynBotDir";
            foreach (string fileName in System.IO.Directory.EnumerateFiles(path)) //maybe don't hard code
            {
                Console.WriteLine(fileName + "file");
                SimlBot Chatbot = new SimlBot();
                Chatbot.PackageManager.LoadFromString(File.ReadAllText(fileName));
                var result = Chatbot.Chat(sentence);
                string outString = result.BotMessage;
                if (!outString.Contains(";"))
                {
                    continue;
                }                
                string[] output = result.BotMessage.Split(';');
                var lastString = output[output.Length-2];
                var response = lastString.Split(':');
                int test = Convert.ToInt32(response[0]);
                maxFile = max < test ? response[1] : maxFile;
                max = max < test ? test : max;
            }
            //return new Tuple<string,bool>(maxFile, true);
            return maxFile;
        }
    }
}