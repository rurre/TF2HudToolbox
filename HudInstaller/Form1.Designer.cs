namespace HudInstaller
{
    partial class mainForm
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
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tab_Install = new System.Windows.Forms.TabPage();
            this.groupBox_InstallMode = new System.Windows.Forms.GroupBox();
            this.radio_InstallMode_Hard = new System.Windows.Forms.RadioButton();
            this.radio_InstallMode_Soft = new System.Windows.Forms.RadioButton();
            this.textBox_MainHelpTitle = new System.Windows.Forms.TextBox();
            this.textBox_MainHelp = new System.Windows.Forms.TextBox();
            this.label_Help = new System.Windows.Forms.Label();
            this.label_Hud = new System.Windows.Forms.Label();
            this.button_Install = new System.Windows.Forms.Button();
            this.button_MinimalDefault = new System.Windows.Forms.Button();
            this.button_StripMinimal = new System.Windows.Forms.Button();
            this.button_Fragment = new System.Windows.Forms.Button();
            this.button_Customize = new System.Windows.Forms.Button();
            this.button_MainBrowse = new System.Windows.Forms.Button();
            this.textBox_MainBrowse = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PictureBox_HudThumb = new System.Windows.Forms.PictureBox();
            this.button_Parse = new System.Windows.Forms.Button();
            this.tab_CombineHuds = new System.Windows.Forms.TabPage();
            this.checkBox_CombineHud2UseDefault = new System.Windows.Forms.CheckBox();
            this.checkBox_CombineHud1UseDefault = new System.Windows.Forms.CheckBox();
            this.button_CombineResultClearLogo = new System.Windows.Forms.Button();
            this.button_CombineResultBrowseLogo = new System.Windows.Forms.Button();
            this.button_CombineBrowse2 = new System.Windows.Forms.Button();
            this.textBox_CombineBrowse2 = new System.Windows.Forms.TextBox();
            this.textBox_CombineBrowse1 = new System.Windows.Forms.TextBox();
            this.button_CombineBrowse1 = new System.Windows.Forms.Button();
            this.textBox_CombineHud_Result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.textBox_MainStatus = new System.Windows.Forms.TextBox();
            this.progressBar_Main = new System.Windows.Forms.ProgressBar();
            this.folderBrowse_CombineHud1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowse_CombineHud2 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_MainCancel = new System.Windows.Forms.Button();
            this.tabControl_Main.SuspendLayout();
            this.tab_Install.SuspendLayout();
            this.groupBox_InstallMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_HudThumb)).BeginInit();
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
            this.tabControl_Main.Controls.Add(this.tab_CombineHuds);
            this.tabControl_Main.Controls.Add(this.tab_About);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(620, 388);
            this.tabControl_Main.TabIndex = 0;
            // 
            // tab_Install
            // 
            this.tab_Install.BackColor = System.Drawing.Color.Transparent;
            this.tab_Install.Controls.Add(this.groupBox_InstallMode);
            this.tab_Install.Controls.Add(this.textBox_MainHelpTitle);
            this.tab_Install.Controls.Add(this.textBox_MainHelp);
            this.tab_Install.Controls.Add(this.label_Help);
            this.tab_Install.Controls.Add(this.label_Hud);
            this.tab_Install.Controls.Add(this.button_Install);
            this.tab_Install.Controls.Add(this.button_MinimalDefault);
            this.tab_Install.Controls.Add(this.button_StripMinimal);
            this.tab_Install.Controls.Add(this.button_Fragment);
            this.tab_Install.Controls.Add(this.button_Customize);
            this.tab_Install.Controls.Add(this.button_MainBrowse);
            this.tab_Install.Controls.Add(this.textBox_MainBrowse);
            this.tab_Install.Controls.Add(this.textBox1);
            this.tab_Install.Controls.Add(this.PictureBox_HudThumb);
            this.tab_Install.Controls.Add(this.button_Parse);
            this.tab_Install.Location = new System.Drawing.Point(4, 25);
            this.tab_Install.Name = "tab_Install";
            this.tab_Install.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Install.Size = new System.Drawing.Size(612, 359);
            this.tab_Install.TabIndex = 0;
            this.tab_Install.Text = "Install Hud";
            // 
            // groupBox_InstallMode
            // 
            this.groupBox_InstallMode.Controls.Add(this.radio_InstallMode_Hard);
            this.groupBox_InstallMode.Controls.Add(this.radio_InstallMode_Soft);
            this.groupBox_InstallMode.Location = new System.Drawing.Point(423, 171);
            this.groupBox_InstallMode.Name = "groupBox_InstallMode";
            this.groupBox_InstallMode.Size = new System.Drawing.Size(170, 80);
            this.groupBox_InstallMode.TabIndex = 18;
            this.groupBox_InstallMode.TabStop = false;
            this.groupBox_InstallMode.Text = "Install Mode";
            // 
            // radio_InstallMode_Hard
            // 
            this.radio_InstallMode_Hard.AutoSize = true;
            this.radio_InstallMode_Hard.Location = new System.Drawing.Point(7, 22);
            this.radio_InstallMode_Hard.Name = "radio_InstallMode_Hard";
            this.radio_InstallMode_Hard.Size = new System.Drawing.Size(60, 21);
            this.radio_InstallMode_Hard.TabIndex = 16;
            this.radio_InstallMode_Hard.Text = "Hard";
            this.radio_InstallMode_Hard.UseVisualStyleBackColor = true;
            // 
            // radio_InstallMode_Soft
            // 
            this.radio_InstallMode_Soft.AutoSize = true;
            this.radio_InstallMode_Soft.Checked = true;
            this.radio_InstallMode_Soft.Location = new System.Drawing.Point(7, 51);
            this.radio_InstallMode_Soft.Name = "radio_InstallMode_Soft";
            this.radio_InstallMode_Soft.Size = new System.Drawing.Size(163, 21);
            this.radio_InstallMode_Soft.TabIndex = 15;
            this.radio_InstallMode_Soft.TabStop = true;
            this.radio_InstallMode_Soft.Text = "Soft (Recommended)";
            this.radio_InstallMode_Soft.UseVisualStyleBackColor = true;
            // 
            // textBox_MainHelpTitle
            // 
            this.textBox_MainHelpTitle.Location = new System.Drawing.Point(222, 36);
            this.textBox_MainHelpTitle.Name = "textBox_MainHelpTitle";
            this.textBox_MainHelpTitle.ReadOnly = true;
            this.textBox_MainHelpTitle.Size = new System.Drawing.Size(192, 22);
            this.textBox_MainHelpTitle.TabIndex = 14;
            // 
            // textBox_MainHelp
            // 
            this.textBox_MainHelp.AcceptsReturn = true;
            this.textBox_MainHelp.AcceptsTab = true;
            this.textBox_MainHelp.Location = new System.Drawing.Point(222, 65);
            this.textBox_MainHelp.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBox_MainHelp.Multiline = true;
            this.textBox_MainHelp.Name = "textBox_MainHelp";
            this.textBox_MainHelp.ReadOnly = true;
            this.textBox_MainHelp.Size = new System.Drawing.Size(192, 276);
            this.textBox_MainHelp.TabIndex = 13;
            // 
            // label_Help
            // 
            this.label_Help.AutoSize = true;
            this.label_Help.Location = new System.Drawing.Point(219, 16);
            this.label_Help.Name = "label_Help";
            this.label_Help.Size = new System.Drawing.Size(37, 17);
            this.label_Help.TabIndex = 12;
            this.label_Help.Text = "Help";
            // 
            // label_Hud
            // 
            this.label_Hud.AutoSize = true;
            this.label_Hud.Location = new System.Drawing.Point(20, 16);
            this.label_Hud.Name = "label_Hud";
            this.label_Hud.Size = new System.Drawing.Size(34, 17);
            this.label_Hud.TabIndex = 11;
            this.label_Hud.Text = "Hud";
            // 
            // button_Install
            // 
            this.button_Install.Location = new System.Drawing.Point(423, 297);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(170, 44);
            this.button_Install.TabIndex = 9;
            this.button_Install.Text = "Install";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.MouseHover += new System.EventHandler(this.button_Install_MouseHover);
            // 
            // button_MinimalDefault
            // 
            this.button_MinimalDefault.Location = new System.Drawing.Point(423, 102);
            this.button_MinimalDefault.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.button_MinimalDefault.Name = "button_MinimalDefault";
            this.button_MinimalDefault.Size = new System.Drawing.Size(170, 31);
            this.button_MinimalDefault.TabIndex = 8;
            this.button_MinimalDefault.Text = "Minimal to Default";
            this.button_MinimalDefault.UseVisualStyleBackColor = true;
            this.button_MinimalDefault.MouseHover += new System.EventHandler(this.button_MinimalDefault_MouseHover);
            // 
            // button_StripMinimal
            // 
            this.button_StripMinimal.Location = new System.Drawing.Point(423, 139);
            this.button_StripMinimal.Name = "button_StripMinimal";
            this.button_StripMinimal.Size = new System.Drawing.Size(170, 31);
            this.button_StripMinimal.TabIndex = 7;
            this.button_StripMinimal.Text = "Strip Minimal";
            this.button_StripMinimal.UseVisualStyleBackColor = true;
            this.button_StripMinimal.MouseHover += new System.EventHandler(this.button_StripMinimal_MouseHover);
            // 
            // button_Fragment
            // 
            this.button_Fragment.Location = new System.Drawing.Point(423, 65);
            this.button_Fragment.Name = "button_Fragment";
            this.button_Fragment.Size = new System.Drawing.Size(170, 31);
            this.button_Fragment.TabIndex = 6;
            this.button_Fragment.Text = "Create Hud Fragment";
            this.button_Fragment.UseVisualStyleBackColor = true;
            this.button_Fragment.MouseHover += new System.EventHandler(this.button_Fragment_MouseHover);
            // 
            // button_Customize
            // 
            this.button_Customize.Location = new System.Drawing.Point(423, 257);
            this.button_Customize.Name = "button_Customize";
            this.button_Customize.Size = new System.Drawing.Size(170, 34);
            this.button_Customize.TabIndex = 5;
            this.button_Customize.Text = "Customize";
            this.button_Customize.UseVisualStyleBackColor = true;
            this.button_Customize.MouseHover += new System.EventHandler(this.button_Customize_MouseHover);
            // 
            // button_MainBrowse
            // 
            this.button_MainBrowse.Location = new System.Drawing.Point(138, 264);
            this.button_MainBrowse.Name = "button_MainBrowse";
            this.button_MainBrowse.Size = new System.Drawing.Size(75, 27);
            this.button_MainBrowse.TabIndex = 4;
            this.button_MainBrowse.Text = "Browse";
            this.button_MainBrowse.UseVisualStyleBackColor = true;
            this.button_MainBrowse.MouseHover += new System.EventHandler(this.button_MainBrowse_MouseHover);
            // 
            // textBox_MainBrowse
            // 
            this.textBox_MainBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MainBrowse.Location = new System.Drawing.Point(19, 264);
            this.textBox_MainBrowse.Name = "textBox_MainBrowse";
            this.textBox_MainBrowse.ReadOnly = true;
            this.textBox_MainBrowse.Size = new System.Drawing.Size(113, 27);
            this.textBox_MainBrowse.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(194, 22);
            this.textBox1.TabIndex = 2;
            // 
            // PictureBox_HudThumb
            // 
            this.PictureBox_HudThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_HudThumb.Location = new System.Drawing.Point(19, 65);
            this.PictureBox_HudThumb.Name = "PictureBox_HudThumb";
            this.PictureBox_HudThumb.Size = new System.Drawing.Size(194, 191);
            this.PictureBox_HudThumb.TabIndex = 1;
            this.PictureBox_HudThumb.TabStop = false;
            // 
            // button_Parse
            // 
            this.button_Parse.Location = new System.Drawing.Point(18, 297);
            this.button_Parse.Name = "button_Parse";
            this.button_Parse.Size = new System.Drawing.Size(195, 44);
            this.button_Parse.TabIndex = 0;
            this.button_Parse.Text = "Parse";
            this.button_Parse.UseVisualStyleBackColor = true;
            this.button_Parse.MouseHover += new System.EventHandler(this.button_Parse_MouseHover);
            // 
            // tab_CombineHuds
            // 
            this.tab_CombineHuds.BackColor = System.Drawing.Color.Transparent;
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineHud2UseDefault);
            this.tab_CombineHuds.Controls.Add(this.checkBox_CombineHud1UseDefault);
            this.tab_CombineHuds.Controls.Add(this.button_CombineResultClearLogo);
            this.tab_CombineHuds.Controls.Add(this.button_CombineResultBrowseLogo);
            this.tab_CombineHuds.Controls.Add(this.button_CombineBrowse2);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineBrowse2);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineBrowse1);
            this.tab_CombineHuds.Controls.Add(this.button_CombineBrowse1);
            this.tab_CombineHuds.Controls.Add(this.textBox_CombineHud_Result);
            this.tab_CombineHuds.Controls.Add(this.label1);
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
            this.tab_CombineHuds.Location = new System.Drawing.Point(4, 25);
            this.tab_CombineHuds.Name = "tab_CombineHuds";
            this.tab_CombineHuds.Padding = new System.Windows.Forms.Padding(3);
            this.tab_CombineHuds.Size = new System.Drawing.Size(612, 359);
            this.tab_CombineHuds.TabIndex = 1;
            this.tab_CombineHuds.Text = "Combine Huds";
            // 
            // checkBox_CombineHud2UseDefault
            // 
            this.checkBox_CombineHud2UseDefault.AutoSize = true;
            this.checkBox_CombineHud2UseDefault.Location = new System.Drawing.Point(418, 324);
            this.checkBox_CombineHud2UseDefault.Name = "checkBox_CombineHud2UseDefault";
            this.checkBox_CombineHud2UseDefault.Size = new System.Drawing.Size(163, 21);
            this.checkBox_CombineHud2UseDefault.TabIndex = 19;
            this.checkBox_CombineHud2UseDefault.Text = "Use Default TF2 Hud";
            this.checkBox_CombineHud2UseDefault.UseVisualStyleBackColor = true;
            // 
            // checkBox_CombineHud1UseDefault
            // 
            this.checkBox_CombineHud1UseDefault.AutoSize = true;
            this.checkBox_CombineHud1UseDefault.Location = new System.Drawing.Point(17, 324);
            this.checkBox_CombineHud1UseDefault.Name = "checkBox_CombineHud1UseDefault";
            this.checkBox_CombineHud1UseDefault.Size = new System.Drawing.Size(163, 21);
            this.checkBox_CombineHud1UseDefault.TabIndex = 18;
            this.checkBox_CombineHud1UseDefault.Text = "Use Default TF2 Hud";
            this.checkBox_CombineHud1UseDefault.UseVisualStyleBackColor = true;
            // 
            // button_CombineResultClearLogo
            // 
            this.button_CombineResultClearLogo.Location = new System.Drawing.Point(371, 263);
            this.button_CombineResultClearLogo.Name = "button_CombineResultClearLogo";
            this.button_CombineResultClearLogo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button_CombineResultClearLogo.Size = new System.Drawing.Size(26, 27);
            this.button_CombineResultClearLogo.TabIndex = 17;
            this.button_CombineResultClearLogo.Text = "X";
            this.button_CombineResultClearLogo.UseVisualStyleBackColor = true;
            // 
            // button_CombineResultBrowseLogo
            // 
            this.button_CombineResultBrowseLogo.Location = new System.Drawing.Point(216, 263);
            this.button_CombineResultBrowseLogo.Name = "button_CombineResultBrowseLogo";
            this.button_CombineResultBrowseLogo.Size = new System.Drawing.Size(149, 27);
            this.button_CombineResultBrowseLogo.TabIndex = 16;
            this.button_CombineResultBrowseLogo.Text = "Pick logo";
            this.button_CombineResultBrowseLogo.UseVisualStyleBackColor = true;
            // 
            // button_CombineBrowse2
            // 
            this.button_CombineBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CombineBrowse2.Location = new System.Drawing.Point(529, 262);
            this.button_CombineBrowse2.Name = "button_CombineBrowse2";
            this.button_CombineBrowse2.Size = new System.Drawing.Size(69, 27);
            this.button_CombineBrowse2.TabIndex = 15;
            this.button_CombineBrowse2.Text = "Browse";
            this.button_CombineBrowse2.UseVisualStyleBackColor = true;
            this.button_CombineBrowse2.Click += new System.EventHandler(this.button_CombineBrowse2_Click);
            // 
            // textBox_CombineBrowse2
            // 
            this.textBox_CombineBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CombineBrowse2.Location = new System.Drawing.Point(418, 263);
            this.textBox_CombineBrowse2.Name = "textBox_CombineBrowse2";
            this.textBox_CombineBrowse2.ReadOnly = true;
            this.textBox_CombineBrowse2.Size = new System.Drawing.Size(106, 22);
            this.textBox_CombineBrowse2.TabIndex = 14;
            // 
            // textBox_CombineBrowse1
            // 
            this.textBox_CombineBrowse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CombineBrowse1.Location = new System.Drawing.Point(16, 263);
            this.textBox_CombineBrowse1.Name = "textBox_CombineBrowse1";
            this.textBox_CombineBrowse1.ReadOnly = true;
            this.textBox_CombineBrowse1.Size = new System.Drawing.Size(105, 22);
            this.textBox_CombineBrowse1.TabIndex = 13;
            // 
            // button_CombineBrowse1
            // 
            this.button_CombineBrowse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CombineBrowse1.Location = new System.Drawing.Point(126, 262);
            this.button_CombineBrowse1.Margin = new System.Windows.Forms.Padding(2);
            this.button_CombineBrowse1.Name = "button_CombineBrowse1";
            this.button_CombineBrowse1.Size = new System.Drawing.Size(69, 27);
            this.button_CombineBrowse1.TabIndex = 12;
            this.button_CombineBrowse1.Text = "Browse";
            this.button_CombineBrowse1.UseVisualStyleBackColor = true;
            this.button_CombineBrowse1.Click += new System.EventHandler(this.button_CombineBrowse1_Click);
            // 
            // textBox_CombineHud_Result
            // 
            this.textBox_CombineHud_Result.Location = new System.Drawing.Point(217, 49);
            this.textBox_CombineHud_Result.Name = "textBox_CombineHud_Result";
            this.textBox_CombineHud_Result.Size = new System.Drawing.Size(178, 22);
            this.textBox_CombineHud_Result.TabIndex = 11;
            this.textBox_CombineHud_Result.Text = "CombinedHudName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Result";
            // 
            // label_CombineMinmode2
            // 
            this.label_CombineMinmode2.AutoSize = true;
            this.label_CombineMinmode2.Location = new System.Drawing.Point(415, 29);
            this.label_CombineMinmode2.Name = "label_CombineMinmode2";
            this.label_CombineMinmode2.Size = new System.Drawing.Size(127, 17);
            this.label_CombineMinmode2.TabIndex = 8;
            this.label_CombineMinmode2.Text = "cl_hud_minmode 1";
            // 
            // label_CombineMinmode1
            // 
            this.label_CombineMinmode1.AutoSize = true;
            this.label_CombineMinmode1.Location = new System.Drawing.Point(13, 29);
            this.label_CombineMinmode1.Name = "label_CombineMinmode1";
            this.label_CombineMinmode1.Size = new System.Drawing.Size(127, 17);
            this.label_CombineMinmode1.TabIndex = 7;
            this.label_CombineMinmode1.Text = "cl_hud_minmode 0";
            // 
            // textBox_CombineHudName2
            // 
            this.textBox_CombineHudName2.Location = new System.Drawing.Point(418, 49);
            this.textBox_CombineHudName2.Name = "textBox_CombineHudName2";
            this.textBox_CombineHudName2.ReadOnly = true;
            this.textBox_CombineHudName2.Size = new System.Drawing.Size(178, 22);
            this.textBox_CombineHudName2.TabIndex = 6;
            // 
            // textBox_CombineHudName1
            // 
            this.textBox_CombineHudName1.Location = new System.Drawing.Point(16, 49);
            this.textBox_CombineHudName1.Name = "textBox_CombineHudName1";
            this.textBox_CombineHudName1.ReadOnly = true;
            this.textBox_CombineHudName1.Size = new System.Drawing.Size(178, 22);
            this.textBox_CombineHudName1.TabIndex = 5;
            // 
            // checkBox_CombineUseMinimal2
            // 
            this.checkBox_CombineUseMinimal2.Location = new System.Drawing.Point(418, 296);
            this.checkBox_CombineUseMinimal2.Name = "checkBox_CombineUseMinimal2";
            this.checkBox_CombineUseMinimal2.Size = new System.Drawing.Size(178, 24);
            this.checkBox_CombineUseMinimal2.TabIndex = 4;
            this.checkBox_CombineUseMinimal2.Text = "Use Minmode values";
            this.checkBox_CombineUseMinimal2.UseVisualStyleBackColor = true;
            // 
            // checkBox_CombineUseMinimal1
            // 
            this.checkBox_CombineUseMinimal1.Location = new System.Drawing.Point(17, 296);
            this.checkBox_CombineUseMinimal1.Name = "checkBox_CombineUseMinimal1";
            this.checkBox_CombineUseMinimal1.Size = new System.Drawing.Size(178, 22);
            this.checkBox_CombineUseMinimal1.TabIndex = 3;
            this.checkBox_CombineUseMinimal1.Text = "Use Minmode values";
            this.checkBox_CombineUseMinimal1.UseVisualStyleBackColor = true;
            // 
            // button_Combine
            // 
            this.button_Combine.Location = new System.Drawing.Point(216, 296);
            this.button_Combine.Name = "button_Combine";
            this.button_Combine.Size = new System.Drawing.Size(181, 49);
            this.button_Combine.TabIndex = 2;
            this.button_Combine.Text = "Combine";
            this.button_Combine.UseVisualStyleBackColor = true;
            this.button_Combine.Click += new System.EventHandler(this.button_Combine_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::HudInstaller.Properties.Resources.logo_default;
            this.pictureBox1.Location = new System.Drawing.Point(217, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // PictureBox_CombineHud2
            // 
            this.PictureBox_CombineHud2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_CombineHud2.Image = global::HudInstaller.Properties.Resources.logo_default;
            this.PictureBox_CombineHud2.Location = new System.Drawing.Point(418, 79);
            this.PictureBox_CombineHud2.Name = "PictureBox_CombineHud2";
            this.PictureBox_CombineHud2.Size = new System.Drawing.Size(178, 178);
            this.PictureBox_CombineHud2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_CombineHud2.TabIndex = 1;
            this.PictureBox_CombineHud2.TabStop = false;
            // 
            // PictureBox_CombineHud1
            // 
            this.PictureBox_CombineHud1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_CombineHud1.Image = global::HudInstaller.Properties.Resources.logo_default;
            this.PictureBox_CombineHud1.Location = new System.Drawing.Point(16, 79);
            this.PictureBox_CombineHud1.Name = "PictureBox_CombineHud1";
            this.PictureBox_CombineHud1.Size = new System.Drawing.Size(178, 178);
            this.PictureBox_CombineHud1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_CombineHud1.TabIndex = 0;
            this.PictureBox_CombineHud1.TabStop = false;
            // 
            // tab_About
            // 
            this.tab_About.BackColor = System.Drawing.Color.Transparent;
            this.tab_About.Controls.Add(this.textBox_About);
            this.tab_About.Controls.Add(this.pictureBox_About_Logo);
            this.tab_About.Location = new System.Drawing.Point(4, 25);
            this.tab_About.Name = "tab_About";
            this.tab_About.Size = new System.Drawing.Size(612, 359);
            this.tab_About.TabIndex = 2;
            this.tab_About.Text = "About";
            // 
            // textBox_About
            // 
            this.textBox_About.AcceptsReturn = true;
            this.textBox_About.AcceptsTab = true;
            this.textBox_About.CausesValidation = false;
            this.textBox_About.Enabled = false;
            this.textBox_About.Location = new System.Drawing.Point(251, 28);
            this.textBox_About.Multiline = true;
            this.textBox_About.Name = "textBox_About";
            this.textBox_About.ReadOnly = true;
            this.textBox_About.Size = new System.Drawing.Size(345, 230);
            this.textBox_About.TabIndex = 1;
            this.textBox_About.Text = "Hud Toolbox v1.0\r\nMade by Pumkin\r\nOr whatever other name I\'m using at the time.\r\n" +
    "\r\nhttp://steamcommunity.com/groups/ivhud";
            // 
            // pictureBox_About_Logo
            // 
            this.pictureBox_About_Logo.Image = global::HudInstaller.Properties.Resources.logo_main;
            this.pictureBox_About_Logo.Location = new System.Drawing.Point(15, 28);
            this.pictureBox_About_Logo.Name = "pictureBox_About_Logo";
            this.pictureBox_About_Logo.Size = new System.Drawing.Size(230, 230);
            this.pictureBox_About_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_About_Logo.TabIndex = 0;
            this.pictureBox_About_Logo.TabStop = false;
            // 
            // textBox_MainStatus
            // 
            this.textBox_MainStatus.AcceptsReturn = true;
            this.textBox_MainStatus.AcceptsTab = true;
            this.textBox_MainStatus.CausesValidation = false;
            this.textBox_MainStatus.Location = new System.Drawing.Point(12, 406);
            this.textBox_MainStatus.Multiline = true;
            this.textBox_MainStatus.Name = "textBox_MainStatus";
            this.textBox_MainStatus.ReadOnly = true;
            this.textBox_MainStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MainStatus.Size = new System.Drawing.Size(616, 120);
            this.textBox_MainStatus.TabIndex = 1;
            // 
            // progressBar_Main
            // 
            this.progressBar_Main.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar_Main.Location = new System.Drawing.Point(12, 533);
            this.progressBar_Main.Name = "progressBar_Main";
            this.progressBar_Main.Size = new System.Drawing.Size(539, 23);
            this.progressBar_Main.TabIndex = 2;
            // 
            // button_MainCancel
            // 
            this.button_MainCancel.Enabled = false;
            this.button_MainCancel.Location = new System.Drawing.Point(554, 532);
            this.button_MainCancel.Name = "button_MainCancel";
            this.button_MainCancel.Size = new System.Drawing.Size(75, 25);
            this.button_MainCancel.TabIndex = 3;
            this.button_MainCancel.Text = "Cancel";
            this.button_MainCancel.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 565);
            this.Controls.Add(this.button_MainCancel);
            this.Controls.Add(this.progressBar_Main);
            this.Controls.Add(this.textBox_MainStatus);
            this.Controls.Add(this.tabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hud ToolBox";
            this.tabControl_Main.ResumeLayout(false);
            this.tab_Install.ResumeLayout(false);
            this.tab_Install.PerformLayout();
            this.groupBox_InstallMode.ResumeLayout(false);
            this.groupBox_InstallMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_HudThumb)).EndInit();
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
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_MinimalDefault;
        private System.Windows.Forms.Button button_StripMinimal;
        private System.Windows.Forms.Button button_Fragment;
        private System.Windows.Forms.Button button_Customize;
        private System.Windows.Forms.Button button_CombineResultClearLogo;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.TextBox textBox_MainHelpTitle;
        private System.Windows.Forms.TextBox textBox_MainHelp;
        private System.Windows.Forms.Label label_Help;
        private System.Windows.Forms.Label label_Hud;
        private System.Windows.Forms.CheckBox checkBox_CombineHud2UseDefault;
        private System.Windows.Forms.CheckBox checkBox_CombineHud1UseDefault;
        private System.Windows.Forms.GroupBox groupBox_InstallMode;
        private System.Windows.Forms.RadioButton radio_InstallMode_Hard;
        private System.Windows.Forms.RadioButton radio_InstallMode_Soft;
    }
}

