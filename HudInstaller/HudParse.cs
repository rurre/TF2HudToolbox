using System;
using System.IO;
using System.Linq;

namespace hudParse
{
    public class HudParse
    {
        public static Hud ParseHud(string path)
        {
            Hud hud = new Hud();
            HudResourceFile tempRes;
            tempRes = ParseHudResource(path);
            if(!tempRes.IsNull)
            {
                hud.Resource = tempRes;
                hud.ApplyResource();
            }                   

            var Hud_Subfolders = Directory.GetDirectories(path);
            for(int i = 0; i < Hud_Subfolders.Length; i++)
            {
                HudFolder folder = new HudFolder();
                folder.FullName = Hud_Subfolders[i];

                if(folder.Name.ToLower() == "resource" || folder.Name.ToLower() == "scripts")
                    folder = ParseHudFolder(folder.FullName);
                else
                    folder.CopyNoParse = true;
                hud.Add(folder);                                                  
            }            
            return hud;
        }

        public static HudResourceFile ParseHudResource(Stream stream)
        {
            HudResourceFile hf = new HudResourceFile();
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd();
            sr.Close();
            RefLib.CleanUp(ref s,RefLib.cleanupModes.Comments);

            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            hf.Name = ReadName(ss);
            s = s.Remove(0,ss.Length);
            RefLib.Seek(ref s);

            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    RefLib.Seek(ref s);
                    ss = s;
                    if(ss.First() != '}')
                    {
                        ss = RefLib.GetLine(ref ss);
                        KeyValue kv = ParseKeyValue(ss);
                        s = s.Remove(0,ss.Length);

                        if(kv != new KeyValue())
                            hf.Add(kv);
                        else break;                        
                    }
                    else break;
                }
            }
            return hf;
        }

        public static HudResourceFile ParseHudResource(string path)
        {            
            if(!path.EndsWith("\\hudinfo.txt"))
                path += "hudinfo.txt";

            if(File.Exists(path))
            {
                HudResourceFile newRes = new HudResourceFile();                
                newRes = ParseHudResource(new StreamReader(path).BaseStream);
                newRes.FullName = path;                
                return newRes;
            }
            else return new HudResourceFile();
        }

        static HudFile ParseHudFile(string path)
        {
            HudFile hf = new HudFile();
            string s;            

            if(File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                s = sr.ReadToEnd();
                RefLib.CleanUp(ref s,RefLib.cleanupModes.Comments);
                sr.Close();                
            }
            else throw new Exception("Can't parse file, it doesn't exist.");

            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            hf.FullName = ReadName(ss);
            s = s.Remove(0,ss.Length);
            

            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                s = s.Remove(0,1);                
                while(true)
                {
                    HudElement he = new HudElement();
                    RefLib.Seek(ref s);                    
                    ss = ReadName(s);
                    if(ss != "")
                    {
                        he.Name = ss;
                        s = s.Remove(0,ss.Length);
                        RefLib.Seek(ref s);
                    }
                    ss = s;
                    ss = RefLib.GetLine(ref ss);
                    if(ss.First() == '[')
                    {                        
                        if(ss.IndexOf(']') != -1)
                        {
                            he.Platform = Read(s,readModes.PlatformTag);
                        }
                        else throw new Exception("Expected platform tag (ex. [$WIN32]) in element " + he.Name + ". In file " + hf.FullName + " got: " + ss);
                        s = s.Remove(0,ss.Length);
                        RefLib.Seek(ref s);
                    }

                    if(s.First() == '{')
                    {
                        s = s.Remove(0,1);
                        while(true)
                        {
                            RefLib.Seek(ref s);
                            ss = s;
                            ss = RefLib.GetLines(2,ref ss);
                            if(ss.IndexOf('{') != -1)
                            {
                                SubElement sb = ParseSubElement(ref s);
                                if(!sb.IsNull)
                                {
                                    he.Add(sb);
                                    s = s.Remove(0,s.IndexOf('}')+1);
                                }
                                continue;                                
                            }

                            if(s.First() != '}')
                            {
                                ss = s;
                                ss = GetKeyValuePair(ss);
                                s = s.Remove(0,ss.Length);
                                KeyValue kv = ParseKeyValue(ss);

                                if(!kv.IsNull)
                                {
                                    he.Add(kv);
                                    continue;
                                }
                            }
                            break;
                        }
                        if(!he.IsNull)
                        {
                            hf.Add(he);
                            RefLib.Seek(ref s);
                            if(s.First() == '}')
                            {
                                s = s.Remove(0,1);
                                RefLib.Seek(ref s);
                            }
                        }
                        else break;
                    }
                    else if(s.First() == '}')
                    {
                        s = s.Remove(0,1);
                        RefLib.Seek(ref s);
                        if(s != "")
                            throw new Exception("Error while parsing file " + hf.FullName + ". String should be empty by now but isn't");
                        else break;
                    }
                }
            }
            return hf;
        }

        static KeyValue ParseKeyValue(string s)
        {            
            KeyValue kv = new KeyValue();
            if(s != "")
            {
                string name = "";
                string value = "";
                bool foundName = false;
                bool foundValue = false;
                bool openQuotes = false;
                int quotesToRemove = 0;
                for(int i = 0; i < s.Length; i++)
                {
                    if((s[i] != '\t') && (s[i] != ' ') && (s[i] != '\r') && (s[i] != '\n'))
                    {
                        if(s[i] == '\"')
                        {
                            if(!openQuotes)
                                openQuotes = true;
                            else
                                openQuotes = false;
                            quotesToRemove++;
                            continue;
                        }
                        if(!foundName)
                            name += s[i];
                        else
                        {
                            value += s[i];
                            foundValue = true;
                        }
                    }
                    else
                    {
                        if(openQuotes)
                        {
                            if(!foundName)
                                name += s[i];
                            else
                                value += s[i];
                            continue;
                        }
                        foundName = true;
                        if(foundValue && foundName)
                            break;
                    }
                }
                if(name != "")
                {
                    s = s.Remove(0,name.Length);
                    kv.Name = name;
                    s = RefLib.Seek(ref s);
                }
                if(value != "")
                {
                    s = s.Remove(0,value.Length);
                    kv.Value = value;
                    s = RefLib.Seek(ref s);
                }
                s = s.Remove(0,quotesToRemove);                             
                if(s != "")
                    kv.Platform = Read(s,readModes.PlatformTag);           
            }
            return kv;
        }

        static HudElement ParseHudElement(string s)
        {
            HudElement he = new HudElement();
            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            if(ss.IndexOf('[') == -1)
                he.Name = RefLib.Condense(ss);
            else
            {
                if(s.First() == '[')
                {
                    string result = "";                    
                    for(int i = 0; i < s.Length; i++)
                    {
                        result += ss[i];
                        if(ss[i] == ']')
                            break;
                        throw new Exception("Reached end of file before reaching end of platform tag");
                    }
                    s = s.Remove(0,ss.Length);
                    he.Platform = ss;
                    RefLib.Seek(ref s);
                }
            }
            s = s.Remove(ss.Length);
            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                while(s.First() != '}')
                {
                    string temp = s;
                    temp = RefLib.GetLines(2,ref temp);
                    if(temp.IndexOf('{') != -1)
                    {
                        SubElement sb = ParseSubElement(ref s);
                        if(!sb.IsNull)
                        {
                            he.Add(sb);
                            continue;
                        }
                        else throw new Exception("Parse sub element returned null. Don't try to parse if there isn't one");
                    }
                    RefLib.Seek(ref s);
                    KeyValue kv = new KeyValue();
                    string x = GetKeyValuePair(s);
                    kv = ParseKeyValue(x);
                    if(x != "")                    
                        s.Remove(0,x.Length);
                    if(!kv.IsNull)
                    {
                        he.Add(kv);
                    }
                    else break;                    
                }
            }
            return he;
        }

        public Hud CombineHuds(Hud hud1,Hud hud2)
        {
            Hud result = new Hud();

            return result;
        }

        //Currently uses almost the same code as ParseHudElement. 
        //TODO: Derive SubElement from HudElement and share code.
        //TODO: Check if it's a .res file before parsing and return null if it's not as a flag to copy the file over when installing.
        //TODO: Set folder check to Hud's path + folder name, or whatever, so it ignores the parsing ONLY if we're in the root hud folder.
        static SubElement ParseSubElement(ref string s)
        {
            SubElement sb = new SubElement();

            string ss = s;

            ss = RefLib.GetLine(ref ss);
            sb.Name = ss;
            ss = s;
            ss = RefLib.GetLine(ref ss);
            int toRemove = 0;

            for(int i = 0; i < ss.Length; i++)
            {
                if(ss[i] == '\"')
                    toRemove++;
            }
            s = s.Remove(0,ss.Length + toRemove);
            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    RefLib.Seek(ref s);
                    SubElement ssb = new SubElement();
                    ss = s;
                    ss = RefLib.GetLines(2,ref ss);
                    if(ss.IndexOf('{') != -1)
                    {
                        ssb = ParseSubElement(ref s);
                        if(!ssb.IsNull)
                        {
                            sb.Add(ssb);
                            s = s.Remove(0,s.IndexOf('}') + 1);
                            continue;
                        }
                    }

                    RefLib.Seek(ref s);
                    KeyValue kv = new KeyValue();
                    if(s.First() != '}')
                    {
                        ss = GetKeyValuePair(s);
                        s = s.Remove(0,ss.Length);
                        kv = ParseKeyValue(ss);
                    }                    
                    if(!kv.IsNull)
                        sb.Add(kv);
                    else break; 
                }
            }
            return sb;
        }

        static HudFolder ParseHudFolder(string path)
        {            
            HudFolder folder = new HudFolder();
            folder.FullName = path;
            var hudFiles = Directory.GetFiles(path, "*.res");
            var folders = Directory.GetDirectories(path);

            for(int i = 0; i < folders.Length; i++)
            {
                HudFolder subFolder = new HudFolder();                
                subFolder.FullName = folders[i];
                if(!subFolder.CopyNoParse)
                    subFolder = ParseHudFolder(subFolder.FullName);
                folder.Add(subFolder);
            }
            if(hudFiles.Length > 0)
            {
                for(int i = 0; i < hudFiles.Length; i++)
                {
                    HudFile file = new HudFile();
                    file.FullName = hudFiles[i];

                    file = ParseHudFile(file.FullName);
                    if(!file.IsNull)
                        folder.Add(file);
                }
            }            
            return folder;
        }

        public enum readModes { KeyValue, PlatformTag };
        /// <summary>
        /// Looks for the first value it can find enclosed in quotes or square brackets.
        /// </summary>
        /// <param name="s">Target string to look in.</param>
        /// <returns>Returns the value enclosed in quotes or square brackets.</returns>
        static string Read(string s,readModes mode)
        {
            string result = "";
            bool openedQuotes = false;

            if(s.First() != '}')
            {
                for(int i = 0; i < s.Length; i++)
                {
                    if(mode == readModes.KeyValue)
                    {
                        if(s[i] == '\"')
                        {
                            if(!openedQuotes)
                            {
                                openedQuotes = true;
                                continue;
                            }
                            else break;
                        }
                        else if(openedQuotes)
                        {
                            result += s[i];
                            continue;
                        }
                    }
                    else if(mode == readModes.PlatformTag)
                    {
                        if(s[i] == '[')
                        {
                            if(!openedQuotes)
                            {
                                openedQuotes = true;
                                continue;
                            }
                            else break;
                        }
                        else if(openedQuotes)
                        {
                            if(s[i] == ']')
                                break;
                            result += s[i];
                        }
                    }
                    else throw new Exception("Error: Something went wrong when trying to Read(). This isn't supposed to be possible. Help!");
                }
            }
            return result;
        }
        static string Read(string s)
        {
            return Read(s,readModes.KeyValue);
        }
        static string ReadName(string s)
        {
            string result = "";
            string ss = s;
            ss = RefLib.GetLine(ref ss);

            for(int i = 0; i < ss.Length; i++)
            {
                if((ss[i] != ' ') && (ss[i] != '}') && (ss[i] != '\t'))
                    result += ss[i];
                else break;
            }
            return result;
        }

        /// <summary>
        /// Strips keyvalues containing "_minmode" off all elements and their subelements.
        /// </summary>
        /// <param name="hf">HudFile to strip.</param>
        /// <returns>Returns a HudFile without any minimal values.</returns>
        static HudFile StripMinimal(HudFile hf)
        {
            foreach(HudElement he in hf.m_ElementList)
            {
                foreach(KeyValue kv in he.m_ValueList)
                {
                    if(kv.Name.IndexOf("_minmode") != -1)
                        he.Remove(kv);                    
                }
                foreach(SubElement sb in he.m_SubList)
                {
                    foreach(KeyValue kv in sb.m_ValueList)
                    {
                        if(kv.Name.IndexOf("_minmode") != -1)
                            he.Remove(kv);
                    }
                    foreach(SubElement ssb in sb.m_SubValueList)
                    {
                        foreach(KeyValue kv in ssb.m_ValueList)
                        {
                            if(kv.Name.IndexOf("_minmode") != -1)
                                he.Remove(kv);
                        }
                    }
                }                
            }
            return hf;
        }

        /// <summary>
        /// Takes a HudFile and makes minimal values override default values, then removes the minimal ones.
        /// For example: It finds a pair like:
        /// "xpos"          "10"    
        /// "xpos_minmode"  "20"
        /// After which it sets "xpos" to 20 and deletes "xpos_minmode" so you're left with only:
        /// "xpos"      "20"
        /// </summary>
        /// <param name="hf">HudFile to use.</param>
        /// <returns>Returns the new HudFile.</returns>
        static HudFile MakeMinimalDefault(HudFile hf)
        {
            foreach(HudElement he in hf.m_ElementList)
            {
                foreach(KeyValue kv in he.m_ValueList)
                {
                    string newValue;
                    string name;
                    if(kv.Name.Contains("_minmode"))
                    {
                        newValue = kv.Value;
                        name = kv.Name.Replace("_minmode","");
                        foreach(KeyValue kv2 in he.m_ValueList)
                        {
                            if(kv2.Name.ToLower() == name.ToLower())
                            {
                                kv2.Value = newValue;
                                he.m_ValueList.Remove(kv);
                                break;
                            }
                        }
                    }
                }
                foreach(SubElement sb in he.m_SubList)
                {
                    foreach(KeyValue kv in he.m_ValueList)
                    {
                        string newValue;
                        string name;
                        if(kv.Name.Contains("_minmode"))
                        {
                            newValue = kv.Value;
                            name = kv.Name.Replace("_minmode","");
                            foreach(KeyValue kv2 in he.m_ValueList)
                            {
                                if(kv2.Name.ToLower() == name.ToLower())
                                {
                                    kv2.Value = newValue;
                                    he.m_ValueList.Remove(kv);
                                    break;
                                }
                            }
                        }
                    }
                    foreach(SubElement ssb in sb.m_SubValueList)
                    {
                        foreach(KeyValue kv in he.m_ValueList)
                        {
                            string newValue;
                            string name;
                            if(kv.Name.Contains("_minmode"))
                            {
                                newValue = kv.Value;
                                name = kv.Name.Replace("_minmode","");
                                foreach(KeyValue kv2 in he.m_ValueList)
                                {
                                    if(kv2.Name.ToLower() == name.ToLower())
                                    {
                                        kv2.Value = newValue;
                                        he.m_ValueList.Remove(kv);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }                
            }
            return hf;
        }

        static string GetKeyValuePair(string s)
        {
            string ss = s;            
            string result = "";
            int quoteNr = 0;
            RefLib.Seek(ref ss);
            bool foundKey = false;            
            bool foundInBetween = false;
            string key = "";
            string value = "";
            string inBetween = "";            

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
            ss = RefLib.GetLine(ref ss);
            if(ss != "")
                result += ss;
            return result;
        }
    }
}