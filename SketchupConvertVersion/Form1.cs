namespace SketchupConvertVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string version = System.Windows.Forms.Application.ProductVersion;
            this.Text = String.Format("SketchupConvertVersion {0}", version);
            comboBox1.SelectedIndex = 0;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.Text = folderBrowserDialog1.SelectedPath;
            }
            this.checkInput();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            progressBar1.Value = 0;
            int version = getVersion(comboBox1.Text);
            string dir = folderBrowserDialog1.SelectedPath + "\\" + version.ToString();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            SketchupAPI sketchup = new SketchupAPI(version, dir, folderBrowserDialog1.SelectedPath);
            if (sketchup.Convert(progressBar1))
            {
                System.Diagnostics.Process.Start("explorer.exe", @dir);
                MessageBox.Show("Convert Success");
            }
            else
            {
                Directory.Delete(dir);
            }
            comboBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            GC.Collect();
        }

        private int getVersion(String text)
        {
            return int.Parse(text.Split(' ')[1]);
        }

        private void checkInput()
        {
            if (comboBox1.SelectedIndex > -1 && folderBrowserDialog1.SelectedPath != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            progressBar1.Value = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int version = getVersion(comboBox1.Text);
                string file = openFileDialog1.FileName;
                SketchupAPI sketchup = new SketchupAPI(version, file, file);
                if (sketchup.convertSingel(progressBar1))
                {
                    MessageBox.Show("Convert Success");
                }
                else
                {
                    MessageBox.Show("Convert Error");
                }
                GC.Collect();
            }
            comboBox1.Enabled = true;
            if (folderBrowserDialog1.SelectedPath != "" && folderBrowserDialog1.SelectedPath != null)
            {
                button1.Enabled = true;
            }
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
