using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    class HudFile
    {
        string filePath,name;
        int errorId = -1;        

        List<KeyValue> keyValues = new List<KeyValue>();

        public string Path
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                name = value.Remove(0,value.LastIndexOf("\\") + 1);                
            }
        }

        public string Folder
        {
            get
            {
                return Path.Remove(Path.Length - name.Length,name.Length);
            }
        }
        public int ErrorId
        {
            get
            {
                return errorId;
            }
        }
        public List<KeyValue> KeyValues
        {
            get
            {
                return keyValues;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        private HudFile() { }

        public HudFile(string path,List<KeyValue> kvList)
        {
            keyValues = kvList;
            Path = path;
        }

        public HudFile(string path)
        {
            HudFile hf = ParseFromPath(path);
            this.errorId = hf.errorId;
            Path = hf.filePath;
            this.keyValues = hf.keyValues;            
        }

        public HudFile(List<KeyValue> kvList)
        {
            keyValues = kvList;
        }

        public void AddKeyValue(KeyValue kv)
        {
            if(kv != null)
                keyValues.Add(kv);
        }

        public override string ToString()
        {
            string s = "";
            foreach(KeyValue kv in keyValues)
            {
                s += kv.ToString();
            }
            return s;
        }

        public static HudFile ParseFromPath(string path)
        {
            try
            {
                HudFile hf = new HudFile();
                string file = System.IO.File.ReadAllText(path);
                hf = Parse(ref file);
                hf.Path = path;

                return hf;
            }
            catch(Exception)
            {
                throw;
            }            
        }

        public static HudFile Parse(ref string file)
        {
            List<KeyValue> kvList = new List<KeyValue>();             
            try
            {
                while(file != "")
                {
                    file = Useful.Seek(ref file);
                    KeyValue kv = KeyValue.Parse(ref file);
                    if(kv != null)
                        kvList.Add(kv);
                }
                return new HudFile(kvList);                
            }
            catch(Exception e)
            {
                throw e;
            }               
        }

        public void MakeFilePathsRelative(string hudPath)
        {
            filePath = filePath.Replace(hudPath,"");
        }

        public KeyValue FindKeyValue(string name)
        {
            if(name == "*")
                return keyValues[0];
            for(int i = 0; i < keyValues.Count; i++)
            {
                if(keyValues[i].Key.ToLower() == name.ToLower())
                    return keyValues[i];
            }
            return null;
        }

        public KeyValue FindKeyValueIgnoreEndNr(string name)
        {
            if(name == "*")
                return keyValues[0];

            name = Useful.StripEndNumbers(name);

            for(int i = 0; i < keyValues.Count; i++)
            {
                string s = keyValues[i].Key.ToLower();                
                if(s == name.ToLower())
                    return keyValues[i];
            }
            return null;
        }

        public bool Equals(HudFile hf)
        {
            if((hf == null) && (this == null))
                return true;
            else
            {
                foreach(KeyValue kv in keyValues)
                {
                    bool found = false;
                    foreach(KeyValue kvv in hf.keyValues)
                    {
                        if(kv.Equals(kvv))
                        {
                            found = true;
                            break;
                        }
                    }
                    if(!found)
                        return false;
                }
                return true;
            }
        }
    }
}
