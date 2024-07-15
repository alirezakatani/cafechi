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


    public partial class Form1 : Form
    {

        public Person manager;
        public Form1()
        {
            InitializeComponent();

       
 
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "DESKTOP-TQRCIBA";
            //    builder.UserID = "Sa";
            //    builder.Password = "1080566783";
            //    builder.InitialCatalog = "rest_manager";
          

            //    SqlConnection connection = new SqlConnection(builder.ConnectionString);
            //connection.Close();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM rest_manager.dbo.manager where username='"+text_user.Text+"' and password='"+text_pass.Text+"'";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-TQRCIBA";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";


            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.Write("user name or password not valid");
                        MessageBox.Show("user name or password not valid");
                        return;
                    }
                    else
                    {
                        reader.Read();
                        MessageBox.Show("welcome "+reader.GetString(1)+ " "+reader.GetString(2));
                        
                        manager = new Person();
                        manager.name = reader.GetString(1);
                        manager.family_name = reader.GetString(2);
                        manager.phone_number = reader.GetString(3);
                        manager.email_address = reader.GetString(4);
                        manager.rest_name = reader.GetString(5);
                        manager.account_number = reader.GetString(6);
                        manager.username = reader.GetString(7);
                        manager.password = reader.GetString(8);
                        manager.is_admin = reader.GetBoolean(9);
                        manager.job = reader.GetString(10);
                        Form3 fr3 = new Form3(manager);
                        fr3.Show(this);
                        
                    }

                }
            }
            connection.Close();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newmanager = new Form2();
            newmanager.ShowDialog();
          




        }
    }
}
