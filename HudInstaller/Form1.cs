using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using hudParse;

namespace HudInstaller
{
    public partial class mainForm : Form
    {
        //Variables
        Hud hud1 = new Hud();
        Hud hud2 = new Hud();
               

        public enum readModes { KeyValue, PlatformTag };
        /// <summary>
        /// Looks for the first value it can find enclosed in quotes or square brackets.
        /// </summary>
        /// <param name="s">Target string to look in.</param>
        /// <returns>Returns the value enclosed in quotes or square brackets.</returns>

        private static string Rd(string s)
        {
            return Rd(ref s,readModes.KeyValue);            
        }
        private static string Rd(ref string s,readModes mode)
        {
            string result = "";
            bool openedQuotes = false;

            for(int i = 0; i < s.Length; i++)
            {
                if(mode == readModes.KeyValue)
                {
                    if(s[i] == '\"')
                    {
                        if(!openedQuotes)
                        {
                            openedQuotes = true;
                            continue;
                        }
                        else break;
                    }
                    else if(openedQuotes)
                    {
                        result += s[i];
                        continue;
                    }
                }
                else if(mode == readModes.PlatformTag)
                {
                    if(s[i] == '[')
                    {
                        if(!openedQuotes)
                        {
                            openedQuotes = true;
                            continue;
                        }
                        else break;
                    }
                    else if(openedQuotes)
                    {
                        if(s[i] == ']')
                            break;
                        result += s[i];
                    }
                }
                else throw new Exception("Error: Something went wrong when trying to Read(). This isn't supposed to be possible. Help!");
            }
            return result;
        }

        public void WriteStatus(string s)
        {
            textBox_MainStatus.AppendText("-" + s + "\n");
        }

        void CombineHudBrowse(FolderBrowserDialog fbd,TextBox tb,TextBox hudName,PictureBox pb, Hud hud)
        {
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tb.Text = fbd.SelectedPath;

                if(File.Exists(fbd.SelectedPath + "\\hudinfo.res"))
                {
                    WriteStatus("Found hudinfo.res");
                    hud.Resource = HudParse.ParseHudResource(fbd.SelectedPath + "\\hudinfo.res");                    
                }
                else
                {
                    WriteStatus("Couldn't find hudinfo.res, using folder name for hud name");
                    string s = fbd.SelectedPath.Remove(0,fbd.SelectedPath.LastIndexOf("\\")+1);
                    hud.Resource = new HudResourceFile("hudinfo",fbd.SelectedPath,new List<KeyValue>() { new KeyValue("name",s) });                    
                }
                hudName.Text = hud.Resource.FindKeyValue("name").Value;
            }

            var files = Directory.GetFiles(fbd.SelectedPath,"logo.*");
            if(files.Length > 0)
            {
                pb.ImageLocation = files[0];
                WriteStatus("Found logo for " + hud.Resource.FindKeyValue("name").Value);
            }
            else
            {
                WriteStatus("Couldn't find logo for " + hud.Resource.FindKeyValue("name").Value + ", using default");
                pb.Image = HudInstaller.Properties.Resources.logo_default;
            }
        }


        public mainForm()
        {
            InitializeComponent();
        }

        private void button_CombineBrowse1_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud1,textBox_CombineBrowse1,textBox_CombineHudName1,PictureBox_CombineHud1,hud1);
        }

        private void button_CombineBrowse2_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud2,textBox_CombineBrowse2,textBox_CombineHudName2,PictureBox_CombineHud2,hud2);
        }
    }
}
