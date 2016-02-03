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
        public List<HudElement> m_ElementList = new List<HudElement>();
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
                if(value.IndexOf("\\") != -1)
                {
                    m_Name = value.Remove(0,value.LastIndexOf("\\") + 1);
                    m_Path = value.Remove(value.Length - m_Name.Length);
                }
                else
                {
                    RefLib.StripAndTrim(ref value);
                    m_Name = value;
                }
                if(m_Name.IndexOf('.') != -1)
                    m_Name = m_Name.Remove(m_Name.IndexOf('.'));                
            }
        }

        public string Path
        {
            get
            {
                return m_Path;
            }

            set
            {
                m_Path = value;
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

        public string FullName
        {
            get
            {
                return m_Path + m_Name + "." + m_FileType;
            }
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
