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
            Position = level +" "+ lang;
            
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
                        text.Span("\n\n\nEducation: " ).SemiBold();
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
                        text.Span("\n\n\n" + educ+ " \n\n\n\n\n\n" + exper + " \n\n\n\n\n\n" + eng + " \n\n\n\n\n\n" + skill).SemiBold();

                       });
                });

                });
        }



        private void button1_Click(object sender, EventArgs e)
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

    }
}
