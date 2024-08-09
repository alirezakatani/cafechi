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
        int food_id = 0;
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
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
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

            newsq.sql = "select orders_item.order_item_id from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.id=" + comboBox1.Text + " and payment.customer_id=" + cust.customer_id.ToString();
            newsq.setcon();
            while (newsq.reader.Read())
            {
                comboBox2.Items.Add(newsq.reader.GetInt32(0));


            }

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                sqlcon newsq = new sqlcon();
                newsq.sql = "select food_id,food.score,payment.rest_name from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) inner join food on ( food.id=orders_item.food_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.id=" + comboBox1.Text + " and payment.customer_id=" + cust.customer_id.ToString() + " and orders_item.order_item_id=" + comboBox2.Text;
                newsq.setcon();

                feed_back nfeed = new feed_back();
                nfeed.customer_id = cust.customer_id;
                newsq.reader.Read();
                nfeed.food_id = newsq.reader.GetInt32(0);
                nfeed.orders_id = Convert.ToInt32(comboBox1.Text);
                nfeed.score = Convert.ToInt32(textBox2.Text);
                nfeed.feed = textBox1.Text;
                nfeed.rest_name = newsq.reader.GetString(2);
                nfeed.time = DateTime.Now;
                int food_final_score = (newsq.reader.GetInt32(1) + Convert.ToInt32(textBox2.Text))/2;


                newsq.sql = "insert into rest_manager.dbo.feed_back values(" + nfeed.customer_id + "," + nfeed.orders_id + "," + nfeed.food_id + ",'" + nfeed.feed + "','" +
                    nfeed.rest_name + "'," + nfeed.score + ",'" + nfeed.getdate() + "')";
                newsq.setcon();
                newsq.sql = "update food set score=" + food_final_score + " where food.id=" + nfeed.food_id;
                newsq.setcon();
                MessageBox.Show("بازخورد با موفقیت ثبت شد", "ثبت بازخورد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("بازخورد با شکست مواجه شد", "ثبت بازخورد", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }





        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) left join feed_back on ( orders_item.food_id=feed_back.food_id) where payment.time='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and payment.id=" + comboBox1.Text + " and payment.customer_id=" + cust.customer_id.ToString() + " and orders_item.order_item_id=" + comboBox2.Text;
            newsq.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            index = comboBox1.SelectedIndex;
            dataGridView1.DataSource = newsq.ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlcon newsq = new sqlcon();
            newsq.sql = "select feed_back.food_id from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) left join feed_back on ( orders_item.food_id=feed_back.food_id) where orders_item.order_item_id=" + comboBox2.Text;
            newsq.setcon();
            try
                {
                newsq.reader.Read();
                food_id = newsq.reader.GetInt32(0);
                newsq.sql = "select * from payment inner join orders_item on ( payment.orders_id=orders_item.order_id) left join feed_back on ( orders_item.food_id=feed_back.food_id) where orders_item.food_id=" + food_id.ToString();

                newsq.setdata_adaptor();

                dataGridView1.ReadOnly = true;
                index = comboBox1.SelectedIndex;
                dataGridView1.DataSource = newsq.ds.Tables[0];

            }
           
            catch

            {
                MessageBox.Show("بازخورد با شکست مواجه شد", "ثبت بازخورد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
