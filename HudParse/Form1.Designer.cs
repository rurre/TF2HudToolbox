namespace HudParse
{
    partial class Form1
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
            this.pathBox = new System.Windows.Forms.TextBox();
            this.parseButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.testButton2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.hudPathBox = new System.Windows.Forms.TextBox();
            this.browseHudButton = new System.Windows.Forms.Button();
            this.parseHudButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.AllowDrop = true;
            this.pathBox.Location = new System.Drawing.Point(13, 13);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(355, 22);
            this.pathBox.TabIndex = 0;
            this.pathBox.Text = "D:\\Desktop\\test.txt";
            // 
            // parseButton
            // 
            this.parseButton.Location = new System.Drawing.Point(471, 12);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(93, 23);
            this.parseButton.TabIndex = 1;
            this.parseButton.Text = "Parse File";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.AcceptsTab = true;
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(13, 73);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(551, 405);
            this.output.TabIndex = 2;
            this.output.WordWrap = false;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(373, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(92, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testButton.Location = new System.Drawing.Point(13, 485);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(260, 23);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // testButton2
            // 
            this.testButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton2.Location = new System.Drawing.Point(279, 484);
            this.testButton2.Name = "testButton2";
            this.testButton2.Size = new System.Drawing.Size(285, 23);
            this.testButton2.TabIndex = 5;
            this.testButton2.Text = "Test 2";
            this.testButton2.UseVisualStyleBackColor = true;
            this.testButton2.Click += new System.EventHandler(this.testButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // hudPathBox
            // 
            this.hudPathBox.AllowDrop = true;
            this.hudPathBox.Location = new System.Drawing.Point(13, 41);
            this.hudPathBox.Name = "hudPathBox";
            this.hudPathBox.Size = new System.Drawing.Size(355, 22);
            this.hudPathBox.TabIndex = 6;
            this.hudPathBox.Text = "D:\\Desktop\\testhud\\";
            // 
            // browseHudButton
            // 
            this.browseHudButton.Location = new System.Drawing.Point(373, 40);
            this.browseHudButton.Name = "browseHudButton";
            this.browseHudButton.Size = new System.Drawing.Size(92, 23);
            this.browseHudButton.TabIndex = 7;
            this.browseHudButton.Text = "Browse";
            this.browseHudButton.UseVisualStyleBackColor = true;
            this.browseHudButton.Click += new System.EventHandler(this.browseHudButton_Click);
            // 
            // parseHudButton
            // 
            this.parseHudButton.Location = new System.Drawing.Point(471, 40);
            this.parseHudButton.Name = "parseHudButton";
            this.parseHudButton.Size = new System.Drawing.Size(93, 23);
            this.parseHudButton.TabIndex = 8;
            this.parseHudButton.Text = "Parse Hud";
            this.parseHudButton.UseVisualStyleBackColor = true;
            this.parseHudButton.Click += new System.EventHandler(this.parseHudButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 518);
            this.Controls.Add(this.parseHudButton);
            this.Controls.Add(this.browseHudButton);
            this.Controls.Add(this.hudPathBox);
            this.Controls.Add(this.testButton2);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.output);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.pathBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button testButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox hudPathBox;
        private System.Windows.Forms.Button browseHudButton;
        private System.Windows.Forms.Button parseHudButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

