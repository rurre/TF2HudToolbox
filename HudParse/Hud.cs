using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    class Hud
    {
        List<HudFile> files;

        Hud()
        {
        }

        Hud ParseHud(string filepath)
        {
            return new Hud();            
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
