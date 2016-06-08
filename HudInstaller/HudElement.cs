using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class HudElement
    {
        public List<KeyValue> m_ValueList;
        public List<SubElement> m_SubList;
        public enum removeType { KeyValue, SubElement };

        string m_Name;
        string m_Platform;

        public HudElement()
        {
            m_Name = null;
            m_Platform = null;
            m_ValueList = new List<KeyValue>();
            m_SubList = new List<SubElement>();
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                if(value.IndexOf('\"') != -1)
                    value = value.Replace("\"","");
                RefLib.StripAndTrim(ref value);
                m_Name = value;
            }
        }
        public int NrOfElements
        {
            get
            {
                return m_ValueList.Count;
            }
        }
        public int NrOfSubElements
        {
            get
            {
                return m_SubList.Count;
            }
        }
        public string Platform
        {
            get
            {
                return m_Platform;
            }

            set
            {
                if(value.IndexOf('[') != -1)
                    value = value.Replace("[","");
                if(value.IndexOf(']') != -1)
                    value = value.Replace("]","");
                if(value != "")
                    m_Platform = value;
                else m_Platform = null;
            }
        }
        public bool IsNull
        {
            get
            {
                if((m_SubList.Count > 0) || m_ValueList.Count > 0)
                    return false;
                else return true;
            }
        }

        public override string ToString()
        {
            string s = "";
            s += "\t\"" + m_Name + "\"\n\t{\n";
            foreach(KeyValue element in m_ValueList)
            {
                s += element.ToString();
            }

            if(m_SubList.Count != 0)
            {
                foreach(SubElement element in m_SubList)
                {
                    s += element.ToString();
                }
                s += "\t}\n";
            }
            return s;
        }
        public void Add(KeyValue kv)
        {                        
            m_ValueList.Add(kv);            
        }
        public void Add(SubElement se)
        {
            m_SubList.Add(se);            
        }
        public void Remove(string name, removeType tp)
        {
            if(tp == removeType.KeyValue)
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
            else if(tp == removeType.SubElement)
            {
                foreach(SubElement element in m_SubList)
                {
                    if(element.Name == name)
                    {
                        m_SubList.Remove(element);
                        break;
                    }
                }                
            }
        }
        public void Remove(KeyValue kv)
        {
            m_ValueList.Remove(kv);
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
        public SubElement FindSub(string name)
        {
            foreach(SubElement sb in m_SubList)
            {
                if(sb.Name.ToLower() == name.ToLower())
                    return sb;
            }
            return null;
        }

        public bool CheckIfDefault(HudElement defaultElement)
        {
            if(Name.ToLower() == defaultElement.Name.ToLower())
            {
                foreach(KeyValue kv in m_ValueList)
                {
                    if(kv != defaultElement.FindKeyValue(kv.Name))
                        return false;                   
                }
                foreach(SubElement sb in m_SubList)
                {
                    if(sb != defaultElement.FindSub(sb.Name))
                        return false;
                }
            }
            return true;
        }
    }
}
