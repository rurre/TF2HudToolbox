using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HudParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void parseButton_Click(object sender,EventArgs e)
        {
            //output.AppendText(new HudFile(pathBox.Text).ToString());            
        }

        private void testButton_Click(object sender,EventArgs e)
        {            
            List<KeyValue> ls = new List<KeyValue>();
            ls.Add(new KeyValue("Key 1","Value 1"));
            ls.Add(new KeyValue("Key 2","Value 2"));
            ls.Add(new KeyValue("Key 3","Value 3"));
            ls.Add(new KeyValue("Key 4","Value 4"));
            output.AppendText(new KeyValue("TestBlock", ls, "$X360").ToString());
            output.AppendText(Environment.NewLine);
        }

        private void testButton2_Click(object sender,EventArgs e)
        {
            List<KeyValue> ls = new List<KeyValue>();            
            ls.Add(new KeyValue("Key 1","Value 1"));
            ls.Add(new KeyValue("Key 2","Value 2"));
            ls.Add(new KeyValue("Key 3","Value 3"));
            ls.Add(new KeyValue("Key 4","Value 4"));
            ls.Add(new KeyValue("Key 5","Value 5"));
            ls.Add(new KeyValue("Key 6","Value 6","$X360"));

            List<KeyValue> ls2 = new List<KeyValue>();
            ls2.Add(new KeyValue("TestBlock",ls,"$MAC"));
            ls2.Add(new KeyValue("TestBlock2",ls, "$WIN32"));

            HudFile hf = new HudFile(ls2);

            output.AppendText(hf.ToString());
        }

        private void browseButton_Click(object sender,EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
