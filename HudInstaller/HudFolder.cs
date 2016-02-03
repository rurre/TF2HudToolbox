using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class HudFolder
    {
        string m_FolderName = "";
        string m_FolderPath = "";        
        List<HudFile> m_FileList = new List<HudFile>();
        List<HudFolder> m_SubFolderList = new List<HudFolder>();
        public bool CopyNoParse = false;

        public string FolderName
        {
            get
            {
                return m_FolderName;
            }

            set
            {
                if(value.IndexOf("\\") != -1)
                {
                    m_FolderName = value.Remove(0,value.LastIndexOf("\\")+1);
                    m_FolderPath = value.Remove(value.Length - m_FolderName.Length);
                }
                else
                {
                    RefLib.StripAndTrim(ref value);
                    m_FolderName = value;
                }
            }
        }

        public string FolderPath
        {
            get
            {
                return m_FolderPath;
            }

            set
            {
                m_FolderPath = value;
            }
        }

        public string FullName
        {
            get
            {
                return FolderPath + FolderName;
            }
        }

        public void Add(HudFile file)
        {
            m_FileList.Add(file);
        }

        public void Add(HudFolder folder)
        {
            if(folder.FolderName == null)
            {
                if(folder.FolderName.ToLower() == "new folder")
                {
                    for(int i = 1; folder.FolderName == "new folder" + i; i++)
                        folder.FolderName = "New Folder " + i;
                }
                else folder.FolderName = "New Folder";
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
