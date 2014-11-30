using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CaptchaTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private string code;

        private void Form1_Load(object sender, EventArgs e)
        {
            code = CreateCode.CreateRegionCode(5);
            pictureBox1.Image = CreateCode.Create(code);
        }

        private void labClear_Click(object sender, EventArgs e)
        {
            code = CreateCode.CreateRegionCode(5);
            pictureBox1.Image = CreateCode.Create(code);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCap.Text == code)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("—È÷§¬Î ‰»Î¥ÌŒÛ£°");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
