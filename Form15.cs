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
    public partial class Form15 : Form
    {
        customer cust;
        int x = 0;
        int index = 0;
        public Form15(customer cus)
        {
            InitializeComponent();
            cust = cus;

            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment  where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd")+"' and payment.customer_id="+cust.customer_id.ToString();
            newsq.setcon();
            while (newsq.reader.Read())
            {
                comboBox1.Items.Add(newsq.reader.GetInt32(0));
                x += 1;


            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.customer_id=" + cust.customer_id.ToString();
            newsq.setcon();
            while (newsq.reader.Read())
            {
                comboBox1.Items.Add(newsq.reader.GetInt32(0));


            }

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd")+"' and payment.id="+comboBox1.Text + " and payment.customer_id=" + cust.customer_id.ToString();
            newsq.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            index = comboBox1.SelectedIndex;
            dataGridView1.DataSource = newsq.ds.Tables[0];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(index<x-1)
            {
                index += 1;
                //sqlcon newsq = new sqlcon();
                //newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.id=" + index.ToString() + " and payment.customer_id=" + cust.customer_id.ToString();
                //newsq.setdata_adaptor();

                //dataGridView1.ReadOnly = true;
                //index = comboBox1.SelectedIndex;
                comboBox1.SelectedIndex = index;
                //dataGridView1.DataSource = newsq.ds.Tables[0];
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(index>0)
            {
                index -= 1;
                comboBox1.SelectedIndex = index;

            }


        }
    }
}
