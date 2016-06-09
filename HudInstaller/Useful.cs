using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    public static class Useful
    {
        /// <summary>
        /// Adds tabs to the beginning of string
        /// </summary>
        /// <param name="i">Number of tabs to add</param>
        /// <returns></returns>
        public static string AddTabs(int i)
        {
            string s = "";
            for(int j = 0; j < i; j++)
            {
                s += "\t";
            }
            return s;
        }
        /// <summary>
        /// Remove tabs, spaces, carriage returns and newlines from start of string
        /// </summary>
        /// <param name="s">String to seek</param>
        /// <returns></returns>
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
        /// <summary>
        /// Seek string and return number of characters removed
        /// </summary>
        /// <param name="s">String to seek</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get comments from beginning of file
        /// </summary>
        /// <param name="file">File to get from</param>
        /// <returns></returns>                      
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

        /// <summary>
        /// Get key, value or tag.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get files in a directory by path
        /// </summary>
        /// <param name="path">Path to look in</param>
        /// <param name="s">Options to look in subfolders or only top folder</param>
        /// <param name="extensions">Extensions to look for, with or without dot</param>
        /// <returns></returns>
        public static string[] GetFiles(string path,SearchOption s,string[] extensions)
        {
            for(int i = 0; i < extensions.Length; i++)
            {
                if(extensions[i].IndexOf(".") == -1)
                    extensions[i] = "*." + extensions[i];
                else
                {
                    if(extensions[i].IndexOf("*") == -1)
                        extensions[i] = "*" + extensions[i];
                }
            }

            List<string> l = new List<string>();
            for(int i = 0; i < extensions.Length; i++)
            {
                l.AddRange(Directory.GetFiles(path,extensions[i],s));
            }
            return l.ToArray();
        }

        /// <summary>
        /// Remove numbers off the end of a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StripEndNumbers(string s)
        {
            var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };            
            var result = s.TrimEnd(digits);
            return s;
        }
    }
}
