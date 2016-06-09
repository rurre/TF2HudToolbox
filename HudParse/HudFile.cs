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
        string filePath;
        int errorId = -1;        

        List<KeyValue> keyValues = new List<KeyValue>();

        string Path
        {
            get
            {
                return filePath;
            }
        }
        int ErrorId
        {
            get
            {
                return errorId;
            }
        }

        private HudFile() { }

        public HudFile(string path,List<KeyValue> kvList)
        {
            keyValues = kvList;
            filePath = path;
        }

        public HudFile(string path)
        {
            HudFile hf = ParseFromPath(path);
            this.errorId = hf.errorId;
            this.filePath = hf.filePath;
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
                hf.filePath = path;

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
    }
}
