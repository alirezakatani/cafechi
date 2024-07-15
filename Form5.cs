using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        Person pers;
        string path;
        food fod;

        public Form5(Person person)
        {
            InitializeComponent();
            pers = person;
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || path == null)
            {
                MessageBox.Show("لطفا تمامی فیلد ها را کامل کنید");
                return;

            }
            String sql = "SELECT * FROM rest_manager.dbo.food where name='" +textBox1.Text + "' and meal='" + textBox2.Text + "' and rest_name='"+pers.rest_name+"'";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-TQRCIBA";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            fod = new food();
            fod.name = textBox1.Text;
            fod.meal = textBox2.Text;
            fod.kind = textBox3.Text;
            fod.price =Convert.ToInt32(textBox4.Text);
            fod.rest_name = pers.rest_name;
            fod.image_path = path;
            fod.time_prepare = Convert.ToInt32(textBox5.Text);



            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        sql = "insert into rest_manager.dbo.food values('" + fod.name + "','" + fod.meal + "','" + fod.kind + "','" + fod.price + "','" + fod.time_prepare + "','" + fod.rest_name + "','" + fod.image_path +"',0)";
                        
                        connection.Close();
                        connection.Open();
                        SqlCommand command2 = new SqlCommand(sql, connection);
                        command2.ExecuteReader();
                        Console.Write("food created");

                        MessageBox.Show("غذا مورد نظر ثبت شد","ثبت غذا",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        reader.Read();
                        MessageBox.Show("this food already exist","Eror",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }

                }
            }
            connection.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {

            sqlcon con = new sqlcon();
            con.sql=  "SELECT * FROM rest_manager.dbo.food where name='" + textBox1.Text + "' and meal='"+textBox2.Text + "' and rest_name='" + pers.rest_name + "'"; ;
            con.setcon();
            if(con.reader.HasRows)
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
                fod.name = textBox1.Text;
                fod.meal = textBox2.Text;
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

        private void button5_Click(object sender, EventArgs e)
        {
            sqlcon con = new sqlcon();
            con.sql = "Delete FROM rest_manager.dbo.food where name='" + textBox1.Text + "' and meal='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'"; ;
            con.setcon();
            con.delcon();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(path!=null)
            {
                sqlcon con = new sqlcon();
                con.sql = "update rest_manager.dbo.food set name='" + textBox1.Text + "',meal ='" + textBox2.Text + "',kind='" + textBox3.Text + "',price=" + textBox4.Text + ",time_prepare=" + textBox5.Text +",image_path='"+path+"' where name='" + fod.name + "' and meal='" + fod.meal  +"' and rest_name='" + fod.rest_name + "'";
                con.setcon();
                con.delcon();

            }
            else
            {
                sqlcon con = new sqlcon();
                con.sql = "update rest_manager.dbo.food set name='" + textBox1.Text + "',meal ='" + textBox2.Text + "',kind='" + textBox3.Text + "',price=" + textBox4.Text + ",time_prepare=" + textBox5.Text + " where name='" + fod.name + "' and meal='" + fod.meal + "' and rest_name='"+fod.rest_name+"'";
                con.setcon();
                con.delcon();

            }



        }
    }
}
