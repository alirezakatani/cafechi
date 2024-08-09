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
    public partial class Form6 : Form
    {
        Person pers;
        string path;
        Person newemp;
        List<int> salary = new List<int>();
        public Form6(Person per)
        {
            InitializeComponent();
            pers = per;

            sqlcon jobcon = new sqlcon();
            jobcon.sql = "select role_name,role_salary from rolej where rest_name='"+pers.rest_name+"'";
            jobcon.setcon();
            

            while (jobcon.reader.Read())
            {
                comboBox1.Items.Add(jobcon.reader.GetString(0));
                salary.Add(jobcon.reader.GetInt32(1));


            }
            jobcon.delcon();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            

            if(path==null)
            {
                MessageBox.Show("لطغا مسیر تصویر  را انتخاب کنید", "عدم تعیین مسیر تصویر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.employee where name='" + textBox1.Text + "' and family_name='" + textBox2.Text + "' and rest_name='"+pers.rest_name+"'";
            con.setcon();

            if (!con.reader.HasRows)
            {




                con.delcon();
                sqlcon con3 = new sqlcon();
                con3.sql = "insert into rest_manager.dbo.employee values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "'," + Convert.ToInt32(textBox4.Text) + ",'" + textBox5.Text + "'," + (checkBox1.Checked?1:0) + ",'" + path+"','"+pers.rest_name+"',5,'" +textBox6.Text+"','"+textBox7.Text+"','"+(checkBox1.Checked?textBox9.Text:"")+ "','" + (checkBox1.Checked ? textBox8.Text : "")+"')";
                con3.setcon();
                Console.Write("food created");
                MessageBox.Show("کارمند مورد نظر ثبت شد", "ثبت کارمند", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con3.delcon();
            }
            else
            {
                MessageBox.Show("ثبت کارمند با خطا مواجه شد", "مشکل در ثبت کارمند", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.delcon();

            }
            if (checkBox1.Checked == true)
            {
                sqlcon con2 = new sqlcon();
                con2.sql = "insert into rest_manager.dbo.manager values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + pers.rest_name + "','" + textBox7.Text + "','" + textBox9.Text + "','" + textBox8.Text + "',1,'" + comboBox1.Text + "')";
                con2.setcon();
                Console.Write("food created");
                MessageBox.Show("کارمند مورد نظر به عنوان ادمین ثبت شد", "ثبت کارمند", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                con2.delcon();
                return;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.employee where name='" + textBox1.Text + "' and family_name='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'";
            con.setcon();
            if (con.reader.HasRows)
            {
                con.reader.Read();
                comboBox1.Text = con.reader.GetString(2);
                textBox4.Text = Convert.ToString(con.reader.GetInt32(3));
                textBox5.Text = con.reader.GetString(4);
                textBox6.Text = con.reader.GetString(9);
                textBox7.Text = con.reader.GetString(10);
                checkBox1.Checked = con.reader.GetBoolean(5);
                if(checkBox1.Checked==true)
                {
                    textBox9.Text = con.reader.GetString(11);
                    textBox8.Text = con.reader.GetString(12);
                }

                path = con.reader.GetString(6);
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                newemp = new Person();
                newemp.name = textBox1.Text;
                newemp.family_name = textBox2.Text;
                newemp.job = comboBox1.Text;
                newemp.salary = Convert.ToInt32(textBox4.Text);
                newemp.phone_number = textBox4.Text;
                newemp.email_address = textBox5.Text;
                newemp.account_number = textBox6.Text;
                newemp.is_admin = checkBox1.Checked;
                newemp.rest_name = pers.rest_name;
                newemp.image_path = path;
                newemp.username = textBox9.Text;
                newemp.password = textBox8.Text;
                con.delcon();
            }
            else
            {

                MessageBox.Show("کارمند مورد نظر وجود ندارد", "عدم وجود کارمند", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            newemp.name = textBox1.Text;
            newemp.family_name = textBox2.Text;
            newemp.job = comboBox1.Text;
            newemp.salary = Convert.ToInt32(textBox4.Text);
            newemp.phone_number = textBox4.Text;
            newemp.email_address = textBox5.Text;
            newemp.account_number = textBox6.Text;
            newemp.is_admin = checkBox1.Checked;
            newemp.rest_name = pers.rest_name;
            newemp.image_path = path;
            newemp.username = textBox9.Text;
            newemp.password = textBox8.Text;
            if (checkBox1.Checked ==false)
            {
                sqlcon con = new sqlcon();
                con.sql = "update rest_manager.dbo.employee set name='" + newemp.name + "',family_name ='" + newemp.family_name + "',job='" + newemp.job + "',salary=" + newemp.salary + ",phone_number='" + textBox5.Text + "',image_path='" + path +"',account_number='"+newemp.account_number+"',app_access="+0+ " where name='" + newemp.name + "' and family_name='" + newemp.family_name + "' and rest_name='" + newemp.rest_name + "'";
                con.setcon();
                con.delcon();

            }
            else
            {
                sqlcon con = new sqlcon();
                con.sql = "update rest_manager.dbo.employee set name='" + newemp.name + "',family_name ='" + newemp.family_name + "',job='" + newemp.job + "',salary=" + newemp.salary + ",phone_number='" + textBox5.Text + "',image_path='" + path + "',account_number='" + newemp.account_number + "',app_access=" + 1+",username='"+newemp.username+"',password='"+newemp.password + "' where name='" + newemp.name + "' and family_name='" + newemp.family_name + "' and rest_name='" + newemp.rest_name + "'";
                con.setcon();
                con.delcon();

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                textBox8.Enabled = true;
                textBox9.Enabled = true;
            } 
            else
            {
                textBox8.Enabled = false;
                textBox9.Enabled = false;

            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                sqlcon con = new sqlcon();
                con.sql = "Delete FROM rest_manager.dbo.employee where name='" + textBox1.Text + "' and family_name='" + textBox2.Text + "' and rest_name='"+pers.rest_name+"'";
                con.setcon();
                con.delcon();
                MessageBox.Show("کارمند مورد نظر حذف شذ", "ثبت کارمند", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                sqlcon con = new sqlcon();
                con.sql = "Delete FROM rest_manager.dbo.employee where name='" + textBox1.Text + "' and family_name='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'";
                con.setcon();
                con.delcon();

                sqlcon con2 = new sqlcon();
                con2.sql = "Delete FROM rest_manager.dbo.manager where name='" + textBox1.Text + "' and family_name='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'";
                con2.setcon();
                con2.delcon();
                MessageBox.Show("کارمند مورد نظر حذف شذ", "ثبت کارمند", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(salary[comboBox1.SelectedIndex]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
