namespace Resume___JSON_to_PDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnSearch = new System.Windows.Forms.Button();
            this.bttnSave = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1000, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // txtInputName
            // 
            this.txtInputName.Location = new System.Drawing.Point(10, 50);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Size = new System.Drawing.Size(290, 31);
            this.txtInputName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input Json File name";
            // 
            // bttnSearch
            // 
            this.bttnSearch.Location = new System.Drawing.Point(10, 90);
            this.bttnSearch.Name = "bttnSearch";
            this.bttnSearch.Size = new System.Drawing.Size(112, 34);
            this.bttnSearch.TabIndex = 2;
            this.bttnSearch.Text = "Search";
            this.bttnSearch.UseVisualStyleBackColor = true;
            this.bttnSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // bttnSave
            // 
            this.bttnSave.Location = new System.Drawing.Point(190, 600);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(112, 34);
            this.bttnSave.TabIndex = 4;
            this.bttnSave.Text = "Save";
            this.bttnSave.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(110, 180);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(112, 34);
            this.test.TabIndex = 5;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(320, 10);
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Size = new System.Drawing.Size(930, 650);
            this.Preview.TabIndex = 6;
            this.Preview.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.test);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.bttnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInputName);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private TextBox txtInputName;
        private Label label2;
        private Button bttnSearch;
        private Button bttnSave;
        private Button test;
        private RichTextBox Preview;
    }
}