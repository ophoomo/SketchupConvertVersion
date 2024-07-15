namespace SketchupConvertVersion
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            progressBar1 = new ProgressBar();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 122);
            button1.Name = "button1";
            button1.Size = new Size(320, 41);
            button1.TabIndex = 0;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Sketchup 3", "Sketchup 4", "Sketchup 5", "Sketchup 6", "Sketchup 7", "Sketchup 8", "Sketchup 2013", "Sketchup 2014", "Sketchup 2015", "Sketchup 2016", "Sketchup 2017", "Sketchup 2018", "Sketchup 2019", "Sketchup 2020", "Sketchup 2021", "Sketchup 2022" });
            comboBox1.Location = new Point(12, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(320, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Version";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Directory ";
            // 
            // button2
            // 
            button2.Location = new Point(12, 83);
            button2.Name = "button2";
            button2.Size = new Size(320, 33);
            button2.TabIndex = 4;
            button2.Text = "Browse Folder";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 213);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(320, 23);
            progressBar1.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(12, 169);
            button3.Name = "button3";
            button3.Size = new Size(320, 38);
            button3.TabIndex = 6;
            button3.Text = "Single File";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(344, 245);
            Controls.Add(button3);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SketchupConvertVersion";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Button button2;
        private FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar progressBar1;
        private Button button3;
        private OpenFileDialog openFileDialog1;
    }
}
