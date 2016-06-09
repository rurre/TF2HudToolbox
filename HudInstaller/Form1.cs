using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Resources;
using System.Diagnostics;
using HudParse;

namespace HudInstaller
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string s);
        delegate void SetProgressBarMaxCallback(int i);
        delegate void SetProgressBarValueCallback(int i);

        #region Variables        
                
        Hud fragmentHud = new Hud();
        Hud defaultHud = new Hud();
        Hud combineHud1 = new Hud();
        Hud combineHud2 = new Hud();

        string gamePath;
        string installPath;

        Languages language;
        Jobs job;
        bool working = false;
        bool silentCancel = false;              
        bool helpEnabled = false;
        bool gameInstalled = false;
        bool defaultHudParsed = false;

        string applicationPath = AppDomain.CurrentDomain.BaseDirectory;

        static Point formSize = new Point(497, 500);    //Different from designer value!!
        SettingsForm Settings = new SettingsForm();
        static ResourceManager resourceManager = Properties.Resources.ResourceManager;

        static HudFile localizationFile = null;
                       

#if DEBUG
        public enum Languages { English, Test };
#else
        public enum Languages { English };        
#endif
        enum Jobs { None, Parse, GetDefaultHud , ParseDefaultHud , Fragment, Combine ,Install, Error };

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
            string toolbox = resourceManager.GetObject("toolbox_english").ToString();
            localizationFile = HudFile.Parse(ref toolbox);
            if(localizationFile == null)
                throw new Exception("localizationFile is empty!");            
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

        public void SetProgressBarMax(int i)
        {
            if(this.progressBar_Main.InvokeRequired)
            {
                SetProgressBarMaxCallback d = new SetProgressBarMaxCallback(SetProgressBarMax);
                this.Invoke(d,i);                
            }
            else
            {
                progressBar_Main.Maximum = i;
            }
        }

        public void SetProgressBarValue(int i)
        {
            if(this.progressBar_Main.InvokeRequired)
            {
                SetProgressBarValueCallback d = new SetProgressBarValueCallback(SetProgressBarValue);
                this.Invoke(d,progressBar_Main.Value = i);
            }
            else
            {
                if(progressBar_Main.Value + i > progressBar_Main.Maximum)
                    progressBar_Main.Value = progressBar_Main.Maximum;
                else
                    progressBar_Main.Value += i;
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
            KeyValue toolbox;
            if((toolbox = localizationFile.FindKeyValue("toolbox")) == null)
                throw new Exception("Can't find toolbox in localization file");

            if(typeof(T) == typeof(Button) || typeof(T) == typeof(Label) || typeof(T) == typeof(RadioButton) || typeof(T) == typeof(CheckBox) || typeof(T) == typeof(GroupBox))
            {                
                var all = RefLib.GetAll(this,typeof(T));
                foreach(var x in all)
                {
                    string ss = x.Name;
                    KeyValue kv = toolbox.FindSubKeyValueIgnoreEndNr(ss);
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
                        KeyValue kv = toolbox.FindSubKeyValue(s);
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
            KeyValue helpInfo;
            if((helpInfo = localizationFile.FindKeyValue("helpinfo")) == null)
                throw new Exception("Can't find helpinfo in localizationFile");            
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
                    string s = null;
                    if(ResourceExists("toolbox_" + lang))                    
                        s = resourceManager.GetObject("toolbox_" + lang).ToString();                                            
                    else                    
                        s = resourceManager.GetObject("toolbox_english").ToString();
                    if(s != null)
                        localizationFile = HudFile.Parse(ref s);
                    else
                        throw new Exception("Can't parse localization file");
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
                    //hud.Resource = ParseHudResource(fbd.SelectedPath + "\\hudinfo.txt");
                    //hud.ApplyResource();
                    //WriteStatus("Found hudinfo.txt for " + hud.Name);                                     
                }
                else
                {
                    WriteStatus("Couldn't find hudinfo.txt, using folder name for Hud name");
                    string s = fbd.SelectedPath.Remove(0,fbd.SelectedPath.LastIndexOf("\\")+1);

                    /*hud.Resource = new HudResourceFile("hudinfo","txt",fbd.SelectedPath,new List<KeyValue>()
                    {
                        new KeyValue("name",s),
                        new KeyValue("author","Unknown"),
                        new KeyValue("version","Unknown"),
                        new KeyValue("website","Unknown")                        
                    });                    */
                }
                //hudName.Text = hud.Resource.FindKeyValue("name").Value;                
                //hud.FullName = fbd.SelectedPath;

                var files = Directory.GetFiles(fbd.SelectedPath,"logo.*");
                if(files.Length > 0)
                {
                    //WriteStatus("Found logo for " + hud.Resource.FindKeyValue("name").Value);
                    //hud.SetLogo(Image.FromFile(files[0]));                    
                }
                else
                {
                    //WriteStatus("Couldn't find logo for " + hud.Resource.FindKeyValue("name").Value + ", using default");
                    //hud.SetDeafaultLogo();
                }
                //pb.Image = hud.Logo;
                //WriteStatus("Path of " + hudName.Text + " is " + hud.Path);

                /*if(resName != null)
                    resName.Text = hud.Resource.FindKeyValue("name").Value;
                if(resAuthor != null)
                    resAuthor.Text = hud.Resource.FindKeyValue("author").Value;
                if(resVersion != null)
                    resVersion.Text = hud.Resource.FindKeyValue("version").Value;
                if(resWebsite != null)
                    resWebsite.Text = hud.Resource.FindKeyValue("website").Value;
                if(resLogo != null)
                {
                    if(files.Length > 0)
                        resLogo.Text = files[0];
                }*/
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
            /*textBox_Fragment_LogoBrowse.Text = "";
            openFile_FragmentLogoBrowse.FileName = null;
            fragmentHud.SetDeafaultLogo();
            pictureBox_FragmentHudMain.Image = fragmentHud.Logo;*/
        }

        private void button_FragmentHudBrowse_Click(object sender,EventArgs e)
        {
            /*FragmentHudBrowse(folderBrowse_Fragment,textBox_FragmentHudBrowse,textBox_FragmentHudMain,pictureBox_FragmentHudMain,fragmentHud,textBox_Fragment_Name,textBox_Fragment_Version,textBox_Fragment_Author,textBox_Fragment_Website,textBox_Fragment_LogoBrowse);
            if(fragmentHud.HasDefaultLogo)
            {
                textBox_Fragment_LogoBrowse.Text = "";
                openFile_FragmentLogoBrowse.FileName = "";
            }
            else textBox_Fragment_LogoBrowse.Text = openFile_FragmentLogoBrowse.FileName;*/
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
                KeyValue helpInfo = localizationFile.FindKeyValue("helpinfo");
                KeyValue name = helpInfo.FindSubKeyValue(s + "_name");
                KeyValue desc = helpInfo.FindSubKeyValue(s + "_desc");

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
                SetProgressBarValue(0);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void button_FragmentMain_Click(object sender,EventArgs e)
        {            
            if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Fragment;
                working = true;
                UpdateButtonState();
                SetProgressBarValue(0);
                backgroundWorker.RunWorkerAsync();
            }
        }

        void pr_OutputDataReceived(object sender,DataReceivedEventArgs e)
        {
            WriteStatus(e.Data);
        }

        private void button_Install_Click(object sender,EventArgs e)
        {
            if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Install;
                working = true;
                UpdateButtonState();
                SetProgressBarValue(0);
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
                SetProgressBarValue(0);
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

        private void GetDefaultHud()
        {            
            /*Jobs oldJob = job;
            Jobs newJob = Jobs.ParseDefaultHud;
                                     
            try
            {
                WriteStatus("Grabbing default Hud.");

                string temp = System.IO.Path.GetTempPath();

                if(Directory.Exists(temp + "HudToolbox\\DefaultHud"))
                    Directory.Delete(temp + "HudToolbox\\DefaultHud",true);
                Directory.CreateDirectory(temp + "HudToolbox\\DefaultHud");                

                Process proc = new Process();                
                proc.StartInfo.FileName = applicationPath + "HLExtract.exe";
                proc.StartInfo.Arguments = "-p \"" + gamePath + "\\tf\\tf2_misc_dir.vpk\" -d \"" + temp + "HudToolbox\\DefaultHud\"" + " -e \"resource\" -e \"scripts\" -v";
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                proc.Start();
                proc.WaitForExit();


                SetProgressBarMax(GetFiles(temp + "\\HudToolbox\\DefaultHud\\").Count*2);

                WriteStatus("Got default Hud. Attempting to Parse");                
                defaultHud = ParseHud(temp + "\\HudToolbox\\DefaultHud");
                WriteStatus("Successfully Parsed Default Hud");

                job = oldJob;
                defaultHudParsed = true;
            }
            catch(Exception e)
            {
                defaultHudParsed = false;
                throw e;                
            }        */
        }


        private void backgroundWorker_DoWork(object sender,System.ComponentModel.DoWorkEventArgs e)
        {
            if(!gameInstalled)
            {
                bool hlExtractFound = false;
                bool vpkFound = false;
                if(File.Exists(applicationPath + "\\HlExtract.exe") && File.Exists(applicationPath + "\\HLLib.dll"))
                    hlExtractFound = true;
                else
                    WriteStatus("HLExtract.exe and/or HLLib.dll not found in " + applicationPath);

                if(File.Exists(folderBrowse_MainInstallPath.SelectedPath + "/tf/tf2_misc_dir.vpk"))
                    vpkFound = true;
                else
                    WriteStatus(gamePath + "/tf/tf2_misc_dir.vpk Not found");

                if(!hlExtractFound || !vpkFound)
                {
                    WriteStatus("Can't continue until the above issues are resolved");
                    job = Jobs.Error;
                }
                else gameInstalled = true;
            }

            if(gameInstalled && !defaultHudParsed)
            {                
                GetDefaultHud();
            }

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
               /* if(folderBrowse_Fragment.SelectedPath != "")
                {
                    WriteStatus("Attempting to Create Hud Blueprint...");
                    Hud tempFragment = new Hud();

                    //Set progress bar to length of nr of files in hud and increment bar by 1 after each file parsed
                    var allHudfiles =  Directory.GetFiles(folderBrowse_Fragment.SelectedPath, "*", SearchOption.AllDirectories);
                    var filesInThisFolder = Directory.GetFiles(folderBrowse_Fragment.SelectedPath, "*");

                    SetProgressBarMax(GetFiles(folderBrowse_Fragment.SelectedPath,true).Count + defaultHud.FileCount);

                    tempFragment = ParseHud(folderBrowse_Fragment.SelectedPath);
                    tempFragment.Resource = fragmentHud.Resource;
                    tempFragment.Path = fragmentHud.Path;
                    if(!fragmentHud.HasDefaultLogo)
                        tempFragment.Logo = fragmentHud.Logo;

                    fragmentHud = tempFragment;
                    fragmentHud.ApplyResource();

                    foreach(HudFolder folder in fragmentHud.m_FolderList)
                    {
                        foreach(HudFile file in folder.m_FileList)
                        {
                            //file.CheckIfDefault(
                        }
                    }
                }
                else
                {
                    WriteStatus("Select a Hud folder first");
                    silentCancel = true;
                    backgroundWorker.CancelAsync();
                }*/
            }
            else if(job == Jobs.Error)
            {
                backgroundWorker.CancelAsync();
            }
            else
                throw new Exception("backgroundWorker asked to do work but a job wasn't assigned");            
        }

        private void backgroundWorker_ProgressChanged(object sender,System.ComponentModel.ProgressChangedEventArgs e)
        {
            SetProgressBarValue(e.ProgressPercentage);
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
                            combineHud1 = new Hud();
                            combineHud2 = new Hud();
                            break;
                        case (Jobs.Fragment):
                            WriteStatus("Cancelled Blueprint creation");
                            fragmentHud = new Hud();
                            break;
                        case (Jobs.Parse):
                            WriteStatus("Cancelled Parsing operation");
                            defaultHud = new Hud();                            
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
                WriteStatus(e.Error.Message);
                switch(job)
                {
                    case (Jobs.Combine):
                        combineHud1 = new Hud();
                        combineHud2 = new Hud();
                        break;
                    case (Jobs.Fragment):
                        fragmentHud = new Hud();
                        break;
                    case (Jobs.Parse):
                        defaultHud = new Hud();
                        defaultHudParsed = false;
                        break;
                    default:
                        throw new Exception("Something went wrong. Resetting ~everything~");                       
                }
                job = Jobs.Error;
            }
            else
            {                
                switch(job)
                {
                    case (Jobs.Combine):
                        //WriteStatus("Successfully Combined Huds " + combineHud1.Name + " and " + combineHud2.Name);
                        break;
                    case (Jobs.Fragment):
                        //WriteStatus("Successfully created Blueprint from " + fragmentHud.Name);
                        break;
                    case (Jobs.Parse):
                        WriteStatus("Successfully completed Parsing Hud");
                        break;
                    case (Jobs.Install):
                        WriteStatus("Succesfully Installed Hud");
                        break;
                    case (Jobs.Error):
                    break;
                    default:
                        throw new Exception("backgroundWorker finished working but job wasn't reported");
                }                                
            }
            
            working = false;
            job = Jobs.None;
            
            if(backgroundWorker.IsBusy == false)
                SetProgressBarValue(progressBar_Main.Maximum);
            UpdateButtonState();

            if(silentCancel)
                silentCancel = false;            
        }
                
        /// <summary>
        /// Strips keyvalues containing "_minmode" off all elements and their subelements.
        /// </summary>
        /// <param name="hf">HudFile to strip.</param>
        /// <returns>Returns a HudFile without any minimal values.</returns>
        HudFile StripMinimal(HudFile hf)
        {
            return null;
            /*foreach(HudElement he in hf.m_ElementList)
            {
                foreach(KeyValue kv in he.m_ValueList)
                {
                    if(kv.Name.IndexOf("_minmode") != -1)
                        he.Remove(kv);
                }
                foreach(SubElement sb in he.m_SubList)
                {
                    foreach(KeyValue kv in sb.m_ValueList)
                    {
                        if(kv.Name.IndexOf("_minmode") != -1)
                            he.Remove(kv);
                    }
                    foreach(SubElement ssb in sb.m_SubValueList)
                    {
                        foreach(KeyValue kv in ssb.m_ValueList)
                        {
                            if(kv.Name.IndexOf("_minmode") != -1)
                                he.Remove(kv);
                        }
                    }
                }
            }
            return hf;*/
        }

        /// <summary>
        /// Takes a HudFile and makes minimal values override default values, then removes the minimal ones.
        /// For example: It finds a pair like:
        /// "xpos"          "10"    
        /// "xpos_minmode"  "20"
        /// After which it sets "xpos" to 20 and deletes "xpos_minmode" so you're left with only:
        /// "xpos"      "20"
        /// </summary>
        /// <param name="hf">HudFile to use.</param>
        /// <returns>Returns the new HudFile.</returns>
        HudFile MakeMinimalDefault(HudFile hf)
        {
            return null;
            /*foreach(HudElement he in hf.m_ElementList)
            {
                foreach(KeyValue kv in he.m_ValueList)
                {
                    string newValue;
                    string name;
                    if(kv.Name.Contains("_minmode"))
                    {
                        newValue = kv.Value;
                        name = kv.Name.Replace("_minmode","");
                        foreach(KeyValue kv2 in he.m_ValueList)
                        {
                            if(kv2.Name.ToLower() == name.ToLower())
                            {
                                kv2.Value = newValue;
                                he.m_ValueList.Remove(kv);
                                break;
                            }
                        }
                    }
                }
                foreach(SubElement sb in he.m_SubList)
                {
                    foreach(KeyValue kv in he.m_ValueList)
                    {
                        string newValue;
                        string name;
                        if(kv.Name.Contains("_minmode"))
                        {
                            newValue = kv.Value;
                            name = kv.Name.Replace("_minmode","");
                            foreach(KeyValue kv2 in he.m_ValueList)
                            {
                                if(kv2.Name.ToLower() == name.ToLower())
                                {
                                    kv2.Value = newValue;
                                    he.m_ValueList.Remove(kv);
                                    break;
                                }
                            }
                        }
                    }
                    foreach(SubElement ssb in sb.m_SubValueList)
                    {
                        foreach(KeyValue kv in he.m_ValueList)
                        {
                            string newValue;
                            string name;
                            if(kv.Name.Contains("_minmode"))
                            {
                                newValue = kv.Value;
                                name = kv.Name.Replace("_minmode","");
                                foreach(KeyValue kv2 in he.m_ValueList)
                                {
                                    if(kv2.Name.ToLower() == name.ToLower())
                                    {
                                        kv2.Value = newValue;
                                        he.m_ValueList.Remove(kv);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return hf;*/            
        }
    }
}
