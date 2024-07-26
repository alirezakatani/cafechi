using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class feed_back
    {

           public int feed_backid { get; set; }
           public int customer_id { get; set; }
           public int orders_id { get; set; }
           public int food_id { get; set; }
           public string feed{ get; set; }
           public string rest_name { get; set; }
           public int score { get; set; }
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
