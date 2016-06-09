using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    class Hud
    {
        List<HudFile> files = new List<HudFile>();
        string hudPath;

        public Hud()
        {
        }

        public Hud(string filepath)
        {
            Hud h = ParseHud(filepath);
            this.files = h.files;
        }

        Hud ParseHud(string filepath)
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
                            h.files.Add(hf);
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
    }
}
