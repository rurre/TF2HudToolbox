using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class SubElement
    {
        string m_Name = "";
        public List<KeyValue> m_ValueList = new List<KeyValue>();
        public List<SubElement> m_SubValueList = new List<SubElement>();

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                RefLib.StripAndTrim(ref value);
                m_Name = value;
            }
        }

        public void Add(KeyValue kv)
        {
            m_ValueList.Add(kv);
        }

        public void Add(SubElement sb)
        {
            m_SubValueList.Add(sb);
        }

        public override string ToString()
        {
            string result = "";
            result += "\n\t\t\"" + m_Name + "\"\n\t\t{\n";
            foreach(KeyValue element in m_ValueList)
            {
                result += "\t";           
                result += element.ToString();                
            }
            result += "\t\t}\n";
            return result;
        }

        public KeyValue FindKeyValue(string name)
        {
            foreach(KeyValue element in m_ValueList)
            {
                if(element.Name.ToLower() == name.ToLower())
                    return element;
            }
            return new KeyValue();
        }
    }
}
