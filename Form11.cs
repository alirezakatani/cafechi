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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sqlcon newsq = new sqlcon();
            newsq.sql = "SELECT * FROM rest_manager.dbo.customer where username='" + text_user.Text + "' and password='" + text_pass.Text + "'";
            newsq.setcon();
            newsq.reader.Read();
            if(newsq.reader.HasRows)
            {

                customer login_customer = new customer();
                login_customer.name = newsq.reader.GetString(1);
                login_customer.username = newsq.reader.GetString(2);
                login_customer.password = newsq.reader.GetString(3);
                login_customer.phone_number = newsq.reader.GetString(4);
                login_customer.address = newsq.reader.GetString(5);
                login_customer.customer_id = newsq.reader.GetInt32(0);

                Form12 newcustomer = new Form12(login_customer);
                newcustomer.ShowDialog();

            }
            else
            {
                MessageBox.Show("user name or password not valid");
                return;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14_customer_registration newcustomer = new Form14_customer_registration();
            newcustomer.ShowDialog();
        }
    }
}
