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
        private const string FILE_DEFAULT_NAME = "제목 없음";
        private const string TEXTBOX_DEFAUIT_TEXT = "입력하세요.";
        private const string FILENAME_FILTER = "텍스트 파일(*.txt)|*.txt";
        private const string FILE_MODIFY_SYMBOL = "*";
        private string ORIGINAL_FILE_CONTENT = "";

        public FormMain()
        {
            InitializeComponent();
            lblFileName.Text = FILE_DEFAULT_NAME;
            textBox1.Text = TEXTBOX_DEFAUIT_TEXT;
            ORIGINAL_FILE_CONTENT = textBox1.Text;
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
            openFileDialog.Filter = FILENAME_FILTER;
            DialogResult result = openFileDialog.ShowDialog();
            switch(result)
            {
                case DialogResult.OK:
                    lblFileName.Text = openFileDialog.FileName;
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                        lblModify.Text = "";
                        ORIGINAL_FILE_CONTENT = textBox1.Text;

                    }
                    fileStream.Close();
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소되었습니다.");
                    break;
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lblFileName.Text == FILE_DEFAULT_NAME)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = FILENAME_FILTER;
                DialogResult result = saveFileDialog.ShowDialog();

                if(result == DialogResult.Cancel)
                {
                    return;
                }    
                lblFileName.Text = saveFileDialog.FileName;
            }

            var fileStream = new FileStream(lblFileName.Text, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(textBox1.Text);
                //writer.WirteLine(textBox1.Text);
                writer.Close();
                lblModify.Text = "";
                ORIGINAL_FILE_CONTENT = textBox1.Text;
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FILENAME_FILTER;
            saveFileDialog.FileName = lblFileName.Text;
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }
            lblFileName.Text = saveFileDialog.FileName;
         
            var fileStream = new FileStream(lblFileName.Text, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(textBox1.Text);
                //writer.WirteLine(textBox1.Text);
                writer.Close();
                lblModify.Text = "";
                ORIGINAL_FILE_CONTENT = textBox1.Text;
            }
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 이터널코드, 매직넘버 최소화, 상수로 빼서 해야함
            textBox1.Text = TEXTBOX_DEFAUIT_TEXT;
            lblFileName.Text = FILE_DEFAULT_NAME;
            lblModify.Text = "";

        }

        private void lblModify_TextChanged(object sender, EventArgs e){ }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != ORIGINAL_FILE_CONTENT)
            {
                lblModify.Text = FILE_MODIFY_SYMBOL;
            }
            else
            {
                lblModify.Text = "";
            }
        }
    }
}
