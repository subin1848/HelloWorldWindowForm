using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWindowForm
{
    public partial class FormMain: Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "쾅!";
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 헬로월드정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAbout1 = new FormAbout();
            formAbout1.Text = "모달창";
            formAbout1.ShowDialog();
            Form formAbout2 = new Form();
            formAbout2.Text = "모달리스창(Medeless)";
            formAbout2.Show();
        }
        private void 열기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 파일(*.txt)|*.txt";
            DialogResult result = openFileDialog.ShowDialog();
            switch(result)
            {
                case DialogResult.OK:
                    //textBox1.Text = openFileDialog.FileName;
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }
                        break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소되었습니다.");
                    break;
            }
        }
    }
}
