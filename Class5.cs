using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class paymnet
    {
        public customer  cust{ get; set; }
        public  List<food> basket_food  { get; set; }
        public Double price_all { get; set; }
        public string payment_card { get; set; }
        public string rest_name { get; set; }
        public string payment_id { get; set; }
        public string Deposit_account_number { get; set; }
        public string Deposit_receipt_number { get; set; }
        public string reciver_phone_number { get; set; }
        public string reciver_address { get; set; }
        public Boolean book_table { get; set; }
        public int table_id { get; set; }
        public int orders_id { get; set; }
        public DateTime time { get; set; }




        public string getdate()
        {
            return time.ToString("yyyy/MM/dd");
        }
        public void setdate(string value)
        {
           time = Convert.ToDateTime(value);
        }

    }
}
