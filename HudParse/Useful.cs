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
            if(s != "")
            {
                while((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r'))
                {
                    s = s.Remove(0,1);
                    if(s.Length == 0)
                        break;
                    else if(!((s.First() == '\t') || (s.First() == '\n') || (s.First() == ' ') || (s.First() == '\r')))
                        break;
                }
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
            if(file == "")
                return "";
            string comments = "";
            while((file[0] == '/') && (file[1] == '/'))
            {
                string ss = "";
                int index;
                if((index = file.IndexOf(Environment.NewLine)) == -1)
                    index = file.Length;
                else
                    index += Environment.NewLine.Length;
                ss += file.Substring(0,index);
                file = file.Remove(0,ss.Length);
                comments += ss;
                file = Useful.Seek(ref file);

                if(file == "")
                    break;
            }           
            return comments;
        }

        public static string GetElement(ref string file)
        {
            string s = file;
            string ss = "";
            bool spaceTerminates = true;
            for(int i = 0; i <= file.Length; i++)
            {
                if(s == "")
                    break;
                if(s[0] == '\"')
                {
                    if(spaceTerminates)
                    {
                        spaceTerminates = false;
                        s = s.Remove(0,1);
                    }
                    else
                    {
                        s = s.Remove(0,1);
                        s = Useful.Seek(ref s);
                        break;
                    }
                }

                if((s[0] == ' ') || (s[0] == '\t'))
                {
                    if(spaceTerminates)
                    {
                        s = Seek(ref s);
                        break;
                    }
                }
                else if((s[0] == '\r') && (s[1] == '\n'))
                {
                    s = s.Remove(0,2);
                    break;
                }
                else if((s[0] == '{') || (s[0] == '}'))
                    break;

                ss += s[0];
                s = s.Remove(0,1);
            }
            file = s;
            if(ss == "")
                return null;
            else
                return ss;
        }
    }
}
