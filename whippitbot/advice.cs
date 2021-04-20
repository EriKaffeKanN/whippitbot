using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace whippitbot
{
    class Advice
    {
        private static string JsonSearch(string content, string key)
        {
            string[] splitContent = content.Split('"', ':', ',');
            splitContent = splitContent.Where(val => val != "" && val != " ").ToArray();
            for (int s = 0; s < splitContent.Length; s++)
            {
                if(splitContent[s] == key)
                {
                    string returnStr = groupLines(splitContent, s + 1);
                    return returnStr;
                }
            }
            return "";
        }

        private static string groupLines(string[] content, int index)
        {
            string str = "";
            str += content[index];
            while(!(content[index + 1] == "type"))
            {
                str += content[index + 1];
                index++;
            }
            str = str.Replace("\n", " ");
            str = str.Replace(@"\", "");
            return str;
        }

        public static string get()
        {
            WebClient client = new WebClient();
            string pageContent = client.DownloadString("https://inspirobot.me/api?generateFlow=1");
            string advice = JsonSearch(pageContent, "text");
            return advice;
        }

        public static string getImage()
        {
            WebClient client = new WebClient();
            string pageContent = client.DownloadString("https://inspirobot.me/api?generate=true");
            return pageContent;
        }
    }
}
