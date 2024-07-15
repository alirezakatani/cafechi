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
    public partial class Form7 : Form
    {
        Person pers;
        string path;
        list nlist = new list();
  
        public Form7(Person per)
        {
            InitializeComponent();
            pers = per;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            refresh7();



        }

        public void refresh7()
        {
            sqlcon newsql = new sqlcon();
            newsql.sql = "select * from rest_manager.dbo.list where rest_name='"+pers.rest_name+"'";
            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if(textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("لطفا تمامی فیلد ها را کامل کنید");
                return;

            }
            list nlist = new list();
            nlist.list_date = Convert.ToDateTime(dateTimePicker1.Value);
            nlist.list_id =Convert.ToInt32(textBox3.Text);
            nlist.list_name = textBox1.Text;
            nlist.list_meal = textBox2.Text;

            Form8 fr8 = new Form8(pers,nlist);
            fr8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            sqlcon newsql = new sqlcon();
            newsql.sql = "select * from list where list_id="+Convert.ToInt32(textBox3.Text)+" and rest_name='" + pers.rest_name + "'"; 
            newsql.setcon();
            newsql.reader.Read();
            textBox1.Text = newsql.reader.GetString(1);
            textBox2.Text= newsql.reader.GetString(2);
            textBox3.Text=Convert.ToString(newsql.reader.GetInt32(0));
            nlist.list_name = textBox1.Text;
            nlist.list_meal = textBox2.Text;
            nlist.setdate(newsql.reader.GetString(3));
            dateTimePicker1.Value = nlist.list_date;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                MessageBox.Show("لطغا مسیر تصویر  را انتخاب کنید", "عدم تعیین مسیر تصویر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.list where list_name='" + textBox1.Text + "' and list_meal='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'";
            con.setcon();
            if (!con.reader.HasRows)
            {

                list newl = new list();
                //newl.list_id =Convert.ToInt32(textBox3.Text);
                newl.list_name=textBox1.Text;
                newl.list_meal = textBox2.Text;
                newl.list_date = dateTimePicker1.Value;
            
                con.delcon();
                sqlcon con3 = new sqlcon();
                con3.sql = "insert into rest_manager.dbo.list values('" + newl.list_name + "','" + newl.list_meal + "','" + newl.getdate() + "','" + pers.rest_name + "','" + path + "')";
                con3.setcon();
                Console.Write("food created");
                MessageBox.Show("لیست مورد نظر ثبت شد", "ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con3.delcon();
            }
            else
            {
                MessageBox.Show("ثبت لیست با خطا مواجه شد", "مشکل در ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.delcon();

            }
            refresh7();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            list newl = new list();
            //newl.list_id = Convert.ToInt32(textBox3.Text);
            newl.list_name = textBox1.Text;
            newl.list_meal = textBox2.Text;
            newl.list_date = dateTimePicker1.Value;

      
            if (path == null)
            {
                MessageBox.Show("لطغا مسیر تصویر  را انتخاب کنید", "عدم تعیین مسیر تصویر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.list where list_name='" + newl.list_name + "' and list_meal='" + newl.list_meal + "' and rest_name='" + pers.rest_name + "'";
            con.setcon();
            if (!con.reader.HasRows)
            {

                con.delcon();
                sqlcon con3 = new sqlcon();
                con3.sql = "update list set list_name='" + newl.list_name + "',list_meal='" + newl.list_meal + "',list_date='" + newl.getdate() + "',image_path='" + path + "' where list_name='" + nlist.list_name + "' and list_meal='" + nlist.list_meal+"' and list_date='"+nlist.getdate()+ "' and rest_name='"+pers.rest_name+"'" ;
                con3.setcon();
                Console.Write("food created");
                MessageBox.Show("لیست مورد نظر ثبت شد", "ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con3.delcon();
            }
            else
            {
                MessageBox.Show("ثبت لیست با خطا مواجه شد", "مشکل در ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.delcon();

            }
            refresh7();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            list newl = new list();
            //newl.list_id = Convert.ToInt32(textBox3.Text);
            newl.list_name = textBox1.Text;
            newl.list_meal = textBox2.Text;
            newl.list_date = dateTimePicker1.Value;
           

            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.list where list_name='" + newl.list_name + "' and list_meal='" + newl.list_meal + "' and rest_name='" + pers.rest_name + "'";
            con.setcon();
            if (con.reader.HasRows)
            {

                con.delcon();
                sqlcon con3 = new sqlcon();
                con3.sql = "delete from list where list_name='" + newl.list_name + "' and list_meal='" + newl.list_meal + "' and list_date='" + newl.getdate() + "' and rest_name='" + pers.rest_name + "'";
                con3.setcon();
                Console.Write("food created");
                MessageBox.Show("لیست مورد نظر ثبت شد", "ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con3.delcon();
            }
            else
            {
                MessageBox.Show("ثبت لیست با خطا مواجه شد", "مشکل در ثبت لیست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.delcon();

            }
            refresh7();



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
