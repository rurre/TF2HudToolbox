using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HudInstaller
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {            
            InitializeComponent();
            foreach(object o in langArray)
            {                            
                comboBox_Language.Items.Add(o);                
            }            
        }

        int newLanguage;
        int oldLanguage;
        System.Array langArray = Enum.GetValues(typeof(MainForm.Languages));

        public int NewLanguage
        {
            get
            {
                return newLanguage;
            }
        }

        public int OldLanguage
        {
            get
            {
                return oldLanguage;
            }

            set
            {
                oldLanguage = value;
            }
        }

        private void button_Ok_Click(object sender,EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if(comboBox_Language.SelectedIndex != oldLanguage)
            {
                newLanguage = comboBox_Language.SelectedIndex;
            }
            else
                newLanguage = oldLanguage;
            this.Close();
        }

        private void SettingsForm_Load(object sender,EventArgs e)
        {
            var temp = (MainForm.Languages)OldLanguage;            
            comboBox_Language.Text = temp.ToString();
        }
    }
}
