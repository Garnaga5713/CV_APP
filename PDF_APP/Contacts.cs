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
    public partial class Contacts : Form
    {
        string levels, language;
        bool bl_conti=false;
        public Contacts(string level,string lang)
        {

            InitializeComponent();
            levels = level;
            language = lang;
            label3.Text = "FIO";
            label4.Text = "Email";
            button2.Text = "Next";
            textBox3.Text = "Petrov A. M.";
            textBox4.Text = "petrov@gmail.com";
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            bl_conti = IsValidEmail(textBox4.Text);
            if (bl_conti != true||(textBox3.Text==""&&textBox4.Text==""))
            {
                MessageBox.Show("Check data");
            }
            else
            {
                Educ_Expi educ_Expi = new Educ_Expi(levels,language,textBox3.Text,textBox4.Text);
                educ_Expi.Show();
            }
        }

     
    }
}
