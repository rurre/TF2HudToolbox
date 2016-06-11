using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    class Hud
    {
        //Variables
        List<HudFile> files = new List<HudFile>();
        HudFile resource = null;

        string hudPath,name,author,website,version;

        bool hasDefaultLogo;
        Image logo;

        //Properties
        public HudFile Resource
        {
            get
            {
                return resource;
            }
            set
            {
                resource = value;
                KeyValue kv = resource.FindKeyValue("*");

                name = kv.FindSubKeyValue("name").Value;
                author = kv.FindSubKeyValue("author").Value;
                version = kv.FindSubKeyValue("version").Value;
                website = kv.FindSubKeyValue("website").Value;
            }
        }
        public Image Logo
        {
            get
            {
                return logo;
            }
            set
            {
                logo = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Author
        {
            get
            {
                return Author;
            }
        }
        public string Website
        {
            get
            {
                return website;
            }
        }
        public string Version
        {
            get
            {
                return version;
            }
        }
        public bool HasDefaultLogo
        {
            get
            {
                return hasDefaultLogo;
            }
            set
            {
                hasDefaultLogo = value;
            }
        }
        public int FileCount
        {
            get
            {
                return files.Count;
            }          
        }
        
        //Constructors
        public Hud()
        {
        }

        public Hud(HudFile resource)
        {
            Resource = resource;
        }

        public Hud(string filepath)
        {
            Hud h = ParseHud(filepath);
            this.files = h.files;            
        }

        //Methods
        public static Hud ParseHud(string filepath)
        {
            Hud h = new Hud();
            h.hudPath = filepath;            

            var folders = Directory.GetDirectories(filepath);            
            for(int i = 0; i < folders.Length; i++)
            {
                if(folders[i].ToLower().EndsWith("\\resource") || (folders[i].ToLower().EndsWith("\\scripts")))
                {
                    var files = Useful.GetFiles(filepath, SearchOption.AllDirectories, new string[] { "res" });
                    for(int j = 0; j < files.Length; j++)
                    {
                        HudFile hf = HudFile.ParseFromPath(files[i]);
                        if(hf != null)
                        {
                            h.files.Add(hf);
                            //HudInstaller.MainForm._progress.Value = HudInstaller.MainForm._progress.Value++;
                        }
                    }
                }
            }

            foreach(HudFile f in h.files)
            {
                f.MakeFilePathsRelative(h.hudPath);
            }
            return h;           
        }

        public override string ToString()
        {
            string s = "";
            foreach(HudFile hf in files)
            {
                s += hf.ToString();
            }
            return s;
        }

        int write()
        {
            /*List<String> errors = new List<String>();
            foreach(HudFile f in files)
            {                
                    errors.Add(Error.toString(result,f.Path));
            }
            switch(errors.Count)
            {
                case 0:
                    return 0;
                default:
                    break;
            }*/
            return 0;
        }

        public void ParseResource(string filepath)
        {
            if(File.Exists(filepath))
                Resource = HudFile.ParseFromPath(filepath);
        }        
    }
}
