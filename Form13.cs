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
    public partial class Form13 : Form
    {

        sqlcon find_food;
        food[] foods;
        int index = 0;
        int food_size = 0;
        food[] baseket_food;
        customer customer = new customer();
        int order_id;
        public Form13(customer cus)
        {
            InitializeComponent();
            customer = cus;




            sqlcon newsq = new sqlcon();
            newsq.sql = "select max(order_id) from rest_manager.dbo.orders";
            newsq.setcon();

            try
            {
                newsq.reader.Read();
                order_id = newsq.reader.GetInt32(0);
            }


            catch
            {
                order_id = 0;
            }




            order_id += 1;
            newsq.sql = "insert into rest_manager.dbo.orders values('" + customer.customer_id + "','" + customer.address + "','" + customer.phone_number + "',null,null)";
            newsq.setcon();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            list ml = new list();
            ml.list_date = dateTimePicker1.Value;
            sqlcon newsql = new sqlcon();
            newsql.sql = "select list_meal from rest_manager.dbo.list where list_date='" + ml.list_date.ToString("yyyy/MM/dd") + "'";
            newsql.setcon();


            while (newsql.reader.Read())
            {
                comboBox1.Items.Add(newsql.reader.GetString(0));


            }
            newsql.delcon();



            sqlcon newsq = new sqlcon();
//            newsq.sql = "insert into ";  add shop to orders - need build customer table first
            newsq.sql = "select max(order_id) as maxes from rest_manager.dbo.orders";
            newsq.setcon();
            newsq.reader.Read();
            order_id = newsq.reader.GetInt32(0);

        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            sqlcon newsql = new sqlcon();
            newsql.sql = "select list_name from rest_manager.dbo.list_match where list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and food_meal='" + comboBox1.Text + "'";
            newsql.setcon();


            while (newsql.reader.Read())
            {
                comboBox2.Items.Add(newsql.reader.GetString(0));


            }
            newsql.delcon();

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            sqlcon newsql = new sqlcon();
            newsql.sql = "select food.id,food.name,food.meal,food.kind,food.price,food.score,food.rest_name,food.time_prepare,list.list_name,list.list_date from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text + "'";
            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];


            int x;
            newsql.sql = "select count(*) from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text + "'";
            newsql.setcon();
            newsql.reader.Read();
            x = newsql.reader.GetInt32(0);
            newsql.delcon();
            sqlcon newsq = new sqlcon();
            newsq.sql = "select food.name,food.meal,food.kind,food.price,food.id,food.score,food.rest_name,food.time_prepare,food.image_path,list.list_name,list.list_date from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text + "'";
            newsq.setcon();
            foods = new food[x];
            food_size = x;

            for (int i = 0; i < x; i++)
            {
                food foo = new food();

                newsq.reader.Read();
                foo.name = newsq.reader.GetString(0);
                foo.meal = newsq.reader.GetString(1);
                foo.kind = newsq.reader.GetString(2);
                foo.price = newsq.reader.GetInt32(3);
                foo.id = newsq.reader.GetInt32(4);
                foo.time_prepare = newsq.reader.GetInt32(7);
                foo.image_path = newsq.reader.GetString(8);
                foo.score = newsq.reader.GetInt32(5);
                foo.rest_name = newsq.reader.GetString(6);
                foods[i] = foo;
                comboBox3.Items.Add(foods[i].rest_name);
            }

            textBox2.Text = foods[0].name;
            textBox3.Text = Convert.ToString(foods[0].id);
            textBox4.Text = Convert.ToString(foods[0].time_prepare);
            textBox5.Text = Convert.ToString(foods[0].price);
            String path = foods[0].image_path;
            Bitmap pic = new Bitmap(path);
            pictureBox1.Image = pic;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            index = 1;





            //while (newsql.reader.Read())
            //{
            //    comboBox1.Items.Add(newsql.reader.GetString(0));
            //    food_name.Add(newsql.reader.GetString(0));


            //}
            newsql.delcon();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index -= 1;
                textBox2.Text = foods[index].name;
                textBox3.Text = Convert.ToString(foods[index].id);
                textBox4.Text = Convert.ToString(foods[index].time_prepare);
                textBox5.Text = Convert.ToString(foods[index].price);
                String path = foods[index].image_path;
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show("به ابتدای لیست رسیده اید", "عدم وجود غذا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (index < food_size - 1)
            {
                index += 1;
                textBox2.Text = foods[index].name;
                textBox3.Text = Convert.ToString(foods[index].id);
                textBox4.Text = Convert.ToString(foods[index].time_prepare);
                textBox5.Text = Convert.ToString(foods[index].price);
                String path = foods[index].image_path;
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                MessageBox.Show("به انتهای این دسته از غذاها رسیده اید.", "عدم وجود غذا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            list ml = new list();
            ml.list_date = dateTimePicker1.Value;
            sqlcon newsql = new sqlcon();
            newsql.sql = "select food_meal from rest_manager.dbo.list_match where list_date='" + ml.list_date.ToString("yyyy/MM/dd") + "'";
            newsql.setcon();


            while (newsql.reader.Read())
            {
                comboBox1.Items.Add(newsql.reader.GetString(0));


            }
            newsql.delcon();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlcon newsql = new sqlcon();
            newsql.sql = "select food.id,food.name,food.meal,food.kind,food.price,food.score,food.rest_name,food.time_prepare,list.list_name,list.list_date from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text + "' and food.rest_name='"+comboBox3.Text+"'";
            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];


            int x;
            newsql.sql = "select count(*) from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text  +"' and food.rest_name='" + comboBox3.Text + "'";
            newsql.setcon();
            newsql.reader.Read();
            x = newsql.reader.GetInt32(0);
            newsql.delcon();
            sqlcon newsq = new sqlcon();
            newsq.sql = "select food.name,food.meal,food.kind,food.price,food.id,food.score,food.rest_name,food.time_prepare,food.image_path,list.list_name,list.list_date from rest_manager.dbo.list inner join  rest_manager.dbo.list_match on(list.list_name=list_match.list_name and list.list_meal=list_match.list_meal and list.list_date=list_match.list_date) inner join dbo.food on (list_match.food_name=food.name and list_match.food_meal=food.meal)  " + "where list.list_date='" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and list_match.food_meal='" + comboBox1.Text + "' and list.list_name='" + comboBox2.Text + "' and food.rest_name='"+comboBox3.Text+"'";
            newsq.setcon();
            foods = new food[x];
            food_size = x;

            for (int i = 0; i < x; i++)
            {
                food foo = new food();

                newsq.reader.Read();
                foo.name = newsq.reader.GetString(0);
                foo.meal = newsq.reader.GetString(1);
                foo.kind = newsq.reader.GetString(2);
                foo.price = newsq.reader.GetInt32(3);
                foo.id = newsq.reader.GetInt32(4);
                foo.time_prepare = newsq.reader.GetInt32(7);
                foo.image_path = newsq.reader.GetString(8);
                foo.score = newsq.reader.GetInt32(5);
                foo.rest_name = newsq.reader.GetString(6);
                foods[i] = foo;
                comboBox3.Items.Add(foods[i].rest_name);
            }

            textBox2.Text = foods[0].name;
            textBox3.Text = Convert.ToString(foods[0].id);
            textBox4.Text = Convert.ToString(foods[0].time_prepare);
            textBox5.Text = Convert.ToString(foods[0].price);
            String path = foods[0].image_path;
            Bitmap pic = new Bitmap(path);
            pictureBox1.Image = pic;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            index = 1;





            //while (newsql.reader.Read())
            //{
            //    comboBox1.Items.Add(newsql.reader.GetString(0));
            //    food_name.Add(newsql.reader.GetString(0));


            //}
            newsql.delcon();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            sqlcon newsq = new sqlcon();
            newsq.sql = "insert into rest_manager.dbo.orders_item values(" + order_id.ToString() + ",'" + textBox2.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "'," + textBox5.Text + "," + textBox4.Text + ",'" + textBox3.Text + "'," + numericUpDown1.Value.ToString() + "," + (numericUpDown1.Value * Convert.ToInt32(textBox5.Text)).ToString() + ",'in progress')";
            newsq.setcon();
            comboBox3.Enabled = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            sqlcon show_basket = new sqlcon();
            show_basket.sql = "select * from orders_item where order_id="+order_id.ToString();
            show_basket.setdata_adaptor();
            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = show_basket.ds.Tables[0];

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form14 payment_form = new Form14();
            payment_form.Show();
        }
    }
}
