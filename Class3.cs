using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class list
    {

        public int list_id  { get; set; }
        public DateTime list_date{ get; set; }
        public DateTime list_dateg
        {
     
            set { list_date =Convert.ToDateTime(value) ; }
        }
        public DateTime list_datep { get; set; }
        public string list_name { get; set; }
        public string list_meal { get; set; }

        public DateTime return_persian()
        {
            list_datep= DateTime.Parse(list_date.ToString("yyyy/MM/dd"), new CultureInfo("en-US"));
            return list_datep;
        }



        public string getdate()
        {
            return list_date.ToString("yyyy/MM/dd");
        }
        public void setdate(string value)
        {
            list_date = Convert.ToDateTime(value);
        }



    }
}
