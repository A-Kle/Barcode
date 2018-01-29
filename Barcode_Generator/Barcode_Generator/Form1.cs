using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Barcode_Generator
{
    enum code_options{ none = 0, test = 1, rainbow_colors = 2 };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control = new Control();
            string barcode = textBox1.Text;
            maskedTextBox1.Clear();
            Bitmap bmp;
            if (barcode.Length < 1)
            {
                maskedTextBox1.Visible = true;
                maskedTextBox1.AppendText("Please enter atleast one character.");
            }
            else
            {
                if(checkBox1.Checked == true)
                {
                    bmp = Barcode.DrawBarcode(barcode, code_options.rainbow_colors);
                }
                else
                {
                    bmp = Barcode.DrawBarcode(barcode, code_options.none);
                }
                pictureBox1.Image = bmp;
                this.Size = new Size(Math.Max(bmp.Size.Width + pictureBox1.Location.X * 2, 540), this.Size.Height); 
                pictureBox1.Size = bmp.Size;
                button2.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.MaxLength = 13;
            int code_length = textBox1.TextLength;
            maskedTextBox2.Visible = true;
            maskedTextBox2.Text = "Input length: " + code_length.ToString();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if(saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length-4, 4) != ".png")
                {
                    saveFileDialog1.FileName += ".png";
                }
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                pictureBox1.Image.Save(fs, ImageFormat.Png);
                fs.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox1.Image = null;
            button2.Enabled = false;
            checkBox1.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
