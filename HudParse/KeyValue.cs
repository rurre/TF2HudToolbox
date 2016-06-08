using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    class KeyValue
    {
        string key = null;
        string value = null;
        string tag = null;
        string commentHeader = null;
        int indentIndex = 0;        

        List<KeyValue> subKeyValues = new List<KeyValue>();

        private KeyValue()
        {
            if((subKeyValues.Count > 0) && (commentHeader != null))
                commentHeader = null;
        }

        public KeyValue(string key, string value, string tag, int indentIndex) : this()
        {
            this.key = key;
            this.value = value;
            this.indentIndex = indentIndex;
            this.tag = tag;
        }

        public KeyValue(string key, List<KeyValue> valueBlock, string tag, int indentIndex) : this()
        {
            this.key = key;
            this.subKeyValues = valueBlock;
            this.indentIndex = indentIndex;
            this.tag = tag;

            foreach(KeyValue kv in subKeyValues)
            {
                kv.indentIndex = indentIndex + 1;
            }
        }

        public KeyValue(string key,List<KeyValue> valueBlock) : this(key,valueBlock,null,0) { }
        public KeyValue(string key,List<KeyValue> valueBlock, string tag) : this(key,valueBlock,tag,0) { }
        public KeyValue(string key,string value) : this(key,value,null,0) { }
        public KeyValue(string key,string value, string tag) : this(key,value,tag,0) { }

        public void addSub(KeyValue kv)
        {
            kv.indentIndex = indentIndex + 1;
            subKeyValues.Add(kv);
        }

        public override string ToString()
        {
            string file = "";            
            file += Useful.AddTabs(indentIndex);
            if(subKeyValues.Count > 0)
            {
                foreach(KeyValue kv in subKeyValues)
                {
                    if(indentIndex == 0)
                        kv.indentIndex = indentIndex + 1;
                }
                if(commentHeader != null)
                {
                    file += commentHeader;
                    file += Useful.AddTabs(indentIndex);
                }
            }
            if(subKeyValues.Count > 0)
            {
                file += "\"" + key + "\"";
                if(tag != null)
                {
                    file += "\t[" + tag + "]";
                }
                file += Environment.NewLine;

                file += Useful.AddTabs(indentIndex);
                file += "{" + Environment.NewLine;

                for(int i = 0; i < subKeyValues.Count; i++)
                    file += subKeyValues[i].ToString();

                file += Useful.AddTabs(indentIndex);
                file += "}" + Environment.NewLine;
            }
            else
            {
                file += "\"" + key + "\"" + "\t\t" + "\"" + value + "\"";
                if(tag != null)
                    file += "\t[" + tag + "]";
                file += Environment.NewLine;
            }
            if(file != "")
                return file;
            else
                return null;
        }

        public static KeyValue Parse(ref string file)
        {
            string key = "";
            string value = "";
            string tag = "";
            string commentHeader = "";

            bool foundValue = false;
            bool foundKey = false;
            bool foundTag = false;

            bool spaceTerminates = true;

            KeyValue kv = new KeyValue();

            for(int i = 0; i < file.Length; i++)
            {

            }
            return kv;
        }
    }
}
