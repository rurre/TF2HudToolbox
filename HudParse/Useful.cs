using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    public static class Useful
    {
        public static string AddTabs(int i)
        {
            string s = "";
            for(int j = 0; j < i; j++)
            {
                s += "\t";
            }
            return s;
        }

        public static string Seek(string s)
        {
            while((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r'))
            {
                s = s.Remove(0,1);
                if(s.Length == 0)
                    break;
                else if(!((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r')))
                    break;
            }
            return s;
        }

        public static string Seek(ref string s)
        {
            return Seek(s);
        }

        public static int SeekGetIndex(string s)
        {
            int i = 0;
            while((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r'))
            {
                s = s.Remove(0,1);
                i++;
                if(s.Length == 0)
                    break;
                else if(!((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r')))
                    break;
            }
            return i;
        }

        public static string GetLine(ref string s)
        {
            return GetLines(1,ref s);
        }
        /// <summary>
        /// Takes a string and removes a given number of lines from it.
        /// </summary>
        /// <param name="nr">Number of lines to take out</param>
        /// <param name="s">Target string</param>
        /// <returns>Returns the removed lines</returns>
        public static string GetLines(int nr,ref string s)
        {
            int foundNewLine = 0;
            string result = "";
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] != '\n')
                {
                    result += s[i];
                    continue;
                }
                foundNewLine++;
                if(foundNewLine == nr)
                    break;
            }
            if(result.Length + 2 <= s.Length)
                s = s.Remove(0,result.Length + 2);
            else s = "";
            if(result.IndexOf('\r') != -1)
                result = result.Replace("\r","");
            return result;
        }

        static string GetKeyValuePair(string s)
        {
            string ss = s;
            string result = "";
            int quoteNr = 0;
            Seek(ref ss);
            bool foundKey = false;
            bool foundInBetween = false;
            string key = "";
            string value = "";
            string inBetween = "";
            bool valueIsBlock = false;

            if(ss != "")
            {
                for(int i = 0; i < ss.Length; i++)
                {
                    if((ss[i] != '\t') && (ss[i] != ' ') && (ss[i] != '\r') && (ss[i] != '\n'))
                    {
                        if(ss[i] == '\"')
                            quoteNr++;
                        if(!foundKey)
                            key += ss[i];
                        else
                        {
                            foundInBetween = true;
                            value += ss[i];
                        }
                    }
                    else
                    {
                        foundKey = true;
                        if(!foundInBetween)
                            inBetween += ss[i];
                        if(foundInBetween && foundKey)
                            break;
                    }
                }
                result = key + inBetween + value;
            }
            ss = ss.Remove(0,result.Length);
            ss = GetLine(ref ss);
            if(ss != "")
                result += ss;
            return result;
        }

        public static string GetCommentHeader(ref string file)
        {
            file = Useful.Seek(ref file);
            string comments = "";
            while((file[0] == '/') && (file[1] == '/'))
            {                
                string ss = "";
                ss += file.Substring(0,(file.IndexOf(Environment.NewLine) + Environment.NewLine.Length));
                file = file.Remove(0,ss.Length);
                comments += ss;
                file = Useful.Seek(ref file);
            }
            return comments;
        }
    }
}
