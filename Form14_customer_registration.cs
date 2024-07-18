using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form14_customer_registration : Form
    {
        public Form14_customer_registration()
        {
            InitializeComponent();
        }

        private void Form14_customer_registration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();

            newsq.sql = "insert into rest_manager.dbo.customer values('" + textBox1.Text + "','" + textBox2.Text + "','" +textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            newsq.setcon();
            MessageBox.Show("Dear " + textBox1.Text + " you registred successfuly", "sign in", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Hide();
            Form11 newlogin = new Form11();
            newlogin.ShowDialog();



        }
    }
}
