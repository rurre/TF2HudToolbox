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
using Microsoft.Win32;
using System.Resources;
using System.Threading;

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
                        
        bool helpEnabled = false;
        static Point formSize = new Point(497, 500);    //Different from designer value!!

        ResourceManager resourceManager = HudInstaller.Properties.Resources.ResourceManager;
        HudResourceFile localizationFile;
        HudResourceFile helpInfo;

        string gamePath;
        string installPath;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender,EventArgs e)
        {
            resourceManager.IgnoreCase = true;

            GetInstallPaths(folderBrowse_MainInstallPath,textBox_MainInstallPath);
            Width = formSize.X;
            Height = formSize.Y;
            CenterForm(this);

            ClearLabel(ref label_HudName);
            ClearLabel(ref label_HudAuthor);
            ClearLabel(ref label_HudVersion);
            ClearLabel(ref linkLabel_HudWebsite);

            SetLanguage(Languages.English);
        }

        void ClearLabel(ref Label label)
        {
            label.Text = "";
        }

        void ClearLabel(ref LinkLabel label)
        {
            label.Text = "";
        }

        
        void UpdateLabels()
        {               
            var labels = RefLib.GetAll(this,typeof(Label));
                        
            foreach(Label l in labels)
            {
                for(int i = 0; i < localizationFile.ToString().Length; i++)
                {
                    string s = l.Name;
                    if(i > 0)
                        s += i;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        l.Text = kv.Value;
                    else continue;                    
                }
            }
        }

        //Same code as UpdateLabels(). Figure out how to condense into 1 function.
        void UpdateButtons()
        {
            var buttons = RefLib.GetAll(this,typeof(Button));

            foreach(Button b in buttons)
            {
                for(int i = 0; i < localizationFile.ToString().Length; i++)
                {
                    string s = b.Name;
                    if(i > 0)
                        s += i;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        b.Text = kv.Value;
                    else continue;
                }
            }
        }
        //Same code as UpdateLabels(). Figure out how to condense into 1 function.
        void UpdateRadioButtons()
        {
            var all = RefLib.GetAll(this,typeof(RadioButton));

            foreach(RadioButton x in all)
            {
                for(int i = 0; i < localizationFile.ToString().Length; i++)
                {
                    string s = x.Name;
                    if(i > 0)
                        s += i;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        x.Text = kv.Value;
                    else continue;
                }
            }
        }
        //Same code as UpdateLabels(). Figure out how to condense into 1 function.
        void UpdateCheckBoxes()
        {
            var all = RefLib.GetAll(this,typeof(CheckBox));

            foreach(CheckBox x in all)
            {
                for(int i = 0; i < localizationFile.ToString().Length; i++)
                {
                    string s = x.Name;
                    if(i > 0)
                        s += i;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        x.Text = kv.Value;
                    else continue;
                }
            }
        }
        //Same code as UpdateLabels(). Figure out how to condense into 1 function.
        void UpdateGroupBoxes()
        {
            var all = RefLib.GetAll(this,typeof(GroupBox));

            foreach(GroupBox x in all)
            {
                for(int i = 0; i < localizationFile.ToString().Length; i++)
                {
                    string s = x.Name;
                    if(i > 0)
                        s += i;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        x.Text = kv.Value;
                    else continue;
                }
            }
        }

        void UpdateTabs()
        {
            var all = RefLib.GetAll(this,typeof(TabControl));
            foreach(TabControl x in all)
            {
                TabControl.TabPageCollection pages = x.TabPages;
                foreach(TabPage page in pages)
                {
                    string s = page.Controls.Owner.Name;
                    KeyValue kv = localizationFile.FindKeyValue(s);
                    if(kv != null)
                        page.Controls.Owner.Text = kv.Value;                    
                }

            }
        }

        protected void CenterForm(Form form)
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            form.Location = new Point()
            {
                X = Math.Max(workingArea.X,workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y,workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        public void GetInstallPaths(FolderBrowserDialog fbd,TextBox tb)
        {
            var steamPath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam","SteamPath",null);
            if(steamPath != null)
            {
                if(Directory.Exists(steamPath + "\\steamapps\\common\\team Fortress 2"))
                {
                    gamePath = steamPath + "\\steamapps\\common\\team Fortress 2";
                    gamePath = RefLib.PathToForwardSlashes(ref gamePath);
                    WriteStatus("Found TF2 at " + gamePath);
                    tb.Text = gamePath;
                    installPath = gamePath + "\\tf\\custom\\";
                    fbd.SelectedPath = gamePath;
                }
                else WriteStatus("Couldn't find TF2 install path, select an install folder manually");
            }                
        }

        public void WriteStatus(string s)
        {
            textBox_MainStatus.AppendText("-" + s + "\n");
        }

        bool ResourceExists(string resourceName)
        {
            if(resourceManager.GetObject(resourceName) != null)
                return true;
            else return false;
        }

        enum Languages { English, Russian };

        void SetLanguage()
        {
            SetLanguage(Languages.English);
        }

        void SetLanguage(Languages lang)
        {            
            try
            {                
                if(ResourceExists("toolbox_" + lang))                
                    localizationFile = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_" + lang).ToString() ?? "")));                
                else                
                    localizationFile = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));                    
                
                if(ResourceExists("helpInfo_" + lang))                
                    helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_" + lang).ToString() ?? "")));                
                else
                    helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_english").ToString() ?? "")));                
            }
            catch(Exception e)
            {
                throw e;
            }

            UpdateLabels();
            UpdateButtons();
            UpdateRadioButtons();
            UpdateGroupBoxes();
            UpdateCheckBoxes();
            UpdateTabs();      
        }

        #region Browse

        private void BrowseLogo(OpenFileDialog ofd,PictureBox pb,TextBox tb)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pb.ImageLocation = ofd.FileName;
                    tb.Text = ofd.FileName;

                }
                catch(Exception e)
                {
                    WriteStatus(e.Message);
                }
            }
        }

        void CombineHudBrowse(FolderBrowserDialog fbd,TextBox tb,TextBox hudName,PictureBox pb,Hud hud)
        {
            FragmentHudBrowse(fbd,tb,hudName,pb,hud,null,null,null,null,null);
        }

        void FragmentHudBrowse(FolderBrowserDialog fbd,TextBox tb,TextBox hudName,PictureBox pb, Hud hud,TextBox resName,TextBox resVersion,TextBox resAuthor,TextBox resWebsite, TextBox resLogo)
        {
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tb.Text = fbd.SelectedPath;

                if(File.Exists(fbd.SelectedPath + "\\hudinfo.txt"))
                {
                    WriteStatus("Found hudinfo.txt for " + hud.Name);
                    hud.Resource = HudParse.ParseHudResource(fbd.SelectedPath + "\\hudinfo.txt");                    
                }
                else
                {
                    WriteStatus("Couldn't find hudinfo.txt, using folder name for Hud name");
                    string s = fbd.SelectedPath.Remove(0,fbd.SelectedPath.LastIndexOf("\\")+1);

                    hud.Resource = new HudResourceFile("hudinfo","txt",fbd.SelectedPath,new List<KeyValue>()
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
                    hud.SetLogo(Image.FromFile(files[0]));                    
                }
                else
                {
                    WriteStatus("Couldn't find logo for " + hud.Resource.FindKeyValue("name").Value + ", using default");
                    hud.SetDeafaultLogo();
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
                if(resLogo != null)
                    resLogo.Text = files[0];
            }            
        }

        private void button_CombineBrowse1_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud1,textBox_CombineBrowse1,textBox_CombineHudName1,PictureBox_CombineHud1,combineHud1);
        }

        private void button_CombineBrowse2_Click(object sender,EventArgs e)
        {
            CombineHudBrowse(folderBrowse_CombineHud2,textBox_CombineBrowse2,textBox_CombineHudName2,PictureBox_CombineHud2,combineHud2);
        }

        private void button_FragmentLogoBrowse_Click(object sender,EventArgs e)
        {
            BrowseLogo(openFile_FragmentLogoBrowse,pictureBox_FragmentHudMain,textBox_Fragment_LogoBrowse);
        }

        #endregion

        private void button_Parse_Click(object sender,EventArgs e)
        {

        }

        private void button_FragmentMain_Click(object sender,EventArgs e)
        {
            WriteStatus("Parsing Hud...");
            fragmentHud.Resource = new HudResourceFile("hudinfo","txt",fragmentHud.Path,new List<KeyValue>()
            {
                new KeyValue("name",textBox_Fragment_Name.Text),
                new KeyValue("version",textBox_Fragment_Version.Text),
                new KeyValue("author",textBox_Fragment_Author.Text),
                new KeyValue("website",textBox_Fragment_Website.Text)
            });
                        
            Hud tempHud = hudParse.HudParse.ParseHud(folderBrowse_Fragment.SelectedPath);
            if(tempHud != null)
                fragmentHud.m_FolderList = tempHud.m_FolderList;
            else WriteStatus("Failed to parse Hud");
            

            //WriteStatus("Successfully Parsed Hud " + fragmentHud.Name);
        }        

        private void button_FragmentClearLogo_Click(object sender,EventArgs e)
        {
            textBox_Fragment_LogoBrowse.Text = "";
            openFile_FragmentLogoBrowse.FileName = null;
            fragmentHud.SetDeafaultLogo();
            pictureBox_FragmentHudMain.Image = fragmentHud.Logo;
        }

        private void button_Combine_Click(object sender,EventArgs e)
        {            
            if(textBox_CombineBrowse1.Text != textBox_CombineBrowse2.Text)
            {
                //Combine();
            }
            else WriteStatus("Can't combine a hud with itself");
            
        }

        #region Help - Sets help strings and stuff
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
            FragmentHudBrowse(folderBrowse_Fragment,textBox_FragmentHudBrowse,textBox_FragmentHudMain,pictureBox_FragmentHudMain,fragmentHud,textBox_Fragment_Name,textBox_Fragment_Version,textBox_Fragment_Author,textBox_Fragment_Website,textBox_Fragment_LogoBrowse);
            if(fragmentHud.HasDefaultLogo)
            {
                textBox_Fragment_LogoBrowse.Text = "";
                openFile_FragmentLogoBrowse.FileName = "";
            }
            else textBox_Fragment_LogoBrowse.Text = openFile_FragmentLogoBrowse.FileName;
        }

        private void button_ToggleHelp_Click(object sender,EventArgs e)
        {
            SetHelpToString("info_help");

            if(!helpEnabled)
            {
                Width = formSize.X + textBox_MainHelp.Width + 13;
                label_Help.Visible = true;
                textBox_MainHelp.Visible = true;
                textBox_MainHelpTitle.Visible = true;
                helpEnabled = true;
                CenterForm(this);                
            }
            else
            {
                Width = formSize.X;
                label_Help.Visible = false;
                textBox_MainHelp.Visible = false;
                textBox_MainHelpTitle.Visible = false;
                helpEnabled = false;
                CenterForm(this);
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

        #endregion

        #region UpdateFilePaths - Updates file paths when text boxes' text change

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

        private void textBox_Fragment_LogoBrowse_TextChanged(object sender,EventArgs e)
        {
            openFile_FragmentLogoBrowse.FileName = textBox_Fragment_LogoBrowse.Text;
        }

        private void textBox_MainBrowse_TextChanged(object sender,EventArgs e)
        {
            
        }

        private void textBox_MainInstallPath_TextChanged(object sender,EventArgs e)
        {
            folderBrowse_MainInstallPath.SelectedPath = textBox_MainInstallPath.Text;
        }

        #endregion

        private void button_MainInstallBrowseClear_Click(object sender,EventArgs e)
        {
            folderBrowse_MainInstallPath.SelectedPath = null;
            textBox_MainInstallPath.Text = "";
        }

        private void button_MainInstallBrowse_Click(object sender,EventArgs e)
        {
            if(folderBrowse_MainInstallPath.ShowDialog() == DialogResult.OK)
            {                
                gamePath = folderBrowse_MainInstallPath.SelectedPath;
                textBox_MainInstallPath.Text = gamePath;
            }
        }

    }
}
