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
    public partial class Form14 : Form
    {

        new paymnet new_pay = new paymnet();
        public Form14(paymnet pay)
        {
            InitializeComponent();
            new_pay = pay;
            textBox1.Text = new_pay.price_all.ToString();
            textBox2.Text = new_pay.Deposit_account_number.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            new_pay.table_id = 0;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                new_pay.payment_card = textBox7.Text;
                new_pay.Deposit_receipt_number = textBox3.Text;
                new_pay.reciver_phone_number = textBox4.Text;
                new_pay.reciver_address = textBox5.Text;
                new_pay.book_table = checkBox1.Checked;
                new_pay.table_id = Convert.ToInt32(textBox6.Text);
                new_pay.time = DateTime.Now;
                sqlcon newsq = new sqlcon();
                int reserv = 0;
                if (new_pay.book_table == true)
                {
                    reserv = 1;
                }
                newsq.sql = "insert into rest_manager.dbo.payment values(" + new_pay.price_all + ",'" + new_pay.Deposit_receipt_number + "','" + new_pay.payment_card
                    + "','" + new_pay.Deposit_receipt_number + "','" + new_pay.reciver_phone_number
                    + "','" + new_pay.reciver_address + "'," + reserv.ToString() + "," + new_pay.table_id + "," + new_pay.orders_id + ",'" + new_pay.cust.customer_id + "','" + new_pay.getdate() + "','in progress','"+new_pay.rest_name+"')";
                newsq.setcon();

   
                MessageBox.Show("تراکنش با موفقیت ثبت شد. در خواست شما سفارش شما در مرحله پیش پردازش قرار گرفت", "ثبت تراکنش", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch
            {
                MessageBox.Show("تراکنش باشکست مواجه شد.", "عدم ثبت تراکنش", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();





        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox6.Visible = true;
            }
            else
            {
                textBox6.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
    }
}
