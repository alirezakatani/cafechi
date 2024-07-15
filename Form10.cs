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
    public partial class Form10 : Form
    {
        Person pers;
        public Form10(Person per)
        {
            InitializeComponent();
            pers = per;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlcon ns = new sqlcon();
            ns.sql="insert into rolej values('"+textBox1.Text+"',"+textBox6.Text+",'"+textBox7.Text+"','"+pers.rest_name+"')";
            ns.setcon();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
