using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hudParse
{
    class HudFile
    {
        List<HudElement> m_ElementList = new List<HudElement>();
        string m_Name;
        string m_FileType;
        string m_Path;

        public HudFile()
        {
            m_FileType = "res";
            m_Path = "";
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
                value.Replace("\\","/");                
                if(value.LastIndexOf('/') != -1)
                {
                    string s = value;
                    s = s.Remove(value.LastIndexOf('/')+1);
                    m_Path = s;
                    value = value.Remove(0,s.Length);
                }
                RefLib.StripAndTrim(ref value);
                m_Name = value.Remove(value.IndexOf('.'));                
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
            if(m_Path != "")
            {
                StreamWriter sr = new StreamWriter(m_Path + m_Name + "." + m_FileType);      //Change this later
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
    }
}
