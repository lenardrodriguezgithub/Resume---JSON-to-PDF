using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using iText;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Resume___JSON_to_PDF
{
    public partial class Form1 : Form
    {
        public string? json { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bttnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // open JSON file
            ofd.InitialDirectory = "c:\\";
            ofd.Title = "Open a JSON File.";
            ofd.Filter = "All Files(*.*) | *.*";
            DialogResult dr = ofd.ShowDialog();
            json = File.ReadAllText(ofd.FileName);
            txtFileName.Text = ofd.SafeFileName;
            rtbPreview.Text = json;
            bttnOpen.Enabled = false;

        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Root MyResume = JsonConvert.DeserializeObject<Root>(json);
                SaveFileDialog sfdlg = new SaveFileDialog();
                sfdlg.InitialDirectory = "c:\\";
                sfdlg.Title = "Save your resume.";
                sfdlg.Filter = "PDF Files (*.PDF) | *.PDF";
                if (sfdlg.ShowDialog() == DialogResult.OK)
                {
                    using (PdfWriter writer = new PdfWriter(sfdlg.FileName))
                    using (PdfDocument pdfDoc = new PdfDocument(writer))
                    using (Document document = new Document(pdfDoc))
                    {
                        LineSeparator ls = new LineSeparator(new SolidLine());

                        // name
                        Paragraph name = new Paragraph(MyResume.basics.name)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20).SetBold();
                        document.Add(name);
                        Paragraph title = new Paragraph(MyResume.basics.title)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(15);
                        document.Add(title);

                        // about
                        Paragraph about = new Paragraph("ABOUT")
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(15);
                        document.Add(about);
                        
                        document.Add(ls);
                        Paragraph aboutSummary = new Paragraph(MyResume.about.summary)
                           .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12); 
                        document.Add(aboutSummary);

                        // work experience
                        Paragraph work = new Paragraph("WORK EXPERIENCE")
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(15);
                        document.Add(work);
                        document.Add(ls);
                        Paragraph workExp = new Paragraph(MyResume.work.position + 
                            " | " +
                            MyResume.work.company)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                        document.Add(workExp);
                        Paragraph workDate = new Paragraph(MyResume.work.startDate +
                            " to " +
                            MyResume.work.endDate)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                        document.Add(workDate);

                        foreach(var h in MyResume.work.highlights)
                        {
                            Paragraph workhighlight = new Paragraph(h)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                            document.Add(workhighlight);
                        }

                        // education
                        Paragraph educ = new Paragraph("EDUCATION")
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(15);
                        document.Add(work);
                        document.Add(ls);

                        Paragraph educArea = new Paragraph(MyResume.education.area +
                            " | " +
                            MyResume.education.studyType)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                        document.Add(educArea);
                        Paragraph educInst = new Paragraph(MyResume.education.institution)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                        Paragraph educDate = new Paragraph(MyResume.education.startDate +
                            " to " +
                            MyResume.education.endDate)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(12);
                        document.Add(educDate);

                    }

                }
            }
            catch
            {
                MessageBox.Show("An error occured!", "Error Message");
            }
            
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            rtbPreview.Clear();
            bttnOpen.Enabled = true;
            txtFileName.Clear();
        }

    }

    public class About
    {
        public string? summary { get; set; }
    }

    public class Basics
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? title { get; set; }
        public string? website { get; set; }
        public Location? location { get; set; }
    }

    public class Education
    {
        public string? institution { get; set; }
        public string? area { get; set; }
        public string? studyType { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
    }

    public class Location
    {
        public string? address { get; set; }
        public string? postalCode { get; set; }
        public string? city { get; set; }
        public string? countryCode { get; set; }
        public string? region { get; set; }
    }

    public class Root
    {
        public About? about { get; set; }
        public Basics? basics { get; set; }
        public Work? work { get; set; }
        public Education? education { get; set; }
        public List<Skill>? skills { get; set; }
    }

    public class Skill
    {
        public string? name { get; set; }
        public string? level { get; set; }
        public List<string>? keywords { get; set; }
    }

    public class Work
    {
        public string? company { get; set; }
        public string? position { get; set; }
        public string? website { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string ?summary { get; set; }
        public List<string>? highlights { get; set; }
    }


}