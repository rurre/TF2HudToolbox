﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class KeyValue
    {
        string m_Name;
        string m_Value;
        string m_Platform;       

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
        public string Value
        {
            get
            {
                return m_Value;
            }

            set
            {                
                m_Value = value;
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
                    value = value.Remove(0,value.IndexOf('[') + 1);
                if(value.IndexOf(']') != -1)
                    value = value.Remove(value.IndexOf(']'));
                if(value != "")
                    m_Platform = value;
                else m_Platform = null;                
            }
        }
        public bool IsNull
        {
            get
            {
                if(m_Name == null)
                    return true;
                return false;
            }
        }

        public KeyValue()
        {
            m_Name = null;
            m_Value = null;
            m_Platform = null;       
        }
        public KeyValue(string name, string value)
        {
            m_Name = name;
            m_Value = value;
        }        
        public override string ToString()
        {
            string s = "";
            s +=  "\t\t\"" + m_Name + "\"\t\t\"" + m_Value + "\"";
            if(Platform != null)
                s += "\t\t" + "[" + Platform + "]";
            s += "\n";
            return s;
        }        
    }
}
