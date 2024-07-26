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
    public partial class Form8 : Form
    {
        int list_id;
        Person pers;
        list lis;
        string path;
        food fod;
        food[] foods;
        int x;
        public Form8(Person per,list nlist)
        {
            InitializeComponent();
            pers = per;
            list_id = nlist.list_id;
            lis = nlist;


            sqlcon newsql = new sqlcon();

            newsql.sql = "select count(*) from food where rest_name='" + pers.rest_name + "'";
            newsql.setcon();
            newsql.reader.Read();
            x = newsql.reader.GetInt32(0);
            newsql.delcon();
            sqlcon newsq = new sqlcon();
            newsq.sql = "select * from food where rest_name='" + pers.rest_name + "'";
            newsq.setcon();
            foods  = new food[x];

            for (int i=0;i<x;i++)
            {
                food foo = new food();

                newsq.reader.Read();
                foo.name = newsq.reader.GetString(0);
                foo.meal = newsq.reader.GetString(1);
                foo.kind = newsq.reader.GetString(2);
                foo.price = newsq.reader.GetInt32(3);
                foo.time_prepare = newsq.reader.GetInt32(4);
                foo.image_path= newsq.reader.GetString(6);
                foods[i] = foo;
                comboBox1.Items.Add(foo.name);

            }
            
            

            //while (newsql.reader.Read())
            //{
            //    comboBox1.Items.Add(newsql.reader.GetString(0));
            //    food_name.Add(newsql.reader.GetString(0));
                

            //}
            newsql.delcon();


          


            refresh();
        }
        public void refresh()
        {


            sqlcon newsql = new sqlcon();
            newsql.sql = "select food.name as food_name,food.meal as food_meal,food.kind as food_kind,food.price as food_price,food.time_prepare as food_time_prepare,list.*,feed_back.feed_back,food.score from food left join list_match on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) left join list on(list_match.list_name=list.list_name and list_match.list_meal=list.list_meal)    inner join feed_back on (food.id=feed_back.food_id)  where list.list_id=" + list_id + " and food.rest_name='" + pers.rest_name + "'";
            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 fr9 = new Form9(pers);
            fr9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text=="" || textBox4.Text=="" || textBox5.Text=="" || path==null )
            {
                MessageBox.Show("لطفا تمامی فیلد ها را کامل کنید");
                return;

            }
            sqlcon newsql = new sqlcon();
            newsql.sql = "insert into list_match values('" + comboBox1.Text + "','" + comboBox2.Text + "','" +lis.list_name+"','"+lis.list_meal+"','"+pers.rest_name+"','"+lis.getdate()+"')" ;
            newsql.setcon();
            refresh();
            


        }

        private void button3_Click(object sender, EventArgs e)
        {

            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.food where name='" + Convert.ToString(comboBox2.SelectedItem) + "' and meal='" + Convert.ToString(comboBox2.SelectedItem) + "' and rest_name='" + pers.rest_name +"'"; ;
            con.setcon();
            if (con.reader.HasRows)
            {
                con.reader.Read();
                textBox3.Text = con.reader.GetString(2);
                textBox4.Text = Convert.ToString(con.reader.GetInt32(3));
                textBox5.Text = Convert.ToString(con.reader.GetInt32(4));

                path = con.reader.GetString(6);
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                fod = new food();
                fod.name =Convert.ToString(comboBox1.SelectedItem);
                fod.meal = Convert.ToString(comboBox2.SelectedItem);
                fod.kind = textBox3.Text;
                fod.price = Convert.ToInt32(textBox4.Text);
                fod.rest_name = pers.rest_name;
                fod.image_path = path;
                fod.time_prepare = Convert.ToInt32(textBox5.Text);
                con.delcon();
            }
            else
            {

                MessageBox.Show("غذای مورد نظر وجود ندارد", "عدم وجود غذا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon newsql = new sqlcon();
            newsql.sql = "delete from list_match where list_name='" +lis.list_name+"'and list_meal='"+lis.list_meal+"' and  food_name='"+fod.name+"' and food_meal='"+fod.meal+"' and rest_name='"+pers.rest_name+"' and list_date='"+lis.getdate()+"'" ;
            newsql.setcon();
            refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < x; i++)
            {
                food foo = new food();
                foo = foods[i];
                food fo = new food();
                fo = foods[comboBox1.SelectedIndex];
                if (foo.name == fo.name && foo.meal==fo.meal)
                {

                    textBox3.Text = foo.kind;
                    textBox4.Text = Convert.ToString(foo.price);
                    textBox5.Text = Convert.ToString(foo.time_prepare);
                    path = foo.image_path;
                    Bitmap pic = new Bitmap(path);
                    pictureBox1.Image = pic;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sqlcon newsql = new sqlcon();
            //newsql.sql = "select food.meal from food where rest_name='" + pers.rest_name + "' and name='" + food_name[comboBox1.SelectedIndex] + "'";
            //newsql.setcon();

            //while (newsql.reader.Read())
            //{
            //    comboBox2.Items.Add(newsql.reader.GetString(0));


            //}
            //newsql.delcon();
            for(int i=0;i<x;i++)
            {
                food foo = new food();
                foo = foods[i];
                food fo = new food();
                fo = foods[comboBox1.SelectedIndex];
                if (foo.name==fo.name)
                {

                    comboBox2.Items.Add(foo.meal);
                }
            }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
       
        }
    }
}
