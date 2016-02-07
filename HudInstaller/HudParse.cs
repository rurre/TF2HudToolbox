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
            if(tempRes != new HudResourceFile())
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
            string line;
            string s;

            StreamReader sr = new StreamReader(stream);

            s = sr.ReadToEnd();
            RefLib.CleanUp(ref s,RefLib.cleanupModes.Comments);
            sr.Close();

            line = RefLib.GetLine(ref s);
            RefLib.Condense(ref line);
            hf.FullName = line.Trim(new char[] { '\"' });

            RefLib.Seek(ref s);
            line = RefLib.GetLine(ref s);
            RefLib.Condense(ref line);

            if(line.First() == '{')
            {
                while(true)
                {
                    RefLib.Seek(ref s);
                    line = RefLib.GetLine(ref s);
                    if(line.IndexOf('}') == -1)
                        hf.Add(ParseKeyValue(line));
                    else break;
                }                
            }
            
            return hf;
        }

        public static HudResourceFile ParseHudResource(string path)
        {            
            if(!path.EndsWith("\\hudinfo.txt"))
                path += "\\hudinfo.txt";

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
            hf.FullName = Read(s);
            s = s.Remove(0,hf.FullName.Length + 2);
            string ss;

            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    HudElement he = new HudElement();
                    ss = Read(s);
                    he.Name = ss;
                    s = s.Remove(0,ss.Length + 2);
                    RefLib.Seek(ref s);

                    if(s.First() == '{')
                    {
                        s = s.Remove(0,1);
                        while(true)
                        {
                            RefLib.Seek(ref s);                        
                            if(s.First() != '}')
                            {
                                ss = s;
                                RefLib.GetLine(ref ss);
                                s = s.Remove(ss.Length);
                                KeyValue kv = ParseKeyValue(ss);

                                if(kv != new KeyValue())
                                {
                                    he.Add(kv);
                                    continue;
                                }
                            }
                            break;
                        }
                        if(he != new HudElement())
                        {
                            hf.Add(he);
                        }
                        else break;
                    }
                }
            }
            return hf;
        }

        static KeyValue ParseKeyValue(string s)
        {            
            KeyValue kv = new KeyValue();

            string ss;
            RefLib.Seek(ref s);
            if(s.First() != '}')
            {
                int toRemove = 0;
                RefLib.Seek(ref s);

                ss = Read(s,readModes.KeyValue);
                kv.Name = ss;
                for(int i = 0; i < ss.Length+2; i++)
                {
                    if(i < s.Length)
                    {
                        if(s[i] == '\"')
                            toRemove++;
                    }
                    else throw new Exception("Out of range");               
                }                
                s = s.Remove(0,ss.Length + toRemove);
                toRemove = 0;

                RefLib.Seek(ref s);
                ss = Read(s,readModes.KeyValue);
                kv.Value = ss;
                for(int i = 0; i < ss.Length + 2; i++)
                {
                    if(i < s.Length)
                    {
                        if(s[i] == '\"')
                            toRemove++;
                    }
                    else throw new Exception("Out of range");
                }
                s = s.Remove(0,ss.Length + toRemove);
                toRemove = 0;

                RefLib.Seek(ref s);
                if(s.Length > 0)
                {                    
                    ss = Read(s,readModes.PlatformTag);
                    if(s != "")
                    {
                        kv.Platform = s;
                        for(int i = 0; i < ss.Length + 2; i++)
                        {
                            if(i < s.Length)
                            {
                                if(s[i] == '\"')
                                    toRemove++;
                            }
                            else throw new Exception("Out of range");
                        }
                        s = s.Remove(0,ss.Length + toRemove);
                        toRemove = 0;
                    }
                }
            }
            return kv;

        }

        static HudElement ParseHudElement(string s)
        {
            HudElement he = new HudElement();
            RefLib.Seek(ref s);
            string ss = Read(s);
            he.Name = ss;

            s = s.Remove(ss.Length + 2);
            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                while(s.First() != '}')
                {
                    string temp = s;
                    temp = RefLib.GetLines(2,ref temp);
                    if(temp.IndexOf('{') != -1)
                    {
                        SubElement sb = ParseSubElement(s);
                        if(sb != new SubElement())
                        {
                            he.Add(sb);
                            continue;
                        }
                        else throw new Exception("Parse sub element returned null. Don't try to parse if there isn't one");
                    }                    

                    KeyValue kv = new KeyValue();
                    kv = ParseKeyValue(s);
                    if(kv != new KeyValue())
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
        static SubElement ParseSubElement(string s)
        {
            SubElement sb = new SubElement();

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
                    if(file != new HudFile())
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
            return result;
        }
        static string Read(string s)
        {
            return Read(s,readModes.KeyValue);
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


    }
}