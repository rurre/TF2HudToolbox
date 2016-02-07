using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class HudFolder
    {
        string m_Name = "";
        string m_Path = "";        
        List<HudFile> m_FileList = new List<HudFile>();
        List<HudFolder> m_SubFolderList = new List<HudFolder>();
        public bool CopyNoParse = false;

        public string FullName
        {
            get
            {
                return m_Path + m_Name;
            }

            set
            {
                if(value.IndexOf("\\") != -1)
                {
                    m_Name = value.Remove(0,value.LastIndexOf("\\")+1);
                    m_Path = value.Remove(value.Length - m_Name.Length);
                }
                else
                {
                    RefLib.StripAndTrim(ref value);
                    m_Name = value;
                }
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
                m_Name = value;
            }
        }

        public string Path
        {
            get { return m_Path; }
            set { m_Path = value; }
        }
                
        public void Add(HudFile file)
        {
            m_FileList.Add(file);
        }

        public void Add(HudFolder folder)
        {
            if(folder.FullName == null)
            {
                if(folder.FullName.ToLower() == "new folder")
                {
                    for(int i = 1; folder.FullName == "new folder" + i; i++)
                        folder.FullName = "New Folder " + i;
                }
                else folder.FullName = "New Folder";
            }
            m_SubFolderList.Add(folder);
        }

        public bool IsEmpty()
        {
            if(m_FileList.Count == 0)
                return true;
            else return false;
        }
    }
}
