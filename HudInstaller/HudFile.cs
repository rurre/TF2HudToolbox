using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hudParse
{
    public class HudFile
    {
        public List<HudElement> m_ElementList;
        string m_Name;
        string m_FileType;
        string m_Path;
        bool m_IsDefault;

        public HudFile()
        {
            m_ElementList = new List<HudElement>();
            m_FileType = "res";
            m_Path = null;
            m_Name = null;
            m_IsDefault = false;
        }
        public HudFile(string name) : base()
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if(value.IndexOf('.') != -1)
                    value = value.Remove(value.LastIndexOf('.'));
                m_Name = value.Replace("\"","");
            }
        }
        public string Path
        {
            get { return m_Path; }
            set
            {
                m_Path = value.Replace("\"","");
            }
        }
        public string FullName
        {
            get
            {                
                return m_Path + m_Name + "." + m_FileType;                
            }
            set
            {
                value = value.Replace('/','\\');
                string temp = value.Remove(0,value.LastIndexOf("\\") + 1);
                Name = value.Remove(0,value.LastIndexOf("\\") + 1);                
                Path = value.Remove(value.Length - temp.Length);                                
            }
        }
        public bool IsNull
        {
            get
            {
                if(m_ElementList.Count > 0)
                    return false;
                else return true;
            }
        }

        public void Add(HudElement element)
        {
            m_ElementList.Add(element);
        }
        public void Remove(string name)
        {
            foreach(HudElement element in m_ElementList)
            {
                if(element.Name == name)
                {
                    m_ElementList.Remove(element);
                    break;
                }
            }
        }
        public void Write()
        {
            if(!this.IsNull)
            {
                if(m_Path != null)
                {
                    StreamWriter sr = new StreamWriter(m_Path + m_Name + "." + m_FileType);
                    sr.WriteLine("\"" + m_Path + m_Name + "." + m_FileType + "\"\n{\n");
                    foreach(HudElement element in m_ElementList)
                    {
                        sr.WriteLine(element.ToString());
                    }
                    sr.WriteLine("}");
                    sr.Close();
                }
                else throw new Exception("Filepath is empty");
            }
            else throw new Exception("Requested to write a null file");
        }
        public override string ToString()
        {            
            string s = "";
            s += "\"" + m_Path + m_Name + "." + m_FileType + "\"\n{\n";
            foreach(HudElement element in m_ElementList)
            {
                s += element.ToString();
            }
            s += "\n}";
            return s;            
        }

        public void MakeFilePathsRelative(string hudPath)
        {
            if(Path.StartsWith(hudPath))
                m_Path = m_Path.Remove(0,hudPath.Length);
        }

        public bool CheckIfDefault(HudFile file)
        {
            foreach(HudElement he in m_ElementList)
            {
                he.CheckIfDefault(file.FindElement(he.Name));                                    
            }
            return true;
        }

        public HudElement FindElement(string name)
        {
            foreach(HudElement he in m_ElementList)
            {
                if(he.Name.ToLower() == name.ToLower())
                    return he;
                else break;
            }
            return null;
        }
    }
}
