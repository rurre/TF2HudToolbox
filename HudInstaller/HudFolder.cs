using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    class HudFolder
    {
        string m_FolderName = "";
        string m_FolderPath = "";
        List<HudFile> m_FileList = new List<HudFile>();
        List<HudFolder> m_SubFolderList = new List<HudFolder>();

        public string FolderName
        {
            get
            {
                return m_FolderName;
            }

            set
            {
                RefLib.StripAndTrim(ref value);
                m_FolderName = value;
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
    }
}
