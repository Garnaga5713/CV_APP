using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_APP
{
    public partial class Skills : Form
    {
        string level, lang, fio, mai, educa, exper;
        public Skills(string level, string lang, string fio, string mai,string educ,string exper)
        {
            this.level = level;
            this.lang = lang;
            this.fio = fio;
            this.mai = mai;
            this.educa = educ;
            this.exper = exper;
            InitializeComponent();
            loadcomb();
            label7.Text = "Level of English";
            label8.Text = "Skiils";
            richTextBox3.Text = "C#\nSQL\nHTML\nCSS\nJS\n";
            comboBox3.Text = "B1-Intermediate";
        }

        void loadcomb()
        {
            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.Items.Add("A1-Beginner");
            comboBox3.Items.Add("A2-Elementary");
            comboBox3.Items.Add("B1-Intermediate");
            comboBox3.Items.Add("B2-Upper-Intermediate");
            comboBox3.Items.Add("C1-Advanced");
            comboBox3.Items.Add("C2-Proficiently");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(level, lang, fio, mai, educa, exper, comboBox3.Text, richTextBox3.Text);
            form1.ShowDialog();
        }
    }
}
