using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudParse
{
    static class Error
    {
        public enum errors
        {
            InvalidPath            
        };

        public static String toString(errors id, String path)
        {
            string err = "ERROR: An error has occured in " + path + " - ";
            switch(id)
            {                
                case errors.InvalidPath:
                    err += "Filepath is invalid";
                    break;                
                default:
                    err += "Something went wrong...";                    
                    break;
            }
            return err;
        }
    }
}
