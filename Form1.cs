using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics;


namespace De4dot_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2ComboBox1.Items.Add("x32");
            guna2ComboBox1.Items.Add("x64");
            guna2ComboBox1.SelectedIndex = 1;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Exe Files (*.exe)|*.exe";
            opf.Multiselect = false;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox1.Text = opf.FileName;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.FileName = "cmd.exe";
                psi.Arguments = $"/c de4dot.exe {guna2TextBox1.Text}";
                psi.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();
                string logbox = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                guna2TextBox2.Clear();
                guna2TextBox2.Text = logbox;
                process.Dispose();
            }
            else
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.FileName = "cmd.exe";
                psi.Arguments = $"/c de4dot-x64.exe {guna2TextBox1.Text}";
                psi.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();
                string logbox = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                guna2TextBox2.Clear();
                guna2TextBox2.Text = logbox;
                process.Dispose();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("De4dot gui by Keevo\nDiscord: j.r7\nGithub: https://github.com/keevodev");
        }
    }
}
