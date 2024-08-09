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
    public partial class Form12 : Form
    {
        Boolean status;
        customer customer;
        public Form12(customer cus)
        {
            InitializeComponent();
            customer = cus;

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                panel2.Visible = true;
                status = true;
            }
            else
            {
                panel2.Visible = false;
                status = false;
            }
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.Visible = false;
            status = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label3.Text = Convert.ToString(DateTime.Now);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 newship = new Form13(customer);
            newship.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 seeship = new Form15(customer);
            seeship.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form15 seeship = new Form15(customer);
            seeship.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 newship = new Form13(customer);
            newship.ShowDialog();
        }
    }
}
