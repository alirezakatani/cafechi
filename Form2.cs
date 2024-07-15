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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 for1 = new Form1();
            for1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("لطفا نام خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا نام خانوداگی خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا  شماره تلفن خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا ادرس ایمیل خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا نام رستوران خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا شماره حساب خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا نام کاربری خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا رمز عبور خودرا وارد کنید", "هشدار ناقص بودن اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //rest_managerEntities1 Db = new rest_managerEntities1();
            //maangers managerdb = new maangers();
            //managerdb.name = textBox1.Text;
            //managerdb.family_name = textBox2.Text;
            //managerdb.mobile_phone = textBox3.Text;
            //managerdb.email_address = textBox4.Text;
            //managerdb.rest_name = textBox5.Text;
            //managerdb.account_number = textBox6.Text;
            //managerdb.username = textBox7.Text;
            //managerdb.password = textBox8.Text;
            //managerdb.job = textBox9.Text;
            //managerdb.isAdmin = false;
            //Db.SaveChanges();
            //Db.SaveChangesAsync();


            //String sql = "SELECT name,rest_name FROM rest_manager.dbo.manager where name=1";
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-TQRCIBA";
                builder.UserID = "Sa";
                builder.Password = "1080566783";
                builder.InitialCatalog = "rest_manager";
                String sql = "insert into rest_manager.dbo.manager values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "',1,'" + textBox9.Text + "')";
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //if(!reader.HasRows)
                        //{
                        //    Console.Write("not valid");
                        //    MessageBox.Show("not valid");
                        //    return;

                        //}
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", Convert.ToString(reader.GetString(0)), Convert.ToString(reader.GetString(1)));
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
            MessageBox.Show("Dear " + textBox1.Text + " you registred successfuly","sign in",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();








        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
