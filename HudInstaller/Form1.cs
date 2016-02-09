using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Resources;
using hudParse;
using System.Diagnostics;

namespace HudInstaller
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string s);
        delegate void SetProgressBarMaxCallback(int i);
        delegate void SetProgressBarValueCallback(int i);

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
        bool gameInstalled = false;
        bool defaultHudParsed = false;

        static Point formSize = new Point(497, 500);    //Different from designer value!!
        SettingsForm Settings = new SettingsForm();
        ResourceManager resourceManager = Properties.Resources.ResourceManager;
        HudResourceFile localizationFile;
        HudResourceFile helpInfo;
#if DEBUG
        public enum Languages { English, Test };
#else
        public enum Languages { English };        
#endif
        enum Jobs { None, Parse, ParseDefault , Fragment, Combine, Install, Error };

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
            localizationFile = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));
            if(localizationFile.IsNull)
                throw new Exception("localizationFile is empty!");
            helpInfo = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_English").ToString() ?? "")));            
            if(helpInfo.IsNull)
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
            helpInfo = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_english").ToString() ?? "")));
            localizationFile = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));
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
                        localizationFile = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_" + lang).ToString() ?? "")));
                    else
                        localizationFile = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("toolbox_english").ToString() ?? "")));

                    if(ResourceExists("helpInfo_" + lang))
                        helpInfo = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_" + lang).ToString() ?? "")));
                    else
                        helpInfo = ParseHudResource(new MemoryStream(Encoding.UTF8.GetBytes(resourceManager.GetObject("helpinfo_english").ToString() ?? "")));
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
                    hud.Resource = ParseHudResource(fbd.SelectedPath + "\\hudinfo.txt");
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
                {
                    if(files.Length > 0)
                        resLogo.Text = files[0];
                }
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
                SetProgressBarValue(0);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void button_FragmentMain_Click(object sender,EventArgs e)
        {
            gameInstalled = true;
            if(!defaultHudParsed && gameInstalled)
            {
                Jobs oldJob = job;
                job = Jobs.ParseDefault;
                WriteStatus("Default Hud not parsed. Parsing...");

                string temp = System.IO.Path.GetTempPath();
                Directory.Delete(temp + "Hud Toolbox", true);
                Directory.CreateDirectory(temp + "Hud Toolbox\\DefaultHud");
                //Directory.Move(gamePath + "\\tf\\resource","\\tf\\_resource");                
                
                ProcessStartInfo start = new ProcessStartInfo();                
                start.Arguments = "\\l " + gamePath + "\tf\tf2_misc_dir.vpk";                
                start.FileName = gamePath + "/bin/vpk.exe";                
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = true;
                int exitCode;
                                
                start.RedirectStandardOutput = true;
                start.UseShellExecute = false;
                Stream s = new MemoryStream();
                                
                using(Process psi = Process.Start(start))
                {                       
                    psi.WaitForExit();                    
                    exitCode = psi.ExitCode;
                }


                //Directory.Move(gamePath + "\\tf\\resource",temp + "Hud Toolbox\\DefaultHud\\resource");
                //Directory.Move(gamePath + "\\tf\\_resource","\\tf\\resource");

                //defaultHud = ParseHud();
            }
            /*if(!backgroundWorker.IsBusy)
            {
                job = Jobs.Fragment;
                working = true;
                UpdateButtonState();
                SetProgressBarValue(0);
                backgroundWorker.RunWorkerAsync();
            }*/
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

        private List<String> GetFiles(string sDir)
        {
            return GetFiles(sDir,false);
        }

        private List<String> GetFiles(string sDir, bool skipRootDirectory)
        {
            bool skipRoot = skipRootDirectory;
            List<String> files = new List<String>();
            try
            {
                if(!skipRoot)
                {
                    foreach(string f in Directory.GetFiles(sDir))
                    {
                        files.Add(f);
                    }
                }
                foreach(string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(GetFiles(d));
                }
                skipRoot = false;
            }
            catch(System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        #endregion

        private void backgroundWorker_DoWork(object sender,System.ComponentModel.DoWorkEventArgs e)
        {
            if(!defaultHudParsed && gameInstalled)
            {

            }
            if(!gameInstalled)
            {
                bool vpkExecFound = false;
                bool vpkFound = false;
                if(File.Exists(folderBrowse_MainInstallPath.SelectedPath + "/bin/vpk.exe"))
                    vpkExecFound = true;
                else
                    WriteStatus(gamePath + "/bin/vpk.exe Not found");

                if(File.Exists(folderBrowse_MainInstallPath.SelectedPath + "/tf/tf2_misc_dir.vpk"))
                    vpkFound = true;
                else
                    WriteStatus(gamePath + "/tf/tf2_misc_dir.vpk Not found");

                if(!vpkExecFound || !vpkFound)
                {
                    WriteStatus("Can't continue until the above issues are resolved");
                    job = Jobs.Error;
                }
                else gameInstalled = true;
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
                if(folderBrowse_Fragment.SelectedPath != "")
                {
                    WriteStatus("Attempting to Create Hud Blueprint...");
                    Hud tempFragment = new Hud();

                    //Set progress bar to length of nr of files in hud
                    var allHudfiles =  Directory.GetFiles(folderBrowse_Fragment.SelectedPath, "*", SearchOption.AllDirectories);
                    var filesInThisFolder = Directory.GetFiles(folderBrowse_Fragment.SelectedPath, "*");

                    SetProgressBarMax(GetFiles(folderBrowse_Fragment.SelectedPath,true).Count);

                    tempFragment = ParseHud(folderBrowse_Fragment.SelectedPath);
                    tempFragment.Resource = fragmentHud.Resource;
                    fragmentHud = tempFragment;
                    fragmentHud.ApplyResource();
                }
                else
                {
                    WriteStatus("Select a Hud folder first");
                    silentCancel = true;
                    backgroundWorker.CancelAsync();
                }
            }
            else if(job == Jobs.Error)
            {
                backgroundWorker.CancelAsync();
            }
            else
                throw new Exception("backgroundWorker asked to do work but a job wasn't assigned");
            
            /*WriteStatus("Parsing Hud...");
            fragmentHud.Resource = new HudResourceFile("hudinfo","txt",fragmentHud.Path,new List<KeyValue>()
            {
                new KeyValue("name",textBox_Fragment_Name.Text),
                new KeyValue("version",textBox_Fragment_Version.Text),
                new KeyValue("author",textBox_Fragment_Author.Text),
                new KeyValue("website",textBox_Fragment_Website.Text)
            });

            Hud tempHud = ParseHud(folderBrowse_Fragment.SelectedPath);
            if(tempHud != null)
                fragmentHud.m_FolderList = tempHud.m_FolderList;
            else WriteStatus("Failed to parse Hud");*/

            //Use if statement to check for job to do.            
            /*for(int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                backgroundWorker.ReportProgress(i);

                if(backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;                    
                    return;
                }
            }*/
            //e.Result = new Hud();     
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
                        throw new Exception("Something went wrong");                       
                }
                job = Jobs.Error;
            }
            else
            {                
                switch(job)
                {
                    case (Jobs.Combine):
                        WriteStatus("Successfully Combined Huds " + combineHud1.Name + " and " + combineHud2.Name);
                        break;
                    case (Jobs.Fragment):
                        WriteStatus("Successfully created Blueprint from " + fragmentHud.Name);
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

        #region HudParse

        public Hud ParseHud(string path)
        {               
            Hud hud = new Hud();
            HudResourceFile tempRes;
            WriteStatus("Attempting to parse Hud resource");
            tempRes = ParseHudResource(path);
            if(!tempRes.IsNull)
            {
                hud.Resource = tempRes;
                hud.ApplyResource();
                WriteStatus("Succesfully parsed Hud resource file " + hud.Resource.Name);
            }
            else WriteStatus("Resource not found, generating default");
            
            var Hud_Subfolders = Directory.GetDirectories(path);
            WriteStatus("Found " + Hud_Subfolders.Length + " folders in " + path);
            for(int i = 0; i < Hud_Subfolders.Length; i++)
            {
                HudFolder folder = new HudFolder();
                folder.FullName = Hud_Subfolders[i];
                WriteStatus("Attempting to parse folder " + folder.Name);
                if(folder.Name.ToLower() == "resource" || folder.Name.ToLower() == "scripts")
                    folder = ParseHudFolder(folder.FullName);
                else
                    folder.CopyNoParse = true;
                WriteStatus("Successfully parsed folder " + folder.Name);
                hud.Add(folder);
            }
            return hud;
        }

        public HudResourceFile ParseHudResource(Stream stream)
        {
            HudResourceFile hf = new HudResourceFile();
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd();
            sr.Close();
            RefLib.CleanUp(ref s,RefLib.cleanupModes.Comments);

            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            hf.Name = ReadName(ss);
            s = s.Remove(0,ss.Length);
            RefLib.Seek(ref s);

            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    RefLib.Seek(ref s);
                    ss = s;
                    if(ss.First() != '}')
                    {
                        ss = RefLib.GetLine(ref ss);
                        KeyValue kv = ParseKeyValue(ss);
                        s = s.Remove(0,ss.Length);

                        if(kv != new KeyValue())
                            hf.Add(kv);
                        else break;
                    }
                    else break;
                }
            }
            return hf;
        }

        public HudResourceFile ParseHudResource(string path)
        {
            if(!path.EndsWith("\\hudinfo.txt"))
                path += "hudinfo.txt";

            if(File.Exists(path))
            {
                HudResourceFile newRes = new HudResourceFile();
                newRes = ParseHudResource(new StreamReader(path).BaseStream);
                newRes.FullName = path;
                return newRes;
            }
            else return new HudResourceFile();
        }

        HudFile ParseHudFile(string path)
        {
            HudFile hf = new HudFile();
            string s;

            if(File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                s = sr.ReadToEnd();
                RefLib.CleanUp(ref s,RefLib.cleanupModes.Comments);
                sr.Close();
            }
            else throw new Exception("Can't parse file, it doesn't exist.");

            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            hf.FullName = ReadName(ss);
            s = s.Remove(0,ss.Length);


            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    HudElement he = new HudElement();
                    RefLib.Seek(ref s);
                    ss = ReadName(s);
                    if(ss != "")
                    {
                        he.Name = ss;
                        s = s.Remove(0,ss.Length);
                        RefLib.Seek(ref s);
                    }
                    ss = s;
                    ss = RefLib.GetLine(ref ss);
                    if(ss.First() == '[')
                    {
                        if(ss.IndexOf(']') != -1)
                        {
                            he.Platform = Read(s,readModes.PlatformTag);
                        }
                        else throw new Exception("Expected platform tag (ex. [$WIN32]) in element " + he.Name + ". In file " + hf.FullName + " got: " + ss);
                        s = s.Remove(0,ss.Length);
                        RefLib.Seek(ref s);
                    }

                    if(s.First() == '{')
                    {
                        s = s.Remove(0,1);
                        while(true)
                        {
                            RefLib.Seek(ref s);
                            ss = s;
                            ss = RefLib.GetLines(2,ref ss);
                            if(ss.IndexOf('{') != -1)
                            {
                                SubElement sb = ParseSubElement(ref s);
                                if(!sb.IsNull)
                                {
                                    he.Add(sb);
                                    s = s.Remove(0,s.IndexOf('}') + 1);
                                }
                                continue;
                            }

                            if(s.First() != '}')
                            {
                                ss = s;
                                ss = GetKeyValuePair(ss);
                                s = s.Remove(0,ss.Length);
                                KeyValue kv = ParseKeyValue(ss);

                                if(!kv.IsNull)
                                {
                                    he.Add(kv);
                                    continue;
                                }
                            }
                            break;
                        }
                        if(!he.IsNull)
                        {
                            hf.Add(he);
                            RefLib.Seek(ref s);
                            if(s.First() == '}')
                            {
                                s = s.Remove(0,1);
                                RefLib.Seek(ref s);
                            }
                        }
                        else break;
                    }
                    else if(s.First() == '}')
                    {
                        s = s.Remove(0,1);
                        RefLib.Seek(ref s);
                        if(s != "")
                            throw new Exception("Error while parsing file " + hf.FullName + ". String should be empty by now but isn't");
                        else break;
                    }
                }
            }
            return hf;
        }

        KeyValue ParseKeyValue(string s)
        {
            KeyValue kv = new KeyValue();
            if(s != "")
            {
                string name = "";
                string value = "";
                bool foundName = false;
                bool foundValue = false;
                bool openQuotes = false;
                int quotesToRemove = 0;
                for(int i = 0; i < s.Length; i++)
                {
                    if((s[i] != '\t') && (s[i] != ' ') && (s[i] != '\r') && (s[i] != '\n'))
                    {
                        if(s[i] == '\"')
                        {
                            if(!openQuotes)
                                openQuotes = true;
                            else
                                openQuotes = false;
                            quotesToRemove++;
                            continue;
                        }
                        if(!foundName)
                            name += s[i];
                        else
                        {
                            value += s[i];
                            foundValue = true;
                        }
                    }
                    else
                    {
                        if(openQuotes)
                        {
                            if(!foundName)
                                name += s[i];
                            else
                                value += s[i];
                            continue;
                        }
                        foundName = true;
                        if(foundValue && foundName)
                            break;
                    }
                }
                if(name != "")
                {
                    s = s.Remove(0,name.Length);
                    kv.Name = name;
                    s = RefLib.Seek(ref s);
                }
                if(value != "")
                {
                    s = s.Remove(0,value.Length);
                    kv.Value = value;
                    s = RefLib.Seek(ref s);
                }
                s = s.Remove(0,quotesToRemove);
                if(s != "")
                    kv.Platform = Read(s,readModes.PlatformTag);
            }
            return kv;
        }

        HudElement ParseHudElement(string s)
        {
            HudElement he = new HudElement();
            RefLib.Seek(ref s);
            string ss = s;
            ss = RefLib.GetLine(ref ss);
            if(ss.IndexOf('[') == -1)
                he.Name = RefLib.Condense(ss);
            else
            {
                if(s.First() == '[')
                {
                    string result = "";
                    for(int i = 0; i < s.Length; i++)
                    {
                        result += ss[i];
                        if(ss[i] == ']')
                            break;
                        throw new Exception("Reached end of file before reaching end of platform tag");
                    }
                    s = s.Remove(0,ss.Length);
                    he.Platform = ss;
                    RefLib.Seek(ref s);
                }
            }
            s = s.Remove(ss.Length);
            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                while(s.First() != '}')
                {
                    string temp = s;
                    temp = RefLib.GetLines(2,ref temp);
                    if(temp.IndexOf('{') != -1)
                    {
                        SubElement sb = ParseSubElement(ref s);
                        if(!sb.IsNull)
                        {
                            he.Add(sb);
                            continue;
                        }
                        else throw new Exception("Parse sub element returned null. Don't try to parse if there isn't one");
                    }
                    RefLib.Seek(ref s);
                    KeyValue kv = new KeyValue();
                    string x = GetKeyValuePair(s);
                    kv = ParseKeyValue(x);
                    if(x != "")
                        s.Remove(0,x.Length);
                    if(!kv.IsNull)
                    {
                        he.Add(kv);
                    }
                    else break;
                }
            }
            return he;
        }

        public Hud CombineHuds(Hud hud1,Hud hud2)
        {
            Hud result = new Hud();

            return result;
        }

        //Currently uses almost the same code as ParseHudElement. 
        //TODO: Derive SubElement from HudElement and share code.
        //TODO: Check if it's a .res file before parsing and return null if it's not as a flag to copy the file over when installing.
        //TODO: Set folder check to Hud's path + folder name, or whatever, so it ignores the parsing ONLY if we're in the root hud folder.
        SubElement ParseSubElement(ref string s)
        {
            SubElement sb = new SubElement();

            string ss = s;

            ss = RefLib.GetLine(ref ss);
            sb.Name = ss;
            ss = s;
            ss = RefLib.GetLine(ref ss);
            int toRemove = 0;

            for(int i = 0; i < ss.Length; i++)
            {
                if(ss[i] == '\"')
                    toRemove++;
            }
            s = s.Remove(0,ss.Length + toRemove);
            RefLib.Seek(ref s);
            if(s.First() == '{')
            {
                s = s.Remove(0,1);
                while(true)
                {
                    RefLib.Seek(ref s);
                    SubElement ssb = new SubElement();
                    ss = s;
                    ss = RefLib.GetLines(2,ref ss);
                    if(ss.IndexOf('{') != -1)
                    {
                        ssb = ParseSubElement(ref s);
                        if(!ssb.IsNull)
                        {
                            sb.Add(ssb);
                            s = s.Remove(0,s.IndexOf('}') + 1);
                            continue;
                        }
                    }

                    RefLib.Seek(ref s);
                    KeyValue kv = new KeyValue();
                    if(s.First() != '}')
                    {
                        ss = GetKeyValuePair(s);
                        s = s.Remove(0,ss.Length);
                        kv = ParseKeyValue(ss);
                    }
                    if(!kv.IsNull)
                        sb.Add(kv);
                    else break;
                }
            }
            return sb;
        }

        HudFolder ParseHudFolder(string path)
        {
            HudFolder folder = new HudFolder();
            folder.FullName = path;
            var hudFiles = Directory.GetFiles(path, "*.res");
            var folders = Directory.GetDirectories(path);

            WriteStatus("Found " + folders.Length + " folders in " + path);
            for(int i = 0; i < folders.Length; i++)
            {
                HudFolder subFolder = new HudFolder();
                subFolder.FullName = folders[i];                                
                if(!subFolder.CopyNoParse)
                    subFolder = ParseHudFolder(subFolder.FullName);
                folder.Add(subFolder);                
            }
            if(hudFiles.Length > 0)
            {
                WriteStatus("Found " + hudFiles.Length + " files in " + folder.Name);
                for(int i = 0; i < hudFiles.Length; i++)
                {
                    HudFile file = new HudFile();
                    file.FullName = hudFiles[i];
                    WriteStatus("Attempting to parse file " + file.Name);
                    file = ParseHudFile(file.FullName);
                    if(!file.IsNull)
                    {
                        folder.Add(file);
                        WriteStatus("Successfully parsed file " + file.Name);
                        backgroundWorker.ReportProgress(1);
                    }

                    if(backgroundWorker.CancellationPending)
                    {
                        backgroundWorker.CancelAsync();                        
                    }
                }
            }
            return folder;
        }

        public enum readModes { KeyValue, PlatformTag };
        /// <summary>
        /// Looks for the first value it can find enclosed in quotes or square brackets.
        /// </summary>
        /// <param name="s">Target string to look in.</param>
        /// <returns>Returns the value enclosed in quotes or square brackets.</returns>
        static string Read(string s,readModes mode)
        {
            string result = "";
            bool openedQuotes = false;

            if(s.First() != '}')
            {
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
            }
            return result;
        }
        static string Read(string s)
        {
            return Read(s,readModes.KeyValue);
        }
        static string ReadName(string s)
        {
            string result = "";
            string ss = s;
            ss = RefLib.GetLine(ref ss);

            for(int i = 0; i < ss.Length; i++)
            {
                if((ss[i] != ' ') && (ss[i] != '}') && (ss[i] != '\t'))
                    result += ss[i];
                else break;
            }
            return result;
        }

        /// <summary>
        /// Strips keyvalues containing "_minmode" off all elements and their subelements.
        /// </summary>
        /// <param name="hf">HudFile to strip.</param>
        /// <returns>Returns a HudFile without any minimal values.</returns>
        HudFile StripMinimal(HudFile hf)
        {
            foreach(HudElement he in hf.m_ElementList)
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
            return hf;
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
            foreach(HudElement he in hf.m_ElementList)
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
            return hf;
        }

        static string GetKeyValuePair(string s)
        {
            string ss = s;
            string result = "";
            int quoteNr = 0;
            RefLib.Seek(ref ss);
            bool foundKey = false;
            bool foundInBetween = false;
            string key = "";
            string value = "";
            string inBetween = "";

            if(ss != "")
            {
                for(int i = 0; i < ss.Length; i++)
                {
                    if((ss[i] != '\t') && (ss[i] != ' ') && (ss[i] != '\r') && (ss[i] != '\n'))
                    {
                        if(ss[i] == '\"')
                            quoteNr++;
                        if(!foundKey)
                            key += ss[i];
                        else
                        {
                            foundInBetween = true;
                            value += ss[i];
                        }
                    }
                    else
                    {
                        foundKey = true;
                        if(!foundInBetween)
                            inBetween += ss[i];
                        if(foundInBetween && foundKey)
                            break;
                    }
                }
                result = key + inBetween + value;
            }
            ss = ss.Remove(0,result.Length);
            ss = RefLib.GetLine(ref ss);
            if(ss != "")
                result += ss;
            return result;
        }

        #endregion
    }
}
