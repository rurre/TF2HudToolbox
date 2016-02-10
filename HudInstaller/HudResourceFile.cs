using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hudParse
{
    public class HudResourceFile
    {
        List<KeyValue> m_ValueList;
        List<SubElement> m_SubList;

        string m_Name;
        string m_FileType;
        string m_Path;

        public bool IsNull
        {
            get
            {
                if((m_ValueList.Count > 0) || (m_SubList.Count > 0))
                    return false;
                else return true;
            }
        }
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public string Path
        {
            get { return m_Path; }
            set { m_Path = value; }
        }
        public string FullName
        {
            get { return m_Path + m_Name; }
            set
            {
                value = value.Replace("\\","/");
                if(value.LastIndexOf('/') != -1)
                {
                    string s = value;
                    s = s.Remove(value.LastIndexOf('/') + 1);
                    m_Path = s;
                    value = value.Remove(0,s.Length);
                }
                RefLib.StripAndTrim(ref value);
                if(value.IndexOf('.') != -1)
                    m_Name = value.Remove(value.IndexOf('.'));
                else m_Name = value;
                if(value.IndexOf('\"') != -1)
                {
                    m_Name.Replace("\"","");
                    m_Path.Replace("\"","");
                }
            }
        }

        public HudResourceFile()
        {
            m_Name = null;
            m_Path = null;
            m_FileType = "txt";

            m_ValueList = new List<KeyValue>();
            m_SubList = new List<SubElement>();
        }
        public HudResourceFile(string fileType) : base()
        {            
            if(fileType.IndexOf('.') != -1)
                fileType = fileType.Remove(fileType.IndexOf('.'));
            m_FileType = fileType;            
        }
        public HudResourceFile(string name,string fileType,string path, List<KeyValue> kvList) : base()
        {            
            m_Name = name;
            m_Path = path;
            m_ValueList = kvList;

            if(fileType.IndexOf('.') != -1)
                fileType = fileType.Remove(fileType.IndexOf('.'));
            m_FileType = fileType;
        }        
        public void Add(KeyValue kv)
        {
            m_ValueList.Add(kv);
        }
        public void Add(SubElement sb)
        {
            m_SubList.Add(sb);
        }
        public void Remove(string name)
        {
            foreach(KeyValue element in m_ValueList)
            {
                if(element.Name == name)
                {
                    m_ValueList.Remove(element);
                    break;
                }
            }
        }
        public void Write()
        {
            if(m_Path != null)
            {
                StreamWriter sr = new StreamWriter(m_Path + m_Name + "." + m_FileType);
                sr.WriteLine("\"" + m_Path + m_Name +"\"\n{\n");
                foreach(KeyValue element in m_ValueList)
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
            foreach(KeyValue element in m_ValueList)
            {
                s += element.ToString();
            }
            s += "\n}";
            return s;
        }
        public KeyValue FindKeyValue(string name)
        {
            foreach(KeyValue element in m_ValueList)
            {
                if(element.Name.ToLower() == name.ToLower())
                    return element;
            }
            return null;
        }
        public KeyValue FindKeyValueIgnoreEndNr(string name)
        {
            name = RefLib.RemoveEndNumbers(name).ToLower();
            foreach(KeyValue element in m_ValueList)
            {                
                if(name == element.Name.ToLower())
                    return element;                
            }                
            return null;           
        }
        public SubElement FindSubElement(string name)
        {
            foreach(SubElement element in m_SubList)
            {
                if(element.Name.ToLower() == name.ToLower())
                    return element;
            }
            return new SubElement();
        }

        public void MakeFilePathRelative(string hudPath)
        {
            if(Path.StartsWith(hudPath))
                m_Path = m_Path.Remove(hudPath.Length);
        }
    }
}
