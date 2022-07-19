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
using iText;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Resume___JSON_to_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // serach button
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            string FilePath = Application.StartupPath + txtSearch.Text;

            if (File.Exists(FilePath))
            {
                MessageBox.Show("File found!");
                DisplayPreview(FilePath);
                bttnSearch.Enabled = false;
            }
            else
            {
                MessageBox.Show("File not found!");
            }
        }
        // clearbutotn
        private void bttnClear_Click(object sender, EventArgs e)
        {
            Preview.Clear();
            txtSearch.Clear();
            bttnSearch.Enabled = true;
        }
        /// save buttton
        private void bttnSave_Click(object sender, EventArgs e)
        {
            
        }

        // normal arial 12
        public void AppendThis(string text)
        {
            Preview.SelectionFont = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            Preview.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            Preview.AppendText(text);
            Preview.AppendText("\n");
            Preview.ScrollToCaret();
        }
        // custom
        public void AppendThis(string text, string font, float size, FontStyle style, string align)
        {
            if (align == "center")
            {
                Preview.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            }
            else if (align == "right")
            {
                Preview.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            }
            else if (align == "left")
            {
                Preview.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            }
            Preview.SelectionFont = new System.Drawing.Font(font, size, style);
            Preview.AppendText(text);
            Preview.AppendText("\n");
            Preview.ScrollToCaret();
        }
        // preview method
        public void DisplayPreview(string path)
        {
            // deserialized
            string jsonfile = File.ReadAllText(path);
            Root MyResume = JsonConvert.DeserializeObject<Root>(jsonfile);

            // writer
            using()
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
            public string? summary { get; set; }
            public List<string>? highlights { get; set; }
        }


    }
}