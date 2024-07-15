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
    public partial class Form9 : Form
    {
        public Form9(Person pers)
        {
            InitializeComponent();
            sqlcon newsql = new sqlcon();
            newsql.sql = "select * from food where  food.rest_name='" + pers.rest_name + "'";
            newsql.setdata_adaptor();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
