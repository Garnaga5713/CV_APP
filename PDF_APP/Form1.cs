using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace PDF_APP
{
    public partial class Form1 : Form
    {
        public string FIO, Contacts, Education, Experience,Position;
        public bool bool_finish = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Language";
            label2.Text = "FIO";
            label3.Text = "Email";
            label4.Text = "Education";
            label5.Text = "Experience";
            label6.Text = "Level";
            LoadCombo();
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
        void LoadCombo()
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Items.Add("C#/.net");
            comboBox1.Items.Add("Java");
            comboBox1.Items.Add("Python");
            comboBox1.Items.Add("QA");
            comboBox1.Items.Add("C++");

            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.Items.Add("Intern/Trainee");
            comboBox2.Items.Add("Junior");
            comboBox2.Items.Add("Middle");
            comboBox2.Items.Add("Senior");
            
        }

        void ReadData() 
        {
            
            if ((comboBox1.Text != "") && (comboBox2.Text != "") && (IsValidEmail(textBox3.Text)) && (textBox4.Text != "") && (textBox5.Text != "") ) 
            {
                Position =  comboBox2.Text+" "+comboBox1.Text;
                FIO = textBox2.Text;
                Contacts =  textBox3.Text;
                Education =  textBox4.Text;
                Experience =  textBox5.Text ;
                bool_finish = true;

            }

        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(Position).Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("FIO: "+FIO).SemiBold();
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Email: "+Contacts).SemiBold();
                       
                    });
                });

               // row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(IContainer container)
        {
            container
                .PaddingVertical(40)
                .Height(250)
                .Background(Colors.Grey.Lighten3)
                .AlignCenter()
                .AlignMiddle()
                .Text("Content").FontSize(16);
        }



        private void button1_Click(object sender, EventArgs e)
        {

            ReadData();

            if (bool_finish)
            {

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(50);

                        page.Header().Element(ComposeHeader);
                        page.Content().Element(ComposeContent);



                    });
                })
            .GeneratePdf("hello.pdf");
                MessageBox.Show("Sucess");

                string filename = @"C:\Users\Lenovo\OneDrive\Робочий стіл\HYS Hackaton\PDF_APP\PDF_APP\bin\Debug\hello.pdf";

                Process.Start(filename);
            }
            else 
            {
                MessageBox.Show("Check data");
            }
            


        }

    }
}
