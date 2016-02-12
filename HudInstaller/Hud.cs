using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

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

        public List<HudFolder> m_FolderList;

        public Hud()
        {
            m_Name      = "Unknown";
            m_Author    = "Unknown";
            m_Link      = "Unknown";            
            m_FolderList = new List<HudFolder>();
        }
        
        public int FileCount
        {
            get
            {
                int count = 0;
                foreach(HudFolder f in m_FolderList)
                {
                    count += f.FileCount;
                }
                return count;
            }
        }
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
        public bool HasDefaultLogo
        {
            get
            {
                if(m_Logo == null)
                    return true;
                else return false;
            }
        }        
        public string FullName
        {
            get
            {
                return Path + Name;
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
            }
        }

        public void SetLogo(Image logo)
        {
            m_Logo = logo;            
        }
        public void SetDeafaultLogo()
        {
            m_Logo = HudInstaller.Properties.Resources.logo_default;            
        }
        public void ApplyResource()
        {            
            if(m_Resource.FindKeyValue("name") != null)
                m_Name = m_Resource.FindKeyValue("name").Value;
            if(m_Resource.FindKeyValue("author") != null)
                m_Author = m_Resource.FindKeyValue("author").Value;
            if(m_Resource.FindKeyValue("website") != null)
                m_Link = m_Resource.FindKeyValue("website").Value;            
        }
        public void Add(HudFolder folder)
        {
            m_FolderList.Add(folder);
        }

        public void Write()
        {      
                  
        }

        public List<String> GetFileNames()
        {
            List<String> l = new List<String>();
            foreach(HudFolder hf in m_FolderList)
            {
                l.AddRange(hf.GetFileNames());                
            }
            return l;
        }
    }
}
