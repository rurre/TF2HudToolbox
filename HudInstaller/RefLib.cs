using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

static class RefLib
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
    public static string Condense(string s)
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

            //Disabled since it's been causing trouble since some files have stuff like /**********
            //int indexOfStart = s.IndexOf("/*");
            //int indexOfEnd = s.IndexOf("*/");

            //if(indexOfEnd == -1 && indexOfStart != -1)
            //    throw new Exception("Found beginning of block comment - \"/*\" but couldn't find end of it - \"*/\"");

            //if(indexOfStart != -1)
            //{                   
            //    s = s.Remove(indexOfStart,indexOfEnd - indexOfStart+2);
            //   continue;
            //}

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

    public static IEnumerable<Control> GetAll(Control control,Type type)
    {
        var controls = control.Controls.Cast<Control>();

        return controls.SelectMany(ctrl => GetAll(ctrl,type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() == type);
    }

    public static string RemoveEndNumbers(string input)
    {
        var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };        
        var result = input.TrimEnd(digits);
        return result;
    }

    static void CreateShortcut(string applicationPath,string pathName)
    {
        Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
        dynamic shell = Activator.CreateInstance(t);
        try
        {
            if(!pathName.EndsWith(".lnk"))
                pathName += ".lnk";
            var lnk = shell.CreateShortcut(pathName);
            try
            {
                lnk.TargetPath = applicationPath;
                lnk.IconLocation = "shell32.dll, 1";
                lnk.Save();
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(lnk);
            }
        }
        finally
        {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
        }
    }
}

