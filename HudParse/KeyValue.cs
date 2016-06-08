﻿using System;
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
                    if(kv.indentIndex == 0)
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
            string s = "";

            bool foundValue = false;
            bool foundKey = false;
            bool foundTag = false;
            bool valueIsBlock = false;

            KeyValue kv = null;
            List<KeyValue> kvList = new List<KeyValue>();
            
            //Get comments
            commentHeader += Useful.GetCommentHeader(ref file);

            //Get Key           
            s = Useful.GetElement(ref file);
            if(s != null)
            {
                key = s;
                foundKey = true;
            }
            else
                return null;
            //Get Value/Tag
            s = Useful.GetElement(ref file);
            if(s != null)
            {
                if(s.IndexOf('[') != -1)
                {
                    s = s.Replace("[","");
                    s = s.Replace("]","");
                    tag = s;
                    foundTag = true;
                    valueIsBlock = true;
                }
                else
                {
                    if((s == null) && (file.Length > 0))
                    {
                        valueIsBlock = true;
                    }
                    else
                    {
                        value = s;
                        foundValue = true;
                    }
                }
            }
            else
            {
                if(file[0] == '{')
                    valueIsBlock = true;
            }
            //Get Value/Tag
            if(!foundValue)
            {
                if(valueIsBlock)
                {
                    file = Useful.Seek(ref file);
                    if(file[0] == '{')
                    {
                        file = file.Remove(0,1);                        
                        while(file != "")
                        {
                            file = Useful.Seek(ref file);
                            KeyValue subKv = Parse(ref file);
                            if(subKv != null)
                            {
                                kvList.Add(subKv);
                                foundValue = true;
                            }
                            else
                            {
                                file = Useful.Seek(ref file);
                                if(file == "")
                                    break;
                                else if(file[0] == '}')
                                {
                                    file = file.Remove(0,1);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string ss = file;
                s = Useful.GetElement(ref ss);
                if(s != null)
                {
                    if(s.IndexOf('[') != -1)
                    {
                        s = s.Replace("[","");
                        s = s.Replace("]","");
                        tag = s;
                        foundTag = true;
                        file = ss;
                    }
                }
            }
            if(foundKey)
            {                
                kv = new KeyValue();
                kv.key = key;
            }
            if(commentHeader != "")
                kv.commentHeader = commentHeader;
            if(foundTag)
                kv.tag = tag;
            if(foundValue)
            {
                if(!valueIsBlock)
                    kv.value = value;
                else
                    kv.subKeyValues = kvList;
            }            
            return kv;
        }
    }
}