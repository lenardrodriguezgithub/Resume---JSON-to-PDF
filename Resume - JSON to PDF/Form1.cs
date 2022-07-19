using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
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
            txtFileName.Text = ofd.SafeFileName;
            Deserialize(ofd.FileName);
            bttnOpen.Enabled = false;
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {

        }

        private void bttnClear_Click(object sender, EventArgs e)
        {

        }

        public void Deserialize(string filename)
        {
            string jsonfile = File.ReadAllText(filename);
            Root MyResume = JsonConvert.DeserializeObject<Root>(jsonfile);

            // test
            rtbPreview.Text = MyResume.basics.name;
        }

        public void SaveAs(object resume)
        {

        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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