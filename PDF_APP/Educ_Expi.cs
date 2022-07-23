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
    public partial class Educ_Expi : Form
    {
        string levels, language, FIO, mail;

        private void Educ_Expi_Load(object sender, EventArgs e)
        {
            richTextBox2.Text = "Univer QWE in Asd\ncourses in asdasd company\n qwe certification in asdqwe conpany";
            richTextBox1.Text = "6 month in zxc company as trainee .net dev";

        }

        public Educ_Expi(string level, string lang,string fio,string mai)
        {
            levels = level;
            language = lang;
            FIO = fio;
            mail = mai;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string words = richTextBox1.Text;
            words += richTextBox2.Text;
            if (richTextBox1.Text != "" && richTextBox2.Text != ""&&words.Length>100)
            {
                Skills skills = new Skills(levels,language,FIO,mail,richTextBox2.Text,richTextBox1.Text);
                skills.Show();
            }
            else
                MessageBox.Show("Check data!\n Experience and Education must be at least 100 symbols");
        }
    }
}
