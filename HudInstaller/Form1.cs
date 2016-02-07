using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using hudParse;
using Microsoft.Win32;
using System.Resources;

namespace HudInstaller
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string s);

        #region Variables

        Hud mainHud = new Hud();
        Hud defaultHud = new Hud();
        Hud combineHud1 = new Hud();
        Hud combineHud2 = new Hud();
        Hud combineHudResult = new Hud();
        Hud fragmentHud = new Hud();

        string gamePath;
        string installPath;

        Languages language;
        Jobs job;
        bool working = false;
        bool silentCancel = false;              
        bool helpEnabled = false;
        static Point formSize = new Point(497, 500);    //Different from designer value!!
        SettingsForm Settings = new SettingsForm();
        ResourceManager resourceManager = HudInstaller.Properties.Resources.ResourceManager;
        HudResourceFile localizationFile;
        HudResourceFile helpInfo;
        
        public enum Languages { English, Test };
        enum Jobs { None, Parse, Fragment, Combine, Install };


        #endregion

        #region Properties

        public Languages Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        #endregion

        #region Form Functions

        public MainForm()
        {
            InitializeComponent();
            localizationFile = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));
            if(localizationFile.IsEmpty)
                throw new Exception("localizationFile is empty!");
            helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_English").ToString() ?? "")));            
            if(helpInfo.IsEmpty)
                throw new Exception("helpInfo is empty!");
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

            SetLanguageDefault();

#if(DEBUG)
            WriteStatus("!!!!Debug build!!!!");
            WriteStatus("Debugging Fragment Hud");
            folderBrowse_Fragment.SelectedPath = "D:\\Desktop\\testhud\\";
            textBox_FragmentHudBrowse.Text = folderBrowse_Fragment.SelectedPath;
            tabControl_Main.SelectedIndex = 1;
#endif
        }


        public void WriteStatus(string s)
        {
            if(this.textBox_MainStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(WriteStatus);
                this.Invoke(d,new object[] { s + "\n" });            
            }
            else
            {
                textBox_MainStatus.AppendText("-" + s + "\n");
            }
        }

#endregion

#region UI Functions
        /// <summary>
        /// Sets a label's text value to null.
        /// </summary>
        /// <param name="label"></param>
        void ClearLabel(ref Label label)
        {
            label.Text = "";
        }

        /// <summary>
        /// Sets a linklabel's text value to null.
        /// </summary>
        /// <param name="label"></param>
        void ClearLabel(ref LinkLabel label)
        {
            label.Text = "";
        }

        /// <summary>
        /// Updates Labels', Buttons', GroupBoxes', CheckBoxes', RadioButtons' and Tabs' text values to the language selected.
        /// Values are taken from toolbox_language.txt
        /// </summary>
        void UpdateLocalizationText()
        {            
            UpdateControlText<Label>();
            UpdateControlText<Button>();
            UpdateControlText<GroupBox>();
            UpdateControlText<CheckBox>();
            UpdateControlText<RadioButton>();
            UpdateControlText<TabControl>();
        }

        /// <summary>
        /// See UpdateLocalizationText()
        /// </summary>
        /// <typeparam name="T">Type name to use.</typeparam>
        void UpdateControlText<T>() where T : class
        {
            if(typeof(T) == typeof(Button) || typeof(T) == typeof(Label) || typeof(T) == typeof(RadioButton) || typeof(T) == typeof(CheckBox) || typeof(T) == typeof(GroupBox))
            {
                var all = RefLib.GetAll(this,typeof(T));
                foreach(var x in all)
                {
                    string ss = x.Name;
                    KeyValue kv = localizationFile.FindKeyValueIgnoreEndNr(ss);
                    if(kv != null)
                        x.Text = kv.Value;
                }
            }
            else if(typeof(T) == typeof(TabControl))
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
            else throw new Exception("Invalid type " + typeof(T));            
        }

        /// <summary>
        /// Centers the form to the screen.
        /// </summary>
        /// <param name="form"></param>
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

        /// <summary>
        /// Centers the form to the screen on the X axis only.
        /// </summary>
        /// <param name="form"></param>
        protected void CenterFormHorizontally(Form form)
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            int temp = form.Location.Y;
            form.Location = new Point()
            {
                X = Math.Max(workingArea.X,workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = temp
            };
        }

        /// <summary>
        /// Sets the Application's language to English.
        /// Ran at the start of the form to update all the labels and buttons to match toolbox_english.txt.
        /// </summary>
        void SetLanguageDefault()
        {
            Language = Languages.English;
            helpInfo = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_english").ToString() ?? "")));
            localizationFile = HudParse.ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));
            UpdateLocalizationText();
            SetHelpToString("info_help");            
        }

        /// <summary>
        /// Changes the Application language and updates the controls' text.
        /// </summary>
        /// <param name="lang">Language from the Languages enum</param>
        void SetLanguage(Languages lang)
        {            
            if(lang != Language)
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
                    SetHelpToString("info_help");
                    UpdateLocalizationText();
                }
                catch(Exception e)
                {
                    throw e;
                }
                Language = lang;
            }
        }

