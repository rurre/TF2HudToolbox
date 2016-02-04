using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RefLib
{
    public static string PathToForwardSlashes(ref string s)
    {                
        return s.Replace('\\','/');
    }
    /// <summary>
    /// Removes symbols disallowed in file names by Windows (   / \ : ? < > |   ) from string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string StripAndTrim(ref string s)
    {            
        s = s.Replace("/","");
        s = s.Replace("\\","");
        s = s.Replace(":","");
        s = s.Replace("?","");
        s = s.Replace("\"","");
        s = s.Replace("<","");
        s = s.Replace(">","");
        s = s.Replace("|","");
        return s;
    }
    /// <summary>
    /// Removes spaces, tabs, new lines and carriage returns from the beginning of a string up until a character that isn't either of these.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Seek(ref string s)
    {
        if(s.Length > 0)
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
    /// <summary>
    /// Removes all new lines, tabs, spaces and carriage returns from string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Condense(ref string s)       
    {
        s = s.Replace("\n","");
        s = s.Replace("\t","");
        s = s.Replace("\r","");
        s = s.Replace(" ","");
        return s;
    }
    /// <summary>
    /// Takes a string and removes a line from it.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>Returns the removed line.</returns>
    public static string GetLine(ref string s)
    {
        string result = "";
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != '\r')
            {
                result += s[i];
                continue;
            }
            break;
        }
        if(result.Length + 2 <= s.Length)
            s = s.Remove(0,result.Length + 2);
        else s = "";        
        return result;
    }
    /// <summary>
    /// Cleanup modes for the CleanUp function.
    /// </summary>
    public enum cleanupModes { Comments, PlatformTags, Both };
    /// <summary>
    /// Takes a string and removes data based on mode. Check cleanupModes enum above for available modes.
    /// </summary>
    /// <param name="s">Target string to clean up.</param>
    /// <param name="mode">Mode to clean up with. Check cleanupModes enum for modes.</param>
    /// <returns>Returnes cleaned up string.</returns>
    public static string CleanUp(ref string s,cleanupModes mode)
    {
        while(true)
        {
            int commentIndex = s.IndexOf("//");
            int platformIndex = s.IndexOf('[');

            if((s.IndexOf("http://") != -1) || (s.IndexOf("https://") != -1))
            {
                s = s.Replace("http://","__httplink__");
                s = s.Replace("https://","__httpslink__");
                continue;
            } 
            if((commentIndex != -1) && ((mode == cleanupModes.Both) || (mode == cleanupModes.Comments)))
            {
                int newLineIndex = s.IndexOf('\n',commentIndex);
                s = s.Remove(commentIndex,newLineIndex - commentIndex);
                continue;
            }
            if((platformIndex != -1) && ((mode == cleanupModes.Both) || (mode == cleanupModes.PlatformTags)))
            {
                int endPlatformIndex = s.IndexOf(']',platformIndex);
                s = s.Remove(platformIndex,(endPlatformIndex - platformIndex) + 1);
                continue;
            }
            break;
        }
        s = s.Replace("__httplink__","http://");
        s = s.Replace("__httpslink__","https://");
        return s;
    }
}

