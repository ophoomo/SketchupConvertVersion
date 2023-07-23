using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinRT;

namespace SketchupConvertVersion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.button1.Enabled = false;
            if (this.check_input())
            {
                if (!checkBox1.Checked)
                {
                    Properties.Settings.Default.username = null;
                    Properties.Settings.Default.password = null;
                    Properties.Settings.Default.Save();
                }
                Task task = this.login();
            }
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.button1.Enabled = true;
        }

        private bool check_input()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username is not empty");
                return false;
            } else if (textBox2.Text.Length < 10)
            {
                MessageBox.Show("Password is more 10");
                return false;
            }
            return true;
        }

        class Response
        {
            public bool status { get; set; }
            public String message { get; set; }
        }
        
        private async Task login()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://authservice-e5sbdvvdzq-as.a.run.app");
            var pcname = Environment.GetEnvironmentVariable("COMPUTERNAME");
            var pcusername = Environment.GetEnvironmentVariable("USER");
            var data = new StringContent(JsonConvert.SerializeObject(new { username = textBox1.Text, password = textBox2.Text, pcname = pcname, pcusername = pcusername }),
                Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("/api/auth/sketchupconvertversion", data);
            var responseBody = result.Content.ReadAsStringAsync();
            if (((int)result.StatusCode) == 200)
            {
                Response res = JsonConvert.DeserializeObject<Response>(responseBody.Result);
                if (res.status)
                {
                    if (checkBox1.Checked)
                    {
                        Properties.Settings.Default.username = this.textBox1.Text;
                        Properties.Settings.Default.password = this.textBox2.Text;
                        Properties.Settings.Default.Save();
                    }
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                } else
                {
                    MessageBox.Show(res.message);
                }
            }
            else if ((int) result.StatusCode == 403)
            {
                MessageBox.Show("Username or Password incorrect");
            }
            else
            {
                MessageBox.Show("Can't Connect to Server");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            String username = Properties.Settings.Default.username;
            String password = Properties.Settings.Default.password;
            if (username != null && password != null)
            {
                textBox1.Text = username;
                textBox2.Text = password;
                checkBox1.Checked = true;
            }
        }
    }
}
