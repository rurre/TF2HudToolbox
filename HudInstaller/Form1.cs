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
using System.Reflection;

namespace HudInstaller
{
    public partial class mainForm : Form
    {
        //Variables
        Hud mainHud = new Hud();
        Hud defaultHud = new Hud();

        Hud combineHud1 = new Hud();
        Hud combineHud2 = new Hud();
        Hud combineHudResult = new Hud();

        HudResourceFile helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(HudInstaller.Properties.Resources.helpinfo ?? "")));
               
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
                hud.Path = fbd.SelectedPath;                
            }

            var files = Directory.GetFiles(fbd.SelectedPath,"logo.*");
            if(files.Length > 0)
            {                
                WriteStatus("Found logo for " + hud.Resource.FindKeyValue("name").Value);
                hud.Logo = Image.FromFile(files[0]);                
            }
            else
            {
                WriteStatus("Couldn't find logo for " + hud.Resource.FindKeyValue("name").Value + ", using default");                
                hud.Logo = HudInstaller.Properties.Resources.logo_default;
            }
            pb.Image = hud.Logo;
            WriteStatus("Path of " + hudName.Text + " is " + hud.Path);
        }

        public Hud CombineHuds(Hud hud1,Hud hud2)
        {
            Hud result = new Hud();

            return result;
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void button_CombineBrowse1_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud1,textBox_CombineBrowse1,textBox_CombineHudName1,PictureBox_CombineHud1,combineHud1);
        }

        private void button_CombineBrowse2_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud2,textBox_CombineBrowse2,textBox_CombineHudName2,PictureBox_CombineHud2,combineHud2);
        }

        private void button_Combine_Click(object sender,EventArgs e)
        {            
            if(textBox_CombineBrowse1.Text != textBox_CombineBrowse2.Text)
            {
                //Combine();
            }
            else WriteStatus("Can't combine a hud with itself");
            
        }

        private void SetHelpToString(string s)
        {
            textBox_MainHelpTitle.Text = button_MinimalDefault.Text;
            s = helpInfo.FindKeyValue(s).Value;
            if(s == null)
                s = "#Empty_string";
            textBox_MainHelp.Text = s;
        }

        private void button_MinimalDefault_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_MinimalDefault_desc");
        }

        private void button_Fragment_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_Fragment_desc");
        }

        private void button_StripMinimal_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_StripMinimal_desc");
        }

        private void button_MainBrowse_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_browse_desc");
        }

        private void button_Customize_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_customize_desc");
        }

        private void button_Install_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_install_desc");
        }

        private void button_Parse_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_parse_desc");
        }
    }
}
