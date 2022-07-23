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
    public partial class Tech_Pos : Form
    {
        public Tech_Pos()
        {
            InitializeComponent();


             label1.Text = "Language";
             label2.Text = "Level";
            button1.Text = "Next";
            //default data
            comboBox1.Text = "C#/.net";
            comboBox3.Text = "Junior";

            LoadCombo();//  load data to combobox 


        }

        void LoadCombo()
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Items.Add("C#/.net");
            comboBox1.Items.Add("Java");
            comboBox1.Items.Add("Python");
            comboBox1.Items.Add("QA");
            comboBox1.Items.Add("C++");

            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.Items.Add("Intern/Trainee");
            comboBox3.Items.Add("Junior");
            comboBox3.Items.Add("Middle");
            comboBox3.Items.Add("Senior");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox3.Text != "")//check is all data was input
            {
                //create and go to next form
                Contacts contacts = new Contacts(comboBox1.Text,comboBox3.Text);
                contacts.Show();
            }
            else
                MessageBox.Show("Check data");
        }
    }
}
