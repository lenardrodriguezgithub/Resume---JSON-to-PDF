using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Resume___JSON_to_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            string FilePath = Application.StartupPath + txtSearch.Text;

            if (File.Exists(FilePath))
            {
                // MessageBox.Show("File found!");
                DisplayPreview(FilePath);
                bttnSearch.Enabled = false;
            }
            else
            {
                MessageBox.Show("File not found!");
            }
        }

        public void DisplayPreview(string path)
        {
            string jsonfile = File.ReadAllText(path);
            Root MyResume = JsonConvert.DeserializeObject<Root>(jsonfile);
            AppendThis(MyResume.basics.name, "Arial", 20, FontStyle.Bold, "center");
            AppendThis(MyResume.basics.title, "Arial", 12, FontStyle.Regular, "center");

            AppendThis("");
            AppendThis("ABOUT", "Arial", 14, FontStyle.Bold, "center");
            AppendThis(MyResume.about.summary);

            AppendThis("");
            AppendThis("INFORMATION", "Arial", 14, FontStyle.Bold, "center");

            AppendThis("");
            AppendThis("Contact");
            AppendThis(MyResume.basics.email);
            AppendThis(MyResume.basics.phone);
            AppendThis(MyResume.basics.website);

            AppendThis("");
            AppendThis("Address");
            AppendThis(MyResume.basics.location.address + ", " + MyResume.basics.location.city + ", " +
                MyResume.basics.location.postalCode + ", " +
                MyResume.basics.location.region + ", " + MyResume.basics.location.countryCode);

            AppendThis("");
            AppendThis("WORK EXPERIENCE", "Arial", 14, FontStyle.Bold, "center");
            AppendThis(MyResume.work.company + " | " +
                MyResume.work.startDate + " to " + MyResume.work.endDate);
            AppendThis(MyResume.work.position);
            AppendThis(MyResume.work.website);
            AppendThis(MyResume.work.summary);
            AppendThis(MyResume.work.highlights[0]);
            AppendThis(MyResume.work.highlights[1]);
            AppendThis(MyResume.work.highlights[2]);

            AppendThis("");
            AppendThis("EDUCATION", "Arial", 14, FontStyle.Bold, "center");
            AppendThis(MyResume.education.institution + " | " +
                MyResume.education.startDate + " to " + MyResume.education.endDate);
            AppendThis(MyResume.education.area);
            AppendThis(MyResume.education.studyType);

            AppendThis("");
            AppendThis("SKILLS", "Arial", 14, FontStyle.Bold, "center");
            
            foreach(var s in MyResume.skills)
            {
                AppendThis(s.name);
                AppendThis(s.level);
                foreach(var l in s.keywords)
                {
                    AppendThis(l);
                }
            }
        }

        /* PRETIFY PREVIEWWWWW
            SAVE TO PDFFFFF
         */
        private void bttnClear_Click(object sender, EventArgs e)
        {
            Preview.Clear();
            txtSearch.Clear();
            bttnSearch.Enabled = true;
        }
        /// save buttton
        private void bttnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            DialogResult messageResult = MessageBox.Show("Save this file into PDF?", "PDF File", MessageBoxButtons.OKCancel);

            if (messageResult == DialogResult.Cancel)
            {
                MessageBox.Show("Operation Canceled By User", "PDF File");
            }
            else
            {
                sfd.Title = "Save As PDF";
                sfd.Filter = "(*.pdf)|*.pdf";
                sfd.InitialDirectory = @"C:\";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (Preview.Text != "")
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();
                        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(Preview.Text));
                        doc.Close();
                        Preview.Text = "";
                        MessageBox.Show("PDF Saved Succesfully", "PDF File");
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Your Text", "PDF File",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    }

                }

            }


        }



        // normal arial 12
        public void AppendThis(string text)
        {
            Preview.SelectionFont = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            Preview.SelectionAlignment = HorizontalAlignment.Left;
            Preview.AppendText(text);
            Preview.AppendText("\n");
            Preview.ScrollToCaret();
        }
        // custom
        public void AppendThis(string text, string font, float size, FontStyle style, string align)
        {
            if (align == "center")
            {
                Preview.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (align == "right")
            {
                Preview.SelectionAlignment = HorizontalAlignment.Right;
            }
            else if (align == "left")
            {
                Preview.SelectionAlignment = HorizontalAlignment.Left;
            }
            Preview.SelectionFont = new System.Drawing.Font(font, size, style);
            Preview.AppendText(text);
            Preview.AppendText("\n");
            Preview.ScrollToCaret();

        }

        // classes
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

        public class FullName
        {
            public string? first { get; set; }
            public string? last { get; set; }
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
            public FullName? fullName { get; set; }
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
            public string? summary { get; set; }
            public List<string>? highlights { get; set; }
        }


    }
}