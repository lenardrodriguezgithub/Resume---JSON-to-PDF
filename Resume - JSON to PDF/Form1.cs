using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

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
            string FilePath = Application.StartupPath + txtInputName.Text;

            if(File.Exists(FilePath))
            {
                MessageBox.Show("File found!");
                DisplayPreview(FilePath);
            }
            else
            {
                MessageBox.Show("File not found!");
            }
        }

        private void test_Click(object sender, EventArgs e)
        {

        }

        public void DisplayPreview(string path)
        {
            string jsonfile = File.ReadAllText(path);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonfile);
            AppendThis(myDeserializedClass.basics.name);
            AppendThis(myDeserializedClass.basics.email);
        }

        public void AppendThis(string text)
        {
            Output.AppendText(text);
            Output.AppendText("\n");
            Output.ScrollToCaret();
        }
    }

    public class Basics
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? degree { get; set; }
        public string? website { get; set; }
        public Location? location { get; set; }
        public List<Profile>? profiles { get; set; }
    }

    public class Education
    {
        public string? institution { get; set; }
        public string? area { get; set; }
        public string? studyType { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? gpa { get; set; }
        public List<string>? courses { get; set; }
    }

    public class Interest
    {
        public string? name { get; set; }
        public List<string>? keywords { get; set; }
    }

    public class Language
    {
        public string? language { get; set; }
        public string? fluency { get; set; }
    }

    public class Location
    {
        public string? address { get; set; }
        public string? postalCode { get; set; }
        public string? city { get; set; }
        public string? countryCode { get; set; }
        public string? region { get; set; }
    }

    public class Profile
    {
        public string? network { get; set; }
        public string? username { get; set; }
        public string? url { get; set; }
    }

    public class Root
    {
        public Basics? basics { get; set; }
        public List<Work>? work { get; set; }
        public List<Education>? education { get; set; }
        public List<Skill>? skills { get; set; }
        public List<Language>? languages { get; set; }
        public List<Interest>? interests { get; set; }
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