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
    public partial class Form3 : Form
    {
        Person pers;
        Boolean status;
        public Form3(Person person)
        {
            InitializeComponent();
           
          
            pers = person;
            status = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5(pers);
            fr5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6(pers);
            fr6.Show();
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
           panel2.Visible = false;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.Visible = false;
            status = false;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(status==false)
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

        private void button8_MouseEnter_1(object sender, EventArgs e)
        {


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {


        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label3.Text = Convert.ToString( DateTime.Now);


        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7(pers);
            fr7.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10(pers);
            fr10.Show();

        }
    }
}
