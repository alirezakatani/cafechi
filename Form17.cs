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
    public partial class Form17 : Form
    {
        int x = 0;
        int index = 0;
        Person pers;
        public Form17(Person per)
        {
            InitializeComponent();
            pers = per;

            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment  where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.rest_name='" + pers.rest_name + "'";
            newsq.setcon();
            while (newsq.reader.Read())
            {
                comboBox1.Items.Add(newsq.reader.GetInt32(9));
                x += 1;


            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Console.Write(dateTimePicker1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from rest_manager.dbo.payment where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.rest_name='" + pers.rest_name + "'";
            newsq.setcon();
            while (newsq.reader.Read())
            {
                comboBox1.Items.Add(newsq.reader.GetInt32(9));


            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.orders_id=" + comboBox1.Text + " and payment.rest_name='" + pers.rest_name + "'";
            newsq.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            index = comboBox1.SelectedIndex;
            dataGridView1.DataSource = newsq.ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "update payment set status='" + textBox1.Text + "'";
            newsq.setcon();
            newsq.sql = "update orders_item set status='" + textBox1.Text + "' where order_id="+comboBox1.Text;
            newsq.setcon();
            newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.orders_id=" + comboBox1.Text + " and payment.rest_name='" + pers.rest_name + "'";
            newsq.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            index = comboBox1.SelectedIndex;
            dataGridView1.DataSource = newsq.ds.Tables[0];
            MessageBox.Show("تغییر وضعیت تراکنش با موفقیت صورت گرفت", "تغییر وضعیت تراکنش", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (index < x - 1)
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
            if (index > 0)
            {
                index -= 1;
                comboBox1.SelectedIndex = index;

            }
        }
    }
}
