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
using SkiaSharp;
using System.Net;

namespace PDF_APP
{
    public partial class Form1 : Form
    {
        public string FIO, Contacts, Education, Experience,Position;
        public bool bool_finish = false;

        string level, lang, fio, mai, educ, exper, eng, skill;


        public Form1(string level, string lang, string fio, string mai, string educ, string exper, string eng, string skill)
        {
            this.level = level;
            this.lang = lang;
            this.fio = fio;
            this.mai = mai;
            this.educ = educ;
            this.exper = exper;
            this.eng = eng;
            this.skill = skill;
            
            InitializeComponent();
            button1.Text=button2.Text = "Create";
            Position = level +" "+ lang;
            WindowState = FormWindowState.Maximized;
            pictureBox1.Image = Image.FromFile("version1.png");
            pictureBox2.Image = Image.FromFile("version2.png");
            pictureBox1.SizeMode= PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


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
                        text.Span("FIO: "+fio).SemiBold();
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Email: "+mai).SemiBold();
                       
                    });

                });

             

            });
        }

        void ComposeContent(IContainer container)
        {
            //container
            //    .PaddingVertical(40)
            //    .Height(250)
            //    .Background(Colors.Grey.Lighten3)
            //    .AlignCenter()
            //    .AlignMiddle()
            //    .Text("Content").FontSize(16);

            //container.Row(row=>row.RelativeItem().Column(column=>column.Item().Text("\n\n\n")));





            container.Row(row =>
            {


                row.RelativeItem().Column(column =>
                {

                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\nEducation: ").SemiBold();
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Red.Medium);


                    });

                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\n\nExperience:").SemiBold();
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Red.Medium);


                    });
                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\n\nEnglish:").SemiBold();
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Red.Medium);


                    });
                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\n\nSkiils:").SemiBold();
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Red.Medium);


                    });

                });

                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n" + educ + " \n\n\n\n" + exper + " \n\n\n\n\n" + eng + " \n\n\n\n\n\n" + skill).SemiBold();

                    });
                });

            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var document = Document.Create(container =>
                  {
                      container.Page(page =>
                      {
                          page.Margin(50);

                          page.Header().Element(ComposeHeader);
                          page.Content().Element(ComposeContent);

                      });
                  });

            document.GeneratePdf("hello.pdf");

            MessageBox.Show("Sucess");

                string filename = @"C:\Users\Lenovo\OneDrive\Робочий стіл\HYS Hackaton\PDF_APP\PDF_APP\bin\Debug\hello.pdf";

                Process.Start(filename);
        }


        void ComposeHeader1(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(30).SemiBold().FontColor(Colors.Orange.Medium);
            var posStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Darken2);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().AlignCenter().Text(fio).Style(titleStyle);
                    column.Item().AlignCenter().Text(Position).Style(posStyle);


                });



            });
        }

        void ComposeContent1(IContainer container)
        {
            //container
            //    .PaddingVertical(40)
            //    .Height(250)
            //    .Background(Colors.Grey.Lighten3)
            //    .AlignCenter()
            //    .AlignMiddle()
            //    .Text("Content").FontSize(16);

           




            container.Row(row =>
            {


                row.RelativeItem().Column(column =>
                {

                    column.Item().Text(text =>
                    {
                        text.Span("\n\nContacts").SemiBold().Style(TextStyle.Default.FontSize(15));
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Black);
                       
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Email: " + mai).SemiBold().Style(TextStyle.Default.FontSize(15));
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("\n\nEducation: ").SemiBold().Style(TextStyle.Default.FontSize(15));
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Cyan.Medium);
                        


                    });
                    column.Item().Text(text =>
                    {
                        text.Span(educ).SemiBold().Style(TextStyle.Default.FontSize(15));
                    });


                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\n\nSkiils:").SemiBold().Style(TextStyle.Default.FontSize(15));
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Red.Medium);
                        

                    });
                    column.Item().Text(text =>
                    {
                        text.Span(skill).SemiBold().Style(TextStyle.Default.FontSize(15));
                    });

                });

                row.RelativeItem().Column(column =>
                {

                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\n\n\nExperience:").SemiBold().Style(TextStyle.Default.FontSize(15));
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Lime.Medium);
                       

                    });
                    column.Item().Text(text =>
                    {
                        text.Span(exper).SemiBold().Style(TextStyle.Default.FontSize(15));
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("\n\n\n\nEnglish:").SemiBold().Style(TextStyle.Default.FontSize(15));
                        column.Item().MaxWidth(100).LineHorizontal(1).LineColor(Colors.Amber.Medium);
                        

                    });
                    column.Item().Text(text =>
                    {
                        text.Span(eng).SemiBold().Style(TextStyle.Default.FontSize(15));
                    });

                });

            });
        }




        private void button2_Click(object sender, EventArgs e)
        {

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader1);
                    page.Content().Element(ComposeContent1);



                });
            });

            document.GeneratePdf("hello.pdf");

            string filename = @"C:\Users\Lenovo\OneDrive\Робочий стіл\HYS Hackaton\PDF_APP\PDF_APP\bin\Debug\hello.pdf";

            Process.Start(filename);

        }


    }
}