#endregion

#region Browse - Browsing related functions

        /// <summary>
        /// Browse for a logo.
        /// </summary>
        /// <param name="ofd">OpenFileDialog to set logo path in</param>
        /// <param name="pb">PictureBox to show preview in </param>
        /// <param name="tb">TextBox to display file path in</param>
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
                    hud.Resource = HudParse.ParseHudResource(fbd.SelectedPath + "\\hudinfo.txt");
                    hud.ApplyResource();
                    WriteStatus("Found hudinfo.txt for " + hud.Name);                                     
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

        private void button_FragmentClearLogo_Click(object sender,EventArgs e)
        {
            textBox_Fragment_LogoBrowse.Text = "";
            openFile_FragmentLogoBrowse.FileName = null;
            fragmentHud.SetDeafaultLogo();
            pictureBox_FragmentHudMain.Image = fragmentHud.Logo;
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

#endregion

#region Help - Sets help strings and stuff
        /// <summary>
        /// Sets help to a string from inside helpinfo.txt resource. Appends _name and _desc automatically to get name and description.
        /// </summary>
        /// <param name="s">String name as appears in helpinfo.txt, without _name or _desc suffix.</param>
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
                CenterFormHorizontally(this);                
            }
            else
            {
                Width = formSize.X;
                label_Help.Visible = false;
                textBox_MainHelp.Visible = false;
                textBox_MainHelpTitle.Visible = false;
                helpEnabled = false;
                CenterFormHorizontally(this);
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

#region Buttons - Click events
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

        private void button_Settings_Click(object sender,EventArgs e)
        {
            Settings.OldLanguage = (int)Language;
            if(Settings.ShowDialog() == DialogResult.OK)
            {
                Languages temp = (Languages)Settings.NewLanguage;                
                SetLanguage(temp);
            }            
        }

        private void button_Parse_Click(object sender,EventArgs e)
        {            
            if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Parse;
                working = true;
                UpdateButtonState();
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void button_FragmentMain_Click(object sender,EventArgs e)
        {
            /*if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Fragment;
                working = true;
                UpdateButtonState();
                backgroundWorker.RunWorkerAsync();
            }*/

            if(folderBrowse_Fragment.SelectedPath != "")
            {
                WriteStatus("Attempting to Create Hud Blueprint...");
                WriteStatus("This is just a mockup. It doesn't actually do anything yet.");
                Hud tempFragment = new Hud();

                tempFragment = HudParse.ParseHud(folderBrowse_Fragment.SelectedPath);
                tempFragment.Resource = fragmentHud.Resource;

            }
            else
            {
                WriteStatus("Select a Hud folder first");
                silentCancel = true;
                backgroundWorker.CancelAsync();
            }

        }

        private void button_Install_Click(object sender,EventArgs e)
        {
            if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Install;
                working = true;
                UpdateButtonState();
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void button_Combine_Click(object sender,EventArgs e)
        {            
            if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Combine;
                working = true;
                UpdateButtonState();
                backgroundWorker.RunWorkerAsync();
            }
            /*if(textBox_CombineBrowse1.Text != textBox_CombineBrowse2.Text)
            {
                //Combine();
            }
            else WriteStatus("Can't combine a hud with itself");*/

        }

        private void button_MainCancel_Click(object sender,EventArgs e)
        {
            if(backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            else throw new Exception("Attempted to cancel while backgroundWorker wasn't working. Button should be disabled");
            button_MainCancel.Enabled = false;
        }

#endregion

#region General Functions
        /// <summary>
        /// Checks the Windows Registry for the Steam install path and figures out the TF2 path from there
        /// </summary>
        /// <param name="fbd">Folder browser dialog to set path in</param>
        /// <param name="tb">Text box representing the selected path</param>
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
        /// <summary>
        /// Checks if a resource exists.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns>Returns bool</returns>
        bool ResourceExists(string resourceName)
        {
            if(resourceManager.GetObject(resourceName) != null)
                return true;
            else return false;
        }
        /// <summary>
        /// Checks if out backgroundWorker is busy, if so buttons get disabled and cancel enabled
        /// </summary>
        private void UpdateButtonState()
        {
            if(working)
            {
                button_Parse.Enabled = false;
                button_MinimalDefault.Enabled = false;
                button_StripMinimal.Enabled = false;
                button_Install.Enabled = false;
                button_FragmentMain.Enabled = false;
                button_Combine.Enabled = false;
                button_Customize.Enabled = false;

                button_MainCancel.Enabled = true;
            }
            else
            {
                button_Parse.Enabled = true;
                button_MinimalDefault.Enabled = true;
                button_StripMinimal.Enabled = true;
                button_Install.Enabled = true;
                button_FragmentMain.Enabled = true;
                button_Combine.Enabled = true;
                button_Customize.Enabled = true;

                button_MainCancel.Enabled = false;
            }
        }

#endregion

        private void backgroundWorker_DoWork(object sender,System.ComponentModel.DoWorkEventArgs e)
        {
            if(job == Jobs.Parse)
            {
                WriteStatus("Attempting to parse Hud...");
                WriteStatus("This is just a mockup. It doesn't actually do anything yet.");
            }
            else if(job == Jobs.Combine)
            {
                WriteStatus("Attempting to Combine Huds...");
                WriteStatus("This is just a mockup. It doesn't actually do anything yet.");
            }
            else if(job == Jobs.Install)
            {
                WriteStatus("Attempting to Install Hud...");
                WriteStatus("This is just a mockup. It doesn't actually do anything yet.");
            }
            else if(job == Jobs.Fragment)
            {
                /*if(folderBrowse_Fragment.SelectedPath != "")
                {
                    WriteStatus("Attempting to Create Hud Blueprint...");
                    WriteStatus("This is just a mockup. It doesn't actually do anything yet.");
                    Hud tempFragment = new Hud();

                    tempFragment = HudParse.ParseHud(folderBrowse_Fragment.SelectedPath);
                    tempFragment.Resource = fragmentHud.Resource;

                }
                else
                {
                    WriteStatus("Select a Hud folder first");
                    silentCancel = true;
                    backgroundWorker.CancelAsync();
                }   */             
            }
            else
                throw new Exception("backgroundWorker asked to do work but a job wasn't assigned");
            /*
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
            else WriteStatus("Failed to parse Hud");*/

            //Use if statement to check for job to do.            
            for(int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                backgroundWorker.ReportProgress(i);

                if(backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker.ReportProgress(0);
                    return;
                }
            }
            //e.Result = new Hud();     
        }

        private void backgroundWorker_ProgressChanged(object sender,System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar_Main.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender,System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                if(!silentCancel)
                {
                    switch(job)
                    {
                        case (Jobs.Combine):
                            WriteStatus("Cancelled Combine operation");
                            break;
                        case (Jobs.Fragment):
                            WriteStatus("Cancelled Blueprint creation");
                            break;
                        case (Jobs.Parse):
                            WriteStatus("Cancelled Parsing operation");
                            break;
                        case (Jobs.Install):
                            WriteStatus("Cancelled Hud Install");
                            break;
                        default:
                            throw new Exception("backgroundWorker stopped working but job wasn't reported");
                    }
                }            
            }
            else if(e.Error != null)
            {
                //throw new Exception("Some error occured during backgroundWorker doing work.");
                WriteStatus(e.Error.Message);
            }
            else
            {                
                switch(job)
                {
                    case (Jobs.Combine):
                        WriteStatus("Successfully Combined Huds");
                        break;
                    case (Jobs.Fragment):
                        WriteStatus("Successfully created Blueprint from Hud");
                        break;
                    case (Jobs.Parse):
                        WriteStatus("Successfully completed Parsing Hud");
                        break;
                    case (Jobs.Install):
                        WriteStatus("Succesfully Installed Hud");
                        break;
                    default:
                        throw new Exception("backgroundWorker finished working but job wasn't reported");
                }                                
            }
            
            working = false;
            job = Jobs.None;                        
            progressBar_Main.Value = 0;
            UpdateButtonState();

            if(silentCancel)
                silentCancel = false;
        }
    }
}
