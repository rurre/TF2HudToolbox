﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace hudParse
{
    public class Hud
    {        
        string  m_Name;        
        Image   m_Logo;
        string  m_Path;
        string  m_Author;
        string  m_Link;
        HudResourceFile m_Resource;

        public Hud()
        {
            m_Name      = "Unknown";
            m_Author    = "Unknown";
            m_Link      = "Unknown";
        }

        List<HudFolder> m_FolderList = new List<HudFolder>();

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

        internal HudResourceFile Resource
        {
            get
            {
                return m_Resource;
            }

            set
            {
                m_Resource = value;
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

        public Image Logo
        {
            get
            {
                return m_Logo;
            }

            set
            {
                m_Logo = value;
            }
        }

        public void ApplyResource()
        {            
            if(m_Resource.FindKeyValue("name") != new KeyValue())
                m_Name = m_Resource.FindKeyValue("name").Value;
            if(m_Resource.FindKeyValue("author") != new KeyValue())
                m_Author = m_Resource.FindKeyValue("author").Value;
            if(m_Resource.FindKeyValue("link") != new KeyValue())
                m_Link = m_Resource.FindKeyValue("link").Value;            
        }
    }
}