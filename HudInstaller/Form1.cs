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
        Hud fragmentHud = new Hud();

        HudResourceFile helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(HudInstaller.Properties.Resources.helpinfo ?? "")));

        bool helpEnabled = false;
        int formWidth = 0;
        
        public void WriteStatus(string s)
        {
            textBox_MainStatus.AppendText("-" + s + "\n");
        }

        void CombineHudBrowse(FolderBrowserDialog fbd,TextBox tb,TextBox hudName,PictureBox pb,Hud hud)
        {
            FragmentHudBrowse(fbd,tb,hudName,pb,hud,null,null,null,null);
        }

        void FragmentHudBrowse(FolderBrowserDialog fbd,TextBox tb,TextBox hudName,PictureBox pb, Hud hud,TextBox resName,TextBox resVersion,TextBox resAuthor,TextBox resWebsite)
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

                    hud.Resource = new HudResourceFile("hudinfo",fbd.SelectedPath,new List<KeyValue>()
                    {
                        new KeyValue("name",s),
                        new KeyValue("author","Unknown"),
                        new KeyValue("version","Unknown"),
                        new KeyValue("website","Unknown")                        
                    });                    
                }
                hudName.Text = hud.Resource.FindKeyValue("name").Value;                
                hud.Path = fbd.SelectedPath;

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

                if(resName != null)
                    resName.Text = hud.Resource.FindKeyValue("name").Value;
                if(resAuthor != null)
                    resAuthor.Text = hud.Resource.FindKeyValue("author").Value;
                if(resVersion != null)
                    resVersion.Text = hud.Resource.FindKeyValue("version").Value;
                if(resWebsite != null)
                    resWebsite.Text = hud.Resource.FindKeyValue("website").Value;
            }            
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
            if(s != null)
            {
                KeyValue name = helpInfo.FindKeyValue(s + "_name");
                KeyValue desc = helpInfo.FindKeyValue(s + "_desc");

                if(name.Value == null)
                    s = "#Empty_String";
                else s = name.Value;
                textBox_MainHelpTitle.Text = s;

                if(desc.Value == null)
                    s = "#Empty_String";
                else s = desc.Value;
                textBox_MainHelp.Text = s;
            }
            else
            {
                textBox_MainHelpTitle.Text = "#Empty_String";
                textBox_MainHelp.Text = "#Empty_String";
            }
        }

        private void button_MinimalDefault_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_MinimalDefault");
        }

        private void button_Fragment_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_Fragment");
        }

        private void button_StripMinimal_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_StripMinimal");
        }

        private void button_MainBrowse_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_browse");
        }

        private void button_Customize_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_customize");
        }

        private void button_Install_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_install");
        }

        private void button_Parse_MouseHover(object sender,EventArgs e)
        {
            SetHelpToString("button_parse");
        }

        private void button_FragmentHudBrowse_Click(object sender,EventArgs e)
        {
            FragmentHudBrowse(folderBrowse_Fragment,textBox_FragmentHudBrowse,textBox_FragmentHudMain,pictureBox_FragmentHudMain,fragmentHud,textBox_Fragment_Name,textBox_Fragment_Version,textBox_Fragment_Author,textBox_Fragment_Website);
        }

        private void BrowseLogo(OpenFileDialog ofd, PictureBox pb)
        {

        }

        private void textBox_CombineBrowse2_TextChanged(object sender,EventArgs e)
        {
            folderBrowse_CombineHud2.SelectedPath = textBox_CombineBrowse2.Text;
        }

        private void textBox_CombineBrowse1_TextChanged(object sender,EventArgs e)
        {
            folderBrowse_CombineHud1.SelectedPath = textBox_CombineBrowse1.Text;
        }

        private void textBox_FragmentHudBrowse_TextChanged(object sender,EventArgs e)
        {
            folderBrowse_Fragment.SelectedPath = textBox_FragmentHudBrowse.Text;
        }

        private void textBox_MainBrowse_TextChanged(object sender,EventArgs e)
        {
            
        }

        private void button_ToggleHelp_Click(object sender,EventArgs e)
        {
            if(formWidth == 0)
                formWidth = this.Width;
            SetHelpToString("info_help");

            if(!helpEnabled)
            {                
                this.Width = formWidth + textBox_MainHelp.Width + 13;
                label_Help.Visible = true;
                textBox_MainHelp.Visible = true;
                textBox_MainHelpTitle.Visible = true;
                helpEnabled = true;
            }
            else
            {
                this.Width = formWidth;
                label_Help.Visible = false;
                textBox_MainHelp.Visible = false;
                textBox_MainHelpTitle.Visible = false;
                helpEnabled = false;
            }
        }

        private void tabControl_Main_Selecting(object sender,TabControlCancelEventArgs e)
        {
            if(helpEnabled)
            {
                switch(tabControl_Main.SelectedIndex)
                {
                    case 0:
                        SetHelpToString("tab_Installhud");
                        break;
                    case 1:
                        SetHelpToString("tab_Fragment");
                        break;
                    case 2:
                        SetHelpToString("tab_CombineHuds");
                        break;
                    case 3:
                        SetHelpToString("tab_About");
                        break;
                    default:
                        SetHelpToString(null);
                        break;
                }            
            }
        }

        private void button_ToggleHelp_MouseHover(object sender,EventArgs e)
        {

        }

        private void button_Parse_Click(object sender,EventArgs e)
        {            
            
        }

        private void button_FragmentMain_Click(object sender,EventArgs e)
        {
            WriteStatus("Parsing Hud");
            fragmentHud = hudParse.HudParse.ParseHud(folderBrowse_Fragment.SelectedPath);
            WriteStatus("Successfully Parsed Hud " + fragmentHud.Name);
        }
    }
}
