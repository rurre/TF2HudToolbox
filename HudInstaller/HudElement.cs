﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class HudElement
    {
        List<KeyValue> m_ValueList = new List<KeyValue>();
        List<SubElement> m_SubList = new List<SubElement>();

        public enum removeType { KeyValue, SubElement };

        int m_NrOfElements = 0;
        int m_NrOfSubElements = 0;
        string m_Name = null;        

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

        public int NrOfElements
        {
            get
            {
                return m_NrOfElements;
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
            m_NrOfElements++;
        }

        public void Add(SubElement se)
        {
            m_SubList.Add(se);
            m_NrOfSubElements++;
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
                m_NrOfElements--;
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
                m_NrOfSubElements--;
            }
        }

        public bool IsNull()
        {
            if(Name == null)
                return true;
            else return false;
        }
    }
}
