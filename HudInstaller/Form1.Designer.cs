namespace HudInstaller
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tab_Install = new System.Windows.Forms.TabPage();
            this.button_MainInstallBrowseClear = new System.Windows.Forms.Button();
            this.label_static_hud = new System.Windows.Forms.Label();
            this.button_MainInstallBrowse = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox_GameInstallPath = new System.Windows.Forms.TextBox();
            this.groupBox_HudInfo = new System.Windows.Forms.GroupBox();
            this.label_HudAuthor = new System.Windows.Forms.Label();
            this.linkLabel_HudWebsite = new System.Windows.Forms.LinkLabel();
            this.label_HudVersion = new System.Windows.Forms.Label();
            this.label_HudName = new System.Windows.Forms.Label();
            this.label_Static_HudWebsite = new System.Windows.Forms.Label();
            this.label_Static_HudAuthor = new System.Windows.Forms.Label();
            this.label_Static_HudVersion = new System.Windows.Forms.Label();
            this.label_Static_HudName = new System.Windows.Forms.Label();
            this.label_TF2Folder = new System.Windows.Forms.Label();
            this.groupBox_InstallMode = new System.Windows.Forms.GroupBox();
            this.radio_InstallMode_Hard = new System.Windows.Forms.RadioButton();
            this.radio_InstallMode_Soft = new System.Windows.Forms.RadioButton();
            this.button_Install = new System.Windows.Forms.Button();
            this.button_Customize = new System.Windows.Forms.Button();
            this.button_MainBrowse = new System.Windows.Forms.Button();
            this.textBox_MainBrowse = new System.Windows.Forms.TextBox();
            this.textBox_HudNameMain = new System.Windows.Forms.TextBox();
            this.PictureBox_HudThumb = new System.Windows.Forms.PictureBox();
            this.button_Parse = new System.Windows.Forms.Button();
            this.tab_Fragment = new System.Windows.Forms.TabPage();
            this.groupBox_HudInfo1 = new System.Windows.Forms.GroupBox();
            this.button_FragmentClearLogo = new System.Windows.Forms.Button();
            this.button_FragmentLogoBrowse = new System.Windows.Forms.Button();
            this.textBox_Fragment_LogoBrowse = new System.Windows.Forms.TextBox();
            this.label_static_logo = new System.Windows.Forms.Label();
            this.label_static_hudwebsite1 = new System.Windows.Forms.Label();
            this.textBox_Fragment_Website = new System.Windows.Forms.TextBox();
            this.label_static_hudauthor1 = new System.Windows.Forms.Label();
            this.textBox_Fragment_Author = new System.Windows.Forms.TextBox();
            this.label_static_hudversion1 = new System.Windows.Forms.Label();
            this.textBox_Fragment_Version = new System.Windows.Forms.TextBox();
            this.label_static_hudname1 = new System.Windows.Forms.Label();
            this.textBox_Fragment_Name = new System.Windows.Forms.TextBox();
            this.groupBox_Misc = new System.Windows.Forms.GroupBox();
            this.radio_MinamalDefault = new System.Windows.Forms.RadioButton();
            this.radio_None = new System.Windows.Forms.RadioButton();
            this.radio_StripMinimal = new System.Windows.Forms.RadioButton();
            this.label_Static_Hud1 = new System.Windows.Forms.Label();
            this.button_FragmentHudBrowse = new System.Windows.Forms.Button();
            this.textBox_FragmentHudBrowse = new System.Windows.Forms.TextBox();
            this.textBox_FragmentHudMain = new System.Windows.Forms.TextBox();
            this.pictureBox_FragmentHudMain = new System.Windows.Forms.PictureBox();
            this.button_FragmentMain = new System.Windows.Forms.Button();
            this.tab_CombineHuds = new System.Windows.Forms.TabPage();
            this.checkBox_CombineHudUseDefault2 = new System.Windows.Forms.CheckBox();
            this.checkBox_CombineHudUseDefault1 = new System.Windows.Forms.CheckBox();
            this.button_CombineResultClearLogo = new System.Windows.Forms.Button();
            this.button_CombineResultBrowseLogo = new System.Windows.Forms.Button();
            this.button_CombineBrowse2 = new System.Windows.Forms.Button();
            this.textBox_CombineBrowse2 = new System.Windows.Forms.TextBox();
            this.textBox_CombineBrowse1 = new System.Windows.Forms.TextBox();
            this.button_CombineBrowse1 = new System.Windows.Forms.Button();
            this.textBox_CombineHud_Result = new System.Windows.Forms.TextBox();
            this.label_Static_Result = new System.Windows.Forms.Label();
            this.label_CombineMinmode2 = new System.Windows.Forms.Label();
            this.label_CombineMinmode1 = new System.Windows.Forms.Label();
            this.textBox_CombineHudName2 = new System.Windows.Forms.TextBox();
            this.textBox_CombineHudName1 = new System.Windows.Forms.TextBox();
            this.checkBox_CombineUseMinimal2 = new System.Windows.Forms.CheckBox();
            this.checkBox_CombineUseMinimal1 = new System.Windows.Forms.CheckBox();
            this.button_Combine = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox_CombineHud2 = new System.Windows.Forms.PictureBox();
            this.PictureBox_CombineHud1 = new System.Windows.Forms.PictureBox();
            this.tab_About = new System.Windows.Forms.TabPage();
            this.textBox_About = new System.Windows.Forms.TextBox();
            this.pictureBox_About_Logo = new System.Windows.Forms.PictureBox();
            this.button_ToggleHelp = new System.Windows.Forms.Button();
            this.textBox_MainHelpTitle = new System.Windows.Forms.TextBox();
            this.textBox_MainHelp = new System.Windows.Forms.TextBox();
            this.label_Help = new System.Windows.Forms.Label();
            this.textBox_MainStatus = new System.Windows.Forms.TextBox();
            this.progressBar_Main = new System.Windows.Forms.ProgressBar();
            this.folderBrowse_CombineHud1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowse_CombineHud2 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_MainCancel = new System.Windows.Forms.Button();
            this.folderBrowse_Fragment = new System.Windows.Forms.FolderBrowserDialog();
            this.openFile_FragmentLogoBrowse = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowse_MainInstallPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button_Settings = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFile_FragmentHud = new System.Windows.Forms.SaveFileDialog();
            this.tabControl_Main.SuspendLayout();
            this.tab_Install.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox_HudInfo.SuspendLayout();
            this.groupBox_InstallMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_HudThumb)).BeginInit();
            this.tab_Fragment.SuspendLayout();
            this.groupBox_HudInfo1.SuspendLayout();
            this.groupBox_Misc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FragmentHudMain)).BeginInit();
            this.tab_CombineHuds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CombineHud2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CombineHud1)).BeginInit();
            this.tab_About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_About_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tab_Install);
            this.tabControl_Main.Controls.Add(this.tab_Fragment);
            this.tabControl_Main.Controls.Add(this.tab_CombineHuds);
            this.tabControl_Main.Controls.Add(this.tab_About);
            this.tabControl_Main.Location = new System.Drawing.Point(9, 10);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(465, 315);
            this.tabControl_Main.TabIndex = 0;
            this.tabControl_Main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Main_Selecting);
            // 
            // tab_Install
            // 
            this.tab_Install.BackColor = System.Drawing.Color.Transparent;
            this.tab_Install.Controls.Add(this.button_MainInstallBrowseClear);
            this.tab_Install.Controls.Add(this.label_static_hud);
            this.tab_Install.Controls.Add(this.button_MainInstallBrowse);
            this.tab_Install.Controls.Add(this.pictureBox2);
            this.tab_Install.Controls.Add(this.textBox_GameInstallPath);
            this.tab_Install.Controls.Add(this.groupBox_HudInfo);
            this.tab_Install.Controls.Add(this.label_TF2Folder);
            this.tab_Install.Controls.Add(this.groupBox_InstallMode);
            this.tab_Install.Controls.Add(this.button_Install);
            this.tab_Install.Controls.Add(this.button_Customize);
            this.tab_Install.Controls.Add(this.button_MainBrowse);
            this.tab_Install.Controls.Add(this.textBox_MainBrowse);
            this.tab_Install.Controls.Add(this.textBox_HudNameMain);
            this.tab_Install.Controls.Add(this.PictureBox_HudThumb);
            this.tab_Install.Controls.Add(this.button_Parse);
            this.tab_Install.Location = new System.Drawing.Point(4, 22);
            this.tab_Install.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Install.Name = "tab_Install";
            this.tab_Install.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Install.Size = new System.Drawing.Size(457, 289);
            this.tab_Install.TabIndex = 0;
            this.tab_Install.Text = "Install Hud";
            // 
            // button_MainInstallBrowseClear
            // 
            this.button_MainInstallBrowseClear.Location = new System.Drawing.Point(319, 188);
            this.button_MainInstallBrowseClear.Margin = new System.Windows.Forms.Padding(2);
            this.button_MainInstallBrowseClear.Name = "button_MainInstallBrowseClear";
            this.button_MainInstallBrowseClear.Size = new System.Drawing.Size(58, 19);
            this.button_MainInstallBrowseClear.TabIndex = 20;
            this.button_MainInstallBrowseClear.Text = "Clear";
            this.button_MainInstallBrowseClear.UseVisualStyleBackColor = true;
            this.button_MainInstallBrowseClear.Click += new System.EventHandler(this.button_MainInstallBrowseClear_Click);
            // 
            // label_static_hud
            // 
            this.label_static_hud.AutoSize = true;
            this.label_static_hud.Location = new System.Drawing.Point(12, 13);
            this.label_static_hud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_static_hud.Name = "label_static_hud";
            this.label_static_hud.Size = new System.Drawing.Size(27, 13);
            this.label_static_hud.TabIndex = 21;
            this.label_static_hud.Text = "Hud";
            // 
            // button_MainInstallBrowse
            // 
            this.button_MainInstallBrowse.Location = new System.Drawing.Point(387, 188);
            this.button_MainInstallBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.button_MainInstallBrowse.Name = "button_MainInstallBrowse";
            this.button_MainInstallBrowse.Size = new System.Drawing.Size(59, 19);
            this.button_MainInstallBrowse.TabIndex = 19;
            this.button_MainInstallBrowse.Text = "Browse";
            this.button_MainInstallBrowse.UseVisualStyleBackColor = true;
            this.button_MainInstallBrowse.Click += new System.EventHandler(this.button_MainInstallBrowse_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HudInstaller.Properties.Resources.logo_main_transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(183, 216);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // textBox_GameInstallPath
            // 
            this.textBox_GameInstallPath.Location = new System.Drawing.Point(320, 165);
            this.textBox_GameInstallPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GameInstallPath.Name = "textBox_GameInstallPath";
            this.textBox_GameInstallPath.Size = new System.Drawing.Size(127, 20);
            this.textBox_GameInstallPath.TabIndex = 18;
            this.textBox_GameInstallPath.TextChanged += new System.EventHandler(this.textBox_MainInstallPath_TextChanged);
            // 
            // groupBox_HudInfo
            // 
            this.groupBox_HudInfo.Controls.Add(this.label_HudAuthor);
            this.groupBox_HudInfo.Controls.Add(this.linkLabel_HudWebsite);
            this.groupBox_HudInfo.Controls.Add(this.label_HudVersion);
            this.groupBox_HudInfo.Controls.Add(this.label_HudName);
            this.groupBox_HudInfo.Controls.Add(this.label_Static_HudWebsite);
            this.groupBox_HudInfo.Controls.Add(this.label_Static_HudAuthor);
            this.groupBox_HudInfo.Controls.Add(this.label_Static_HudVersion);
            this.groupBox_HudInfo.Controls.Add(this.label_Static_HudName);
            this.groupBox_HudInfo.Location = new System.Drawing.Point(164, 14);
            this.groupBox_HudInfo.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_HudInfo.Name = "groupBox_HudInfo";
            this.groupBox_HudInfo.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_HudInfo.Size = new System.Drawing.Size(150, 195);
            this.groupBox_HudInfo.TabIndex = 19;
            this.groupBox_HudInfo.TabStop = false;
            this.groupBox_HudInfo.Text = "Hud Info";
            // 
            // label_HudAuthor
            // 
            this.label_HudAuthor.AutoSize = true;
            this.label_HudAuthor.Location = new System.Drawing.Point(4, 118);
            this.label_HudAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_HudAuthor.Name = "label_HudAuthor";
            this.label_HudAuthor.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label_HudAuthor.Size = new System.Drawing.Size(86, 16);
            this.label_HudAuthor.TabIndex = 7;
            this.label_HudAuthor.Text = "label_HudAuthor";
            // 
            // linkLabel_HudWebsite
            // 
            this.linkLabel_HudWebsite.AutoSize = true;
            this.linkLabel_HudWebsite.Location = new System.Drawing.Point(4, 158);
            this.linkLabel_HudWebsite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel_HudWebsite.Name = "linkLabel_HudWebsite";
            this.linkLabel_HudWebsite.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.linkLabel_HudWebsite.Size = new System.Drawing.Size(94, 16);
            this.linkLabel_HudWebsite.TabIndex = 6;
            this.linkLabel_HudWebsite.TabStop = true;
            this.linkLabel_HudWebsite.Text = "label_HudWebsite";
            // 
            // label_HudVersion
            // 
            this.label_HudVersion.AutoSize = true;
            this.label_HudVersion.Location = new System.Drawing.Point(4, 80);
            this.label_HudVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_HudVersion.Name = "label_HudVersion";
            this.label_HudVersion.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label_HudVersion.Size = new System.Drawing.Size(90, 16);
            this.label_HudVersion.TabIndex = 5;
            this.label_HudVersion.Text = "label_HudVersion";
            // 
            // label_HudName
            // 
            this.label_HudName.AutoSize = true;
            this.label_HudName.Location = new System.Drawing.Point(4, 41);
            this.label_HudName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_HudName.Name = "label_HudName";
            this.label_HudName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label_HudName.Size = new System.Drawing.Size(83, 16);
            this.label_HudName.TabIndex = 4;
            this.label_HudName.Text = "label_HudName";
            // 
            // label_Static_HudWebsite
            // 
            this.label_Static_HudWebsite.AutoSize = true;
            this.label_Static_HudWebsite.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Static_HudWebsite.Location = new System.Drawing.Point(4, 134);
            this.label_Static_HudWebsite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_HudWebsite.Name = "label_Static_HudWebsite";
            this.label_Static_HudWebsite.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_Static_HudWebsite.Size = new System.Drawing.Size(49, 23);
            this.label_Static_HudWebsite.TabIndex = 3;
            this.label_Static_HudWebsite.Text = "Website:";
            // 
            // label_Static_HudAuthor
            // 
            this.label_Static_HudAuthor.AutoSize = true;
            this.label_Static_HudAuthor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Static_HudAuthor.Location = new System.Drawing.Point(4, 94);
            this.label_Static_HudAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_HudAuthor.Name = "label_Static_HudAuthor";
            this.label_Static_HudAuthor.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_Static_HudAuthor.Size = new System.Drawing.Size(41, 23);
            this.label_Static_HudAuthor.TabIndex = 2;
            this.label_Static_HudAuthor.Text = "Author:";
            // 
            // label_Static_HudVersion
            // 
            this.label_Static_HudVersion.AutoSize = true;
            this.label_Static_HudVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Static_HudVersion.Location = new System.Drawing.Point(4, 56);
            this.label_Static_HudVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_HudVersion.Name = "label_Static_HudVersion";
            this.label_Static_HudVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_Static_HudVersion.Size = new System.Drawing.Size(45, 23);
            this.label_Static_HudVersion.TabIndex = 1;
            this.label_Static_HudVersion.Text = "Version:";
            // 
            // label_Static_HudName
            // 
            this.label_Static_HudName.AutoSize = true;
            this.label_Static_HudName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Static_HudName.Location = new System.Drawing.Point(4, 18);
            this.label_Static_HudName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_HudName.Name = "label_Static_HudName";
            this.label_Static_HudName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_Static_HudName.Size = new System.Drawing.Size(38, 23);
            this.label_Static_HudName.TabIndex = 0;
            this.label_Static_HudName.Text = "Name:";
            // 
            // label_TF2Folder
            // 
            this.label_TF2Folder.AutoSize = true;
            this.label_TF2Folder.Location = new System.Drawing.Point(319, 148);
            this.label_TF2Folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TF2Folder.Name = "label_TF2Folder";
            this.label_TF2Folder.Size = new System.Drawing.Size(58, 13);
            this.label_TF2Folder.TabIndex = 17;
            this.label_TF2Folder.Text = "TF2 folder:";
            // 
            // groupBox_InstallMode
            // 
            this.groupBox_InstallMode.Controls.Add(this.radio_InstallMode_Hard);
            this.groupBox_InstallMode.Controls.Add(this.radio_InstallMode_Soft);
            this.groupBox_InstallMode.Location = new System.Drawing.Point(321, 23);
            this.groupBox_InstallMode.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_InstallMode.Name = "groupBox_InstallMode";
            this.groupBox_InstallMode.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_InstallMode.Size = new System.Drawing.Size(128, 67);
            this.groupBox_InstallMode.TabIndex = 18;
            this.groupBox_InstallMode.TabStop = false;
            this.groupBox_InstallMode.Text = "Install Mode";
            // 
            // radio_InstallMode_Hard
            // 
            this.radio_InstallMode_Hard.AutoSize = true;
            this.radio_InstallMode_Hard.Location = new System.Drawing.Point(7, 20);
            this.radio_InstallMode_Hard.Margin = new System.Windows.Forms.Padding(2);
            this.radio_InstallMode_Hard.Name = "radio_InstallMode_Hard";
            this.radio_InstallMode_Hard.Size = new System.Drawing.Size(48, 17);
            this.radio_InstallMode_Hard.TabIndex = 16;
            this.radio_InstallMode_Hard.Text = "Hard";
            this.radio_InstallMode_Hard.UseVisualStyleBackColor = true;
            // 
            // radio_InstallMode_Soft
            // 
            this.radio_InstallMode_Soft.AutoSize = true;
            this.radio_InstallMode_Soft.Checked = true;
            this.radio_InstallMode_Soft.Location = new System.Drawing.Point(7, 42);
            this.radio_InstallMode_Soft.Margin = new System.Windows.Forms.Padding(2);
            this.radio_InstallMode_Soft.Name = "radio_InstallMode_Soft";
            this.radio_InstallMode_Soft.Size = new System.Drawing.Size(125, 17);
            this.radio_InstallMode_Soft.TabIndex = 15;
            this.radio_InstallMode_Soft.TabStop = true;
            this.radio_InstallMode_Soft.Text = "Soft (Recommended)";
            this.radio_InstallMode_Soft.UseVisualStyleBackColor = true;
            // 
            // button_Install
            // 
            this.button_Install.Location = new System.Drawing.Point(319, 246);
            this.button_Install.Margin = new System.Windows.Forms.Padding(2);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(128, 36);
            this.button_Install.TabIndex = 9;
            this.button_Install.Text = "Install";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            this.button_Install.MouseHover += new System.EventHandler(this.button_Install_MouseHover);
            // 
            // button_Customize
            // 
            this.button_Customize.Location = new System.Drawing.Point(319, 214);
            this.button_Customize.Margin = new System.Windows.Forms.Padding(2);
            this.button_Customize.Name = "button_Customize";
            this.button_Customize.Size = new System.Drawing.Size(128, 28);
            this.button_Customize.TabIndex = 5;
            this.button_Customize.Text = "Customize";
            this.button_Customize.UseVisualStyleBackColor = true;
            this.button_Customize.MouseHover += new System.EventHandler(this.button_Customize_MouseHover);
            // 
            // button_MainBrowse
            // 
            this.button_MainBrowse.Location = new System.Drawing.Point(104, 213);
            this.button_MainBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.button_MainBrowse.Name = "button_MainBrowse";
            this.button_MainBrowse.Size = new System.Drawing.Size(56, 28);
            this.button_MainBrowse.TabIndex = 4;
            this.button_MainBrowse.Text = "Browse";
            this.button_MainBrowse.UseVisualStyleBackColor = true;
            this.button_MainBrowse.MouseHover += new System.EventHandler(this.button_MainBrowse_MouseHover);
            // 
            // textBox_MainBrowse
            // 
            this.textBox_MainBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MainBrowse.Location = new System.Drawing.Point(14, 214);
            this.textBox_MainBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MainBrowse.Name = "textBox_MainBrowse";
            this.textBox_MainBrowse.ReadOnly = true;
            this.textBox_MainBrowse.Size = new System.Drawing.Size(86, 26);
            this.textBox_MainBrowse.TabIndex = 3;
            this.textBox_MainBrowse.TextChanged += new System.EventHandler(this.textBox_MainBrowse_TextChanged);
            // 
            // textBox_HudNameMain
            // 
            this.textBox_HudNameMain.Location = new System.Drawing.Point(14, 31);
            this.textBox_HudNameMain.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_HudNameMain.Name = "textBox_HudNameMain";
            this.textBox_HudNameMain.ReadOnly = true;
            this.textBox_HudNameMain.Size = new System.Drawing.Size(146, 20);
            this.textBox_HudNameMain.TabIndex = 2;
            this.textBox_HudNameMain.TabStop = false;
            // 
            // PictureBox_HudThumb
            // 
            this.PictureBox_HudThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_HudThumb.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_HudThumb.Image")));
            this.PictureBox_HudThumb.Location = new System.Drawing.Point(14, 54);
            this.PictureBox_HudThumb.Margin = new System.Windows.Forms.Padding(2);
            this.PictureBox_HudThumb.Name = "PictureBox_HudThumb";
            this.PictureBox_HudThumb.Size = new System.Drawing.Size(146, 156);
            this.PictureBox_HudThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_HudThumb.TabIndex = 1;
            this.PictureBox_HudThumb.TabStop = false;
            // 
            // button_Parse
            // 
            this.button_Parse.Location = new System.Drawing.Point(14, 246);
            this.button_Parse.Margin = new System.Windows.Forms.Padding(2);
            this.button_Parse.Name = "button_Parse";
            this.button_Parse.Size = new System.Drawing.Size(146, 36);
            this.button_Parse.TabIndex = 0;
            this.button_Parse.Text = "Parse";
            this.button_Parse.UseVisualStyleBackColor = true;
            this.button_Parse.Click += new System.EventHandler(this.button_Parse_Click);
            this.button_Parse.MouseHover += new System.EventHandler(this.button_Parse_MouseHover);
            // 
            // tab_Fragment
            // 
            this.tab_Fragment.BackColor = System.Drawing.Color.Transparent;
            this.tab_Fragment.Controls.Add(this.groupBox_HudInfo1);
            this.tab_Fragment.Controls.Add(this.groupBox_Misc);
            this.tab_Fragment.Controls.Add(this.label_Static_Hud1);
            this.tab_Fragment.Controls.Add(this.button_FragmentHudBrowse);
            this.tab_Fragment.Controls.Add(this.textBox_FragmentHudBrowse);
            this.tab_Fragment.Controls.Add(this.textBox_FragmentHudMain);
            this.tab_Fragment.Controls.Add(this.pictureBox_FragmentHudMain);
            this.tab_Fragment.Controls.Add(this.button_FragmentMain);
            this.tab_Fragment.Location = new System.Drawing.Point(4, 22);
            this.tab_Fragment.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Fragment.Name = "tab_Fragment";
            this.tab_Fragment.Padding = new System.Windows.Forms.Padding(2);
            this.tab_Fragment.Size = new System.Drawing.Size(457, 289);
            this.tab_Fragment.TabIndex = 3;
            this.tab_Fragment.Text = "Fragment Hud";
            // 
            // groupBox_HudInfo1
            // 
            this.groupBox_HudInfo1.Controls.Add(this.button_FragmentClearLogo);
            this.groupBox_HudInfo1.Controls.Add(this.button_FragmentLogoBrowse);
            this.groupBox_HudInfo1.Controls.Add(this.textBox_Fragment_LogoBrowse);
            this.groupBox_HudInfo1.Controls.Add(this.label_static_logo);
            this.groupBox_HudInfo1.Controls.Add(this.label_static_hudwebsite1);
            this.groupBox_HudInfo1.Controls.Add(this.textBox_Fragment_Website);
            this.groupBox_HudInfo1.Controls.Add(this.label_static_hudauthor1);
            this.groupBox_HudInfo1.Controls.Add(this.textBox_Fragment_Author);
            this.groupBox_HudInfo1.Controls.Add(this.label_static_hudversion1);
            this.groupBox_HudInfo1.Controls.Add(this.textBox_Fragment_Version);
            this.groupBox_HudInfo1.Controls.Add(this.label_static_hudname1);
            this.groupBox_HudInfo1.Controls.Add(this.textBox_Fragment_Name);
            this.groupBox_HudInfo1.Location = new System.Drawing.Point(175, 13);
            this.groupBox_HudInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_HudInfo1.Name = "groupBox_HudInfo1";
            this.groupBox_HudInfo1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_HudInfo1.Size = new System.Drawing.Size(267, 225);
            this.groupBox_HudInfo1.TabIndex = 18;
            this.groupBox_HudInfo1.TabStop = false;
            this.groupBox_HudInfo1.Text = "Hud Info";
            // 
            // button_FragmentClearLogo
            // 
            this.button_FragmentClearLogo.Location = new System.Drawing.Point(166, 194);
            this.button_FragmentClearLogo.Margin = new System.Windows.Forms.Padding(2);
            this.button_FragmentClearLogo.Name = "button_FragmentClearLogo";
            this.button_FragmentClearLogo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button_FragmentClearLogo.Size = new System.Drawing.Size(20, 22);
            this.button_FragmentClearLogo.TabIndex = 18;
            this.button_FragmentClearLogo.Text = "x";
            this.button_FragmentClearLogo.UseVisualStyleBackColor = true;
            this.button_FragmentClearLogo.Click += new System.EventHandler(this.button_FragmentClearLogo_Click);
            // 
            // button_FragmentLogoBrowse
            // 
            this.button_FragmentLogoBrowse.Location = new System.Drawing.Point(185, 194);
            this.button_FragmentLogoBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.button_FragmentLogoBrowse.Name = "button_FragmentLogoBrowse";
            this.button_FragmentLogoBrowse.Size = new System.Drawing.Size(66, 22);
            this.button_FragmentLogoBrowse.TabIndex = 10;
            this.button_FragmentLogoBrowse.Text = "Browse";
            this.button_FragmentLogoBrowse.UseVisualStyleBackColor = true;
            this.button_FragmentLogoBrowse.Click += new System.EventHandler(this.button_FragmentLogoBrowse_Click);
            // 
            // textBox_Fragment_LogoBrowse
            // 
            this.textBox_Fragment_LogoBrowse.Location = new System.Drawing.Point(14, 195);
            this.textBox_Fragment_LogoBrowse.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.textBox_Fragment_LogoBrowse.Name = "textBox_Fragment_LogoBrowse";
            this.textBox_Fragment_LogoBrowse.Size = new System.Drawing.Size(152, 20);
            this.textBox_Fragment_LogoBrowse.TabIndex = 9;
            this.textBox_Fragment_LogoBrowse.TextChanged += new System.EventHandler(this.textBox_Fragment_LogoBrowse_TextChanged);
            // 
            // label_static_logo
            // 
            this.label_static_logo.AutoSize = true;
            this.label_static_logo.Location = new System.Drawing.Point(12, 177);
            this.label_static_logo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_static_logo.Name = "label_static_logo";
            this.label_static_logo.Size = new System.Drawing.Size(31, 13);
            this.label_static_logo.TabIndex = 8;
            this.label_static_logo.Text = "Logo";
            // 
            // label_static_hudwebsite1
            // 
            this.label_static_hudwebsite1.AutoSize = true;
            this.label_static_hudwebsite1.Location = new System.Drawing.Point(12, 136);
            this.label_static_hudwebsite1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.label_static_hudwebsite1.Name = "label_static_hudwebsite1";
            this.label_static_hudwebsite1.Size = new System.Drawing.Size(46, 13);
            this.label_static_hudwebsite1.TabIndex = 7;
            this.label_static_hudwebsite1.Text = "Website";
            // 
            // textBox_Fragment_Website
            // 
            this.textBox_Fragment_Website.Location = new System.Drawing.Point(14, 155);
            this.textBox_Fragment_Website.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fragment_Website.Name = "textBox_Fragment_Website";
            this.textBox_Fragment_Website.Size = new System.Drawing.Size(238, 20);
            this.textBox_Fragment_Website.TabIndex = 6;
            // 
            // label_static_hudauthor1
            // 
            this.label_static_hudauthor1.AutoSize = true;
            this.label_static_hudauthor1.Location = new System.Drawing.Point(12, 96);
            this.label_static_hudauthor1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
            this.label_static_hudauthor1.Name = "label_static_hudauthor1";
            this.label_static_hudauthor1.Size = new System.Drawing.Size(38, 13);
            this.label_static_hudauthor1.TabIndex = 5;
            this.label_static_hudauthor1.Text = "Author";
            // 
            // textBox_Fragment_Author
            // 
            this.textBox_Fragment_Author.Location = new System.Drawing.Point(14, 115);
            this.textBox_Fragment_Author.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fragment_Author.Name = "textBox_Fragment_Author";
            this.textBox_Fragment_Author.Size = new System.Drawing.Size(238, 20);
            this.textBox_Fragment_Author.TabIndex = 4;
            // 
            // label_static_hudversion1
            // 
            this.label_static_hudversion1.AutoSize = true;
            this.label_static_hudversion1.Location = new System.Drawing.Point(12, 55);
            this.label_static_hudversion1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.label_static_hudversion1.Name = "label_static_hudversion1";
            this.label_static_hudversion1.Size = new System.Drawing.Size(42, 13);
            this.label_static_hudversion1.TabIndex = 3;
            this.label_static_hudversion1.Text = "Version";
            // 
            // textBox_Fragment_Version
            // 
            this.textBox_Fragment_Version.Location = new System.Drawing.Point(14, 74);
            this.textBox_Fragment_Version.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fragment_Version.Name = "textBox_Fragment_Version";
            this.textBox_Fragment_Version.Size = new System.Drawing.Size(238, 20);
            this.textBox_Fragment_Version.TabIndex = 2;
            // 
            // label_static_hudname1
            // 
            this.label_static_hudname1.AutoSize = true;
            this.label_static_hudname1.Location = new System.Drawing.Point(12, 17);
            this.label_static_hudname1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_static_hudname1.Name = "label_static_hudname1";
            this.label_static_hudname1.Size = new System.Drawing.Size(35, 13);
            this.label_static_hudname1.TabIndex = 1;
            this.label_static_hudname1.Text = "Name";
            // 
            // textBox_Fragment_Name
            // 
            this.textBox_Fragment_Name.Location = new System.Drawing.Point(14, 34);
            this.textBox_Fragment_Name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fragment_Name.Name = "textBox_Fragment_Name";
            this.textBox_Fragment_Name.Size = new System.Drawing.Size(238, 20);
            this.textBox_Fragment_Name.TabIndex = 0;
            // 
            // groupBox_Misc
            // 
            this.groupBox_Misc.Controls.Add(this.radio_MinamalDefault);
            this.groupBox_Misc.Controls.Add(this.radio_None);
            this.groupBox_Misc.Controls.Add(this.radio_StripMinimal);
            this.groupBox_Misc.Location = new System.Drawing.Point(175, 243);
            this.groupBox_Misc.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Misc.Name = "groupBox_Misc";
            this.groupBox_Misc.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Misc.Size = new System.Drawing.Size(267, 39);
            this.groupBox_Misc.TabIndex = 21;
            this.groupBox_Misc.TabStop = false;
            this.groupBox_Misc.Text = "Misc";
            // 
            // radio_MinamalDefault
            // 
            this.radio_MinamalDefault.AutoSize = true;
            this.radio_MinamalDefault.Location = new System.Drawing.Point(157, 15);
            this.radio_MinamalDefault.Margin = new System.Windows.Forms.Padding(2);
            this.radio_MinamalDefault.Name = "radio_MinamalDefault";
            this.radio_MinamalDefault.Size = new System.Drawing.Size(109, 17);
            this.radio_MinamalDefault.TabIndex = 21;
            this.radio_MinamalDefault.Text = "Minimal to Default";
            this.radio_MinamalDefault.UseVisualStyleBackColor = true;
            // 
            // radio_None
            // 
            this.radio_None.AutoSize = true;
            this.radio_None.Checked = true;
            this.radio_None.Location = new System.Drawing.Point(16, 15);
            this.radio_None.Margin = new System.Windows.Forms.Padding(2);
            this.radio_None.Name = "radio_None";
            this.radio_None.Size = new System.Drawing.Size(51, 17);
            this.radio_None.TabIndex = 20;
            this.radio_None.TabStop = true;
            this.radio_None.Text = "None";
            this.radio_None.UseVisualStyleBackColor = true;
            // 
            // radio_StripMinimal
            // 
            this.radio_StripMinimal.AutoSize = true;
            this.radio_StripMinimal.Location = new System.Drawing.Point(70, 15);
            this.radio_StripMinimal.Margin = new System.Windows.Forms.Padding(2);
            this.radio_StripMinimal.Name = "radio_StripMinimal";
            this.radio_StripMinimal.Size = new System.Drawing.Size(84, 17);
            this.radio_StripMinimal.TabIndex = 19;
            this.radio_StripMinimal.Text = "Strip Minimal";
            this.radio_StripMinimal.UseVisualStyleBackColor = true;
            // 
            // label_Static_Hud1
            // 
            this.label_Static_Hud1.AutoSize = true;
            this.label_Static_Hud1.Location = new System.Drawing.Point(12, 13);
            this.label_Static_Hud1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_Hud1.Name = "label_Static_Hud1";
            this.label_Static_Hud1.Size = new System.Drawing.Size(27, 13);
            this.label_Static_Hud1.TabIndex = 17;
            this.label_Static_Hud1.Text = "Hud";
            // 
            // button_FragmentHudBrowse
            // 
            this.button_FragmentHudBrowse.Location = new System.Drawing.Point(104, 213);
            this.button_FragmentHudBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.button_FragmentHudBrowse.Name = "button_FragmentHudBrowse";
            this.button_FragmentHudBrowse.Size = new System.Drawing.Size(56, 28);
            this.button_FragmentHudBrowse.TabIndex = 16;
            this.button_FragmentHudBrowse.Text = "Browse";
            this.button_FragmentHudBrowse.UseVisualStyleBackColor = true;
            this.button_FragmentHudBrowse.Click += new System.EventHandler(this.button_FragmentHudBrowse_Click);
            // 
            // textBox_FragmentHudBrowse
            // 
            this.textBox_FragmentHudBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FragmentHudBrowse.Location = new System.Drawing.Point(14, 214);
            this.textBox_FragmentHudBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FragmentHudBrowse.Name = "textBox_FragmentHudBrowse";
            this.textBox_FragmentHudBrowse.ReadOnly = true;
            this.textBox_FragmentHudBrowse.Size = new System.Drawing.Size(86, 26);
            this.textBox_FragmentHudBrowse.TabIndex = 15;
            this.textBox_FragmentHudBrowse.TextChanged += new System.EventHandler(this.textBox_FragmentHudBrowse_TextChanged);
            // 
            // textBox_FragmentHudMain
            // 
            this.textBox_FragmentHudMain.Location = new System.Drawing.Point(14, 31);
            this.textBox_FragmentHudMain.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FragmentHudMain.Name = "textBox_FragmentHudMain";
            this.textBox_FragmentHudMain.ReadOnly = true;
            this.textBox_FragmentHudMain.Size = new System.Drawing.Size(146, 20);
            this.textBox_FragmentHudMain.TabIndex = 14;
            this.textBox_FragmentHudMain.TabStop = false;
            // 
            // pictureBox_FragmentHudMain
            // 
            this.pictureBox_FragmentHudMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_FragmentHudMain.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FragmentHudMain.Image")));
            this.pictureBox_FragmentHudMain.Location = new System.Drawing.Point(14, 54);
            this.pictureBox_FragmentHudMain.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_FragmentHudMain.Name = "pictureBox_FragmentHudMain";
            this.pictureBox_FragmentHudMain.Size = new System.Drawing.Size(146, 156);
            this.pictureBox_FragmentHudMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_FragmentHudMain.TabIndex = 13;
            this.pictureBox_FragmentHudMain.TabStop = false;
            // 
            // button_FragmentMain
            // 
            this.button_FragmentMain.Location = new System.Drawing.Point(14, 246);
            this.button_FragmentMain.Margin = new System.Windows.Forms.Padding(2);
            this.button_FragmentMain.Name = "button_FragmentMain";
            this.button_FragmentMain.Size = new System.Drawing.Size(146, 36);
            this.button_FragmentMain.TabIndex = 12;
            this.button_FragmentMain.Text = "Create Blueprint";
            this.button_FragmentMain.UseVisualStyleBackColor = true;
            this.button_FragmentMain.Click += new System.EventHandler(this.button_FragmentMain_Click);
            // 
            // tab_CombineHuds
            // 
            this.tab_CombineHuds.BackColor = System.Drawing.Color.Transparent;
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineHudUseDefault2);
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineHudUseDefault1);
            this.tab_CombineHuds.Controls.Add(this.button_CombineResultClearLogo);
            this.tab_CombineHuds.Controls.Add(this.button_CombineResultBrowseLogo);
            this.tab_CombineHuds.Controls.Add(this.button_CombineBrowse2);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineBrowse2);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineBrowse1);
            this.tab_CombineHuds.Controls.Add(this.button_CombineBrowse1);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineHud_Result);
            this.tab_CombineHuds.Controls.Add(this.label_Static_Result);
            this.tab_CombineHuds.Controls.Add(this.label_CombineMinmode2);
            this.tab_CombineHuds.Controls.Add(this.label_CombineMinmode1);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineHudName2);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineHudName1);
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineUseMinimal2);
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineUseMinimal1);
            this.tab_CombineHuds.Controls.Add(this.button_Combine);
            this.tab_CombineHuds.Controls.Add(this.pictureBox1);
            this.tab_CombineHuds.Controls.Add(this.PictureBox_CombineHud2);
            this.tab_CombineHuds.Controls.Add(this.PictureBox_CombineHud1);
            this.tab_CombineHuds.Location = new System.Drawing.Point(4, 22);
            this.tab_CombineHuds.Margin = new System.Windows.Forms.Padding(2);
            this.tab_CombineHuds.Name = "tab_CombineHuds";
            this.tab_CombineHuds.Padding = new System.Windows.Forms.Padding(2);
            this.tab_CombineHuds.Size = new System.Drawing.Size(457, 289);
            this.tab_CombineHuds.TabIndex = 1;
            this.tab_CombineHuds.Text = "Combine Huds";
            // 
            // checkBox_CombineHudUseDefault2
            // 
            this.checkBox_CombineHudUseDefault2.AutoSize = true;
            this.checkBox_CombineHudUseDefault2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_CombineHudUseDefault2.Location = new System.Drawing.Point(314, 263);
            this.checkBox_CombineHudUseDefault2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CombineHudUseDefault2.Name = "checkBox_CombineHudUseDefault2";
            this.checkBox_CombineHudUseDefault2.Size = new System.Drawing.Size(127, 17);
            this.checkBox_CombineHudUseDefault2.TabIndex = 19;
            this.checkBox_CombineHudUseDefault2.Text = "Use Default TF2 Hud";
            this.checkBox_CombineHudUseDefault2.UseVisualStyleBackColor = true;
            // 
            // checkBox_CombineHudUseDefault1
            // 
            this.checkBox_CombineHudUseDefault1.AutoSize = true;
            this.checkBox_CombineHudUseDefault1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_CombineHudUseDefault1.Location = new System.Drawing.Point(13, 263);
            this.checkBox_CombineHudUseDefault1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CombineHudUseDefault1.Name = "checkBox_CombineHudUseDefault1";
            this.checkBox_CombineHudUseDefault1.Size = new System.Drawing.Size(127, 17);
            this.checkBox_CombineHudUseDefault1.TabIndex = 18;
            this.checkBox_CombineHudUseDefault1.Text = "Use Default TF2 Hud";
            this.checkBox_CombineHudUseDefault1.UseVisualStyleBackColor = true;
            // 
            // button_CombineResultClearLogo
            // 
            this.button_CombineResultClearLogo.Location = new System.Drawing.Point(278, 214);
            this.button_CombineResultClearLogo.Margin = new System.Windows.Forms.Padding(2);
            this.button_CombineResultClearLogo.Name = "button_CombineResultClearLogo";
            this.button_CombineResultClearLogo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button_CombineResultClearLogo.Size = new System.Drawing.Size(20, 22);
            this.button_CombineResultClearLogo.TabIndex = 17;
            this.button_CombineResultClearLogo.Text = "X";
            this.button_CombineResultClearLogo.UseVisualStyleBackColor = true;
            // 
            // button_CombineResultBrowseLogo
            // 
            this.button_CombineResultBrowseLogo.Location = new System.Drawing.Point(162, 214);
            this.button_CombineResultBrowseLogo.Margin = new System.Windows.Forms.Padding(2);
            this.button_CombineResultBrowseLogo.Name = "button_CombineResultBrowseLogo";
            this.button_CombineResultBrowseLogo.Size = new System.Drawing.Size(112, 22);
            this.button_CombineResultBrowseLogo.TabIndex = 16;
            this.button_CombineResultBrowseLogo.Text = "Pick logo";
            this.button_CombineResultBrowseLogo.UseVisualStyleBackColor = true;
            // 
            // button_CombineBrowse2
            // 
            this.button_CombineBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CombineBrowse2.Location = new System.Drawing.Point(397, 213);
            this.button_CombineBrowse2.Margin = new System.Windows.Forms.Padding(2);
            this.button_CombineBrowse2.Name = "button_CombineBrowse2";
            this.button_CombineBrowse2.Size = new System.Drawing.Size(52, 22);
            this.button_CombineBrowse2.TabIndex = 15;
            this.button_CombineBrowse2.Text = "Browse";
            this.button_CombineBrowse2.UseVisualStyleBackColor = true;
            this.button_CombineBrowse2.Click += new System.EventHandler(this.button_CombineBrowse2_Click);
            // 
            // textBox_CombineBrowse2
            // 
            this.textBox_CombineBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CombineBrowse2.Location = new System.Drawing.Point(314, 214);
            this.textBox_CombineBrowse2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CombineBrowse2.Name = "textBox_CombineBrowse2";
            this.textBox_CombineBrowse2.Size = new System.Drawing.Size(80, 19);
            this.textBox_CombineBrowse2.TabIndex = 14;
            this.textBox_CombineBrowse2.TextChanged += new System.EventHandler(this.textBox_CombineBrowse2_TextChanged);
            // 
            // textBox_CombineBrowse1
            // 
            this.textBox_CombineBrowse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CombineBrowse1.Location = new System.Drawing.Point(12, 214);
            this.textBox_CombineBrowse1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CombineBrowse1.Name = "textBox_CombineBrowse1";
            this.textBox_CombineBrowse1.Size = new System.Drawing.Size(80, 19);
            this.textBox_CombineBrowse1.TabIndex = 13;
            this.textBox_CombineBrowse1.TextChanged += new System.EventHandler(this.textBox_CombineBrowse1_TextChanged);
            // 
            // button_CombineBrowse1
            // 
            this.button_CombineBrowse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CombineBrowse1.Location = new System.Drawing.Point(94, 213);
            this.button_CombineBrowse1.Margin = new System.Windows.Forms.Padding(2);
            this.button_CombineBrowse1.Name = "button_CombineBrowse1";
            this.button_CombineBrowse1.Size = new System.Drawing.Size(52, 22);
            this.button_CombineBrowse1.TabIndex = 12;
            this.button_CombineBrowse1.Text = "Browse";
            this.button_CombineBrowse1.UseVisualStyleBackColor = true;
            this.button_CombineBrowse1.Click += new System.EventHandler(this.button_CombineBrowse1_Click);
            // 
            // textBox_CombineHud_Result
            // 
            this.textBox_CombineHud_Result.Location = new System.Drawing.Point(163, 40);
            this.textBox_CombineHud_Result.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CombineHud_Result.Name = "textBox_CombineHud_Result";
            this.textBox_CombineHud_Result.Size = new System.Drawing.Size(134, 20);
            this.textBox_CombineHud_Result.TabIndex = 11;
            this.textBox_CombineHud_Result.Text = "CombinedHudName";
            // 
            // label_Static_Result
            // 
            this.label_Static_Result.AutoSize = true;
            this.label_Static_Result.Location = new System.Drawing.Point(161, 24);
            this.label_Static_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Static_Result.Name = "label_Static_Result";
            this.label_Static_Result.Size = new System.Drawing.Size(37, 13);
            this.label_Static_Result.TabIndex = 10;
            this.label_Static_Result.Text = "Result";
            // 
            // label_CombineMinmode2
            // 
            this.label_CombineMinmode2.AutoSize = true;
            this.label_CombineMinmode2.Location = new System.Drawing.Point(311, 24);
            this.label_CombineMinmode2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CombineMinmode2.Name = "label_CombineMinmode2";
            this.label_CombineMinmode2.Size = new System.Drawing.Size(96, 13);
            this.label_CombineMinmode2.TabIndex = 8;
            this.label_CombineMinmode2.Text = "cl_hud_minmode 1";
            // 
            // label_CombineMinmode1
            // 
            this.label_CombineMinmode1.AutoSize = true;
            this.label_CombineMinmode1.Location = new System.Drawing.Point(10, 24);
            this.label_CombineMinmode1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CombineMinmode1.Name = "label_CombineMinmode1";
            this.label_CombineMinmode1.Size = new System.Drawing.Size(96, 13);
            this.label_CombineMinmode1.TabIndex = 7;
            this.label_CombineMinmode1.Text = "cl_hud_minmode 0";
            // 
            // textBox_CombineHudName2
            // 
            this.textBox_CombineHudName2.Location = new System.Drawing.Point(314, 40);
            this.textBox_CombineHudName2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CombineHudName2.Name = "textBox_CombineHudName2";
            this.textBox_CombineHudName2.ReadOnly = true;
            this.textBox_CombineHudName2.Size = new System.Drawing.Size(134, 20);
            this.textBox_CombineHudName2.TabIndex = 6;
            this.textBox_CombineHudName2.TabStop = false;
            // 
            // textBox_CombineHudName1
            // 
            this.textBox_CombineHudName1.Location = new System.Drawing.Point(12, 40);
            this.textBox_CombineHudName1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CombineHudName1.Name = "textBox_CombineHudName1";
            this.textBox_CombineHudName1.ReadOnly = true;
            this.textBox_CombineHudName1.Size = new System.Drawing.Size(134, 20);
            this.textBox_CombineHudName1.TabIndex = 5;
            this.textBox_CombineHudName1.TabStop = false;
            // 
            // checkBox_CombineUseMinimal2
            // 
            this.checkBox_CombineUseMinimal2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_CombineUseMinimal2.Location = new System.Drawing.Point(314, 240);
            this.checkBox_CombineUseMinimal2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CombineUseMinimal2.Name = "checkBox_CombineUseMinimal2";
            this.checkBox_CombineUseMinimal2.Size = new System.Drawing.Size(134, 20);
            this.checkBox_CombineUseMinimal2.TabIndex = 4;
            this.checkBox_CombineUseMinimal2.Text = "Use Minmode values";
            this.checkBox_CombineUseMinimal2.UseVisualStyleBackColor = true;
            // 
            // checkBox_CombineUseMinimal1
            // 
            this.checkBox_CombineUseMinimal1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_CombineUseMinimal1.Location = new System.Drawing.Point(13, 240);
            this.checkBox_CombineUseMinimal1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CombineUseMinimal1.Name = "checkBox_CombineUseMinimal1";
            this.checkBox_CombineUseMinimal1.Size = new System.Drawing.Size(134, 18);
            this.checkBox_CombineUseMinimal1.TabIndex = 3;
            this.checkBox_CombineUseMinimal1.Text = "Use Minmode values";
            this.checkBox_CombineUseMinimal1.UseVisualStyleBackColor = true;
            // 
            // button_Combine
            // 
            this.button_Combine.Location = new System.Drawing.Point(162, 240);
            this.button_Combine.Margin = new System.Windows.Forms.Padding(2);
            this.button_Combine.Name = "button_Combine";
            this.button_Combine.Size = new System.Drawing.Size(136, 40);
            this.button_Combine.TabIndex = 2;
            this.button_Combine.Text = "Combine";
            this.button_Combine.UseVisualStyleBackColor = true;
            this.button_Combine.Click += new System.EventHandler(this.button_Combine_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(163, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // PictureBox_CombineHud2
            // 
            this.PictureBox_CombineHud2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_CombineHud2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_CombineHud2.Image")));
            this.PictureBox_CombineHud2.Location = new System.Drawing.Point(314, 64);
            this.PictureBox_CombineHud2.Margin = new System.Windows.Forms.Padding(2);
            this.PictureBox_CombineHud2.Name = "PictureBox_CombineHud2";
            this.PictureBox_CombineHud2.Size = new System.Drawing.Size(134, 145);
            this.PictureBox_CombineHud2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_CombineHud2.TabIndex = 1;
            this.PictureBox_CombineHud2.TabStop = false;
            // 
            // PictureBox_CombineHud1
            // 
            this.PictureBox_CombineHud1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_CombineHud1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_CombineHud1.Image")));
            this.PictureBox_CombineHud1.Location = new System.Drawing.Point(12, 64);
            this.PictureBox_CombineHud1.Margin = new System.Windows.Forms.Padding(2);
            this.PictureBox_CombineHud1.Name = "PictureBox_CombineHud1";
            this.PictureBox_CombineHud1.Size = new System.Drawing.Size(134, 145);
            this.PictureBox_CombineHud1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_CombineHud1.TabIndex = 0;
            this.PictureBox_CombineHud1.TabStop = false;
            // 
            // tab_About
            // 
            this.tab_About.BackColor = System.Drawing.Color.Transparent;
            this.tab_About.Controls.Add(this.textBox_About);
            this.tab_About.Controls.Add(this.pictureBox_About_Logo);
            this.tab_About.Location = new System.Drawing.Point(4, 22);
            this.tab_About.Margin = new System.Windows.Forms.Padding(2);
            this.tab_About.Name = "tab_About";
            this.tab_About.Size = new System.Drawing.Size(457, 289);
            this.tab_About.TabIndex = 2;
            this.tab_About.Text = "About";
            // 
            // textBox_About
            // 
            this.textBox_About.AcceptsReturn = true;
            this.textBox_About.AcceptsTab = true;
            this.textBox_About.CausesValidation = false;
            this.textBox_About.Location = new System.Drawing.Point(188, 23);
            this.textBox_About.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_About.Multiline = true;
            this.textBox_About.Name = "textBox_About";
            this.textBox_About.ReadOnly = true;
            this.textBox_About.Size = new System.Drawing.Size(260, 188);
            this.textBox_About.TabIndex = 1;
            this.textBox_About.TabStop = false;
            this.textBox_About.Text = resources.GetString("textBox_About.Text");
            // 
            // pictureBox_About_Logo
            // 
            this.pictureBox_About_Logo.Image = global::HudInstaller.Properties.Resources.logo_main;
            this.pictureBox_About_Logo.Location = new System.Drawing.Point(11, 23);
            this.pictureBox_About_Logo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_About_Logo.Name = "pictureBox_About_Logo";
            this.pictureBox_About_Logo.Size = new System.Drawing.Size(172, 187);
            this.pictureBox_About_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_About_Logo.TabIndex = 0;
            this.pictureBox_About_Logo.TabStop = false;
            // 
            // button_ToggleHelp
            // 
            this.button_ToggleHelp.Location = new System.Drawing.Point(397, 10);
            this.button_ToggleHelp.Margin = new System.Windows.Forms.Padding(2);
            this.button_ToggleHelp.Name = "button_ToggleHelp";
            this.button_ToggleHelp.Size = new System.Drawing.Size(76, 22);
            this.button_ToggleHelp.TabIndex = 6;
            this.button_ToggleHelp.Text = "Toggle Help";
            this.button_ToggleHelp.UseVisualStyleBackColor = true;
            this.button_ToggleHelp.Click += new System.EventHandler(this.button_ToggleHelp_Click);
            // 
            // textBox_MainHelpTitle
            // 
            this.textBox_MainHelpTitle.Location = new System.Drawing.Point(485, 30);
            this.textBox_MainHelpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MainHelpTitle.Name = "textBox_MainHelpTitle";
            this.textBox_MainHelpTitle.ReadOnly = true;
            this.textBox_MainHelpTitle.Size = new System.Drawing.Size(356, 20);
            this.textBox_MainHelpTitle.TabIndex = 14;
            // 
            // textBox_MainHelp
            // 
            this.textBox_MainHelp.AcceptsReturn = true;
            this.textBox_MainHelp.AcceptsTab = true;
            this.textBox_MainHelp.Location = new System.Drawing.Point(485, 53);
            this.textBox_MainHelp.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox_MainHelp.Multiline = true;
            this.textBox_MainHelp.Name = "textBox_MainHelp";
            this.textBox_MainHelp.ReadOnly = true;
            this.textBox_MainHelp.Size = new System.Drawing.Size(356, 400);
            this.textBox_MainHelp.TabIndex = 13;
            // 
            // label_Help
            // 
            this.label_Help.AutoSize = true;
            this.label_Help.Location = new System.Drawing.Point(483, 14);
            this.label_Help.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Help.Name = "label_Help";
            this.label_Help.Size = new System.Drawing.Size(29, 13);
            this.label_Help.TabIndex = 12;
            this.label_Help.Text = "Help";
            // 
            // textBox_MainStatus
            // 
            this.textBox_MainStatus.AcceptsReturn = true;
            this.textBox_MainStatus.AcceptsTab = true;
            this.textBox_MainStatus.CausesValidation = false;
            this.textBox_MainStatus.Location = new System.Drawing.Point(9, 330);
            this.textBox_MainStatus.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MainStatus.Multiline = true;
            this.textBox_MainStatus.Name = "textBox_MainStatus";
            this.textBox_MainStatus.ReadOnly = true;
            this.textBox_MainStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MainStatus.Size = new System.Drawing.Size(463, 98);
            this.textBox_MainStatus.TabIndex = 1;
            // 
            // progressBar_Main
            // 
            this.progressBar_Main.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar_Main.Location = new System.Drawing.Point(9, 433);
            this.progressBar_Main.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Main.Name = "progressBar_Main";
            this.progressBar_Main.Size = new System.Drawing.Size(405, 19);
            this.progressBar_Main.TabIndex = 2;
            // 
            // folderBrowse_CombineHud1
            // 
            this.folderBrowse_CombineHud1.Description = "Browse for a Hud folder";
            // 
            // folderBrowse_CombineHud2
            // 
            this.folderBrowse_CombineHud2.Description = "Browse for a Hud folder";
            // 
            // button_MainCancel
            // 
            this.button_MainCancel.Enabled = false;
            this.button_MainCancel.Location = new System.Drawing.Point(416, 432);
            this.button_MainCancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_MainCancel.Name = "button_MainCancel";
            this.button_MainCancel.Size = new System.Drawing.Size(56, 20);
            this.button_MainCancel.TabIndex = 3;
            this.button_MainCancel.Text = "Cancel";
            this.button_MainCancel.UseVisualStyleBackColor = true;
            this.button_MainCancel.Click += new System.EventHandler(this.button_MainCancel_Click);
            // 
            // folderBrowse_Fragment
            // 
            this.folderBrowse_Fragment.Description = "Browse for a Hud Fragment";
            // 
            // folderBrowse_MainInstallPath
            // 
            this.folderBrowse_MainInstallPath.Description = "Browse for TF2 Game Path or any other place you want to Install the Hud";
            // 
            // button_Settings
            // 
            this.button_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Settings.Image = global::HudInstaller.Properties.Resources.icon_settings;
            this.button_Settings.Location = new System.Drawing.Point(374, 10);
            this.button_Settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(22, 22);
            this.button_Settings.TabIndex = 15;
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // saveFile_FragmentHud
            // 
            this.saveFile_FragmentHud.AddExtension = false;
            this.saveFile_FragmentHud.DefaultExt = "*.blu";
            this.saveFile_FragmentHud.Filter = "Hud Blueprint(*.blu)|*.blu";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 462);
            this.Controls.Add(this.button_Settings);
            this.Controls.Add(this.button_MainCancel);
            this.Controls.Add(this.textBox_MainHelpTitle);
            this.Controls.Add(this.progressBar_Main);
            this.Controls.Add(this.textBox_MainHelp);
            this.Controls.Add(this.label_Help);
            this.Controls.Add(this.textBox_MainStatus);
            this.Controls.Add(this.button_ToggleHelp);
            this.Controls.Add(this.tabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hud ToolBox";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tab_Install.ResumeLayout(false);
            this.tab_Install.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox_HudInfo.ResumeLayout(false);
            this.groupBox_HudInfo.PerformLayout();
            this.groupBox_InstallMode.ResumeLayout(false);
            this.groupBox_InstallMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_HudThumb)).EndInit();
            this.tab_Fragment.ResumeLayout(false);
            this.tab_Fragment.PerformLayout();
            this.groupBox_HudInfo1.ResumeLayout(false);
            this.groupBox_HudInfo1.PerformLayout();
            this.groupBox_Misc.ResumeLayout(false);
            this.groupBox_Misc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FragmentHudMain)).EndInit();
            this.tab_CombineHuds.ResumeLayout(false);
            this.tab_CombineHuds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CombineHud2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CombineHud1)).EndInit();
            this.tab_About.ResumeLayout(false);
            this.tab_About.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_About_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tab_Install;
        private System.Windows.Forms.Button button_Parse;
        private System.Windows.Forms.TabPage tab_CombineHuds;
        private System.Windows.Forms.TextBox textBox_MainStatus;
        private System.Windows.Forms.PictureBox PictureBox_HudThumb;
        private System.Windows.Forms.ProgressBar progressBar_Main;
        private System.Windows.Forms.TabPage tab_About;
        private System.Windows.Forms.TextBox textBox_CombineHud_Result;
        private System.Windows.Forms.Label label_Static_Result;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_CombineMinmode2;
        private System.Windows.Forms.Label label_CombineMinmode1;
        private System.Windows.Forms.TextBox textBox_CombineHudName2;
        private System.Windows.Forms.TextBox textBox_CombineHudName1;
        private System.Windows.Forms.CheckBox checkBox_CombineUseMinimal2;
        private System.Windows.Forms.CheckBox checkBox_CombineUseMinimal1;
        private System.Windows.Forms.Button button_Combine;
        private System.Windows.Forms.PictureBox PictureBox_CombineHud2;
        private System.Windows.Forms.PictureBox PictureBox_CombineHud1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowse_CombineHud1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowse_CombineHud2;
        private System.Windows.Forms.Button button_MainCancel;
        private System.Windows.Forms.Button button_CombineBrowse2;
        private System.Windows.Forms.TextBox textBox_CombineBrowse2;
        private System.Windows.Forms.TextBox textBox_CombineBrowse1;
        private System.Windows.Forms.Button button_CombineBrowse1;
        private System.Windows.Forms.Button button_CombineResultBrowseLogo;
        private System.Windows.Forms.PictureBox pictureBox_About_Logo;
        private System.Windows.Forms.TextBox textBox_About;
        private System.Windows.Forms.Button button_MainBrowse;
        private System.Windows.Forms.TextBox textBox_MainBrowse;
        private System.Windows.Forms.TextBox textBox_HudNameMain;
        private System.Windows.Forms.Button button_ToggleHelp;
        private System.Windows.Forms.Button button_Customize;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.TextBox textBox_MainHelpTitle;
        private System.Windows.Forms.TextBox textBox_MainHelp;
        private System.Windows.Forms.Label label_Help;
        private System.Windows.Forms.CheckBox checkBox_CombineHudUseDefault2;
        private System.Windows.Forms.CheckBox checkBox_CombineHudUseDefault1;
        private System.Windows.Forms.GroupBox groupBox_InstallMode;
        private System.Windows.Forms.RadioButton radio_InstallMode_Hard;
        private System.Windows.Forms.RadioButton radio_InstallMode_Soft;
        private System.Windows.Forms.TabPage tab_Fragment;
        private System.Windows.Forms.GroupBox groupBox_HudInfo1;
        private System.Windows.Forms.Label label_Static_Hud1;
        private System.Windows.Forms.Button button_FragmentHudBrowse;
        private System.Windows.Forms.TextBox textBox_FragmentHudBrowse;
        private System.Windows.Forms.TextBox textBox_FragmentHudMain;
        private System.Windows.Forms.PictureBox pictureBox_FragmentHudMain;
        private System.Windows.Forms.Button button_FragmentMain;
        private System.Windows.Forms.FolderBrowserDialog folderBrowse_Fragment;
        private System.Windows.Forms.Button button_FragmentClearLogo;
        private System.Windows.Forms.Button button_FragmentLogoBrowse;
        private System.Windows.Forms.TextBox textBox_Fragment_LogoBrowse;
        private System.Windows.Forms.Label label_static_logo;
        private System.Windows.Forms.Label label_static_hudwebsite1;
        private System.Windows.Forms.TextBox textBox_Fragment_Website;
        private System.Windows.Forms.Label label_static_hudauthor1;
        private System.Windows.Forms.TextBox textBox_Fragment_Author;
        private System.Windows.Forms.Label label_static_hudversion1;
        private System.Windows.Forms.TextBox textBox_Fragment_Version;
        private System.Windows.Forms.Label label_static_hudname1;
        private System.Windows.Forms.TextBox textBox_Fragment_Name;
        private System.Windows.Forms.OpenFileDialog openFile_FragmentLogoBrowse;
        private System.Windows.Forms.Button button_CombineResultClearLogo;
        private System.Windows.Forms.GroupBox groupBox_HudInfo;
        private System.Windows.Forms.Label label_HudAuthor;
        private System.Windows.Forms.LinkLabel linkLabel_HudWebsite;
        private System.Windows.Forms.Label label_HudVersion;
        private System.Windows.Forms.Label label_HudName;
        private System.Windows.Forms.Label label_Static_HudWebsite;
        private System.Windows.Forms.Label label_Static_HudAuthor;
        private System.Windows.Forms.Label label_Static_HudVersion;
        private System.Windows.Forms.Label label_Static_HudName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button_MainInstallBrowseClear;
        private System.Windows.Forms.Button button_MainInstallBrowse;
        private System.Windows.Forms.TextBox textBox_GameInstallPath;
        private System.Windows.Forms.Label label_TF2Folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowse_MainInstallPath;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.Label label_static_hud;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox_Misc;
        private System.Windows.Forms.RadioButton radio_MinamalDefault;
        private System.Windows.Forms.RadioButton radio_None;
        private System.Windows.Forms.RadioButton radio_StripMinimal;
        private System.Windows.Forms.SaveFileDialog saveFile_FragmentHud;
    }
}

