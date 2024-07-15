using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class sqlcon
    {

        public String sql { get; set; }
        public SqlConnection connection { get; set; }
        public SqlConnectionStringBuilder builder { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }
        public DataSet ds;
        public BindingSource bs;


        public void setcon()
        {
            builder= new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-TQRCIBA";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";
            connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            reader = command.ExecuteReader();
            
        }

        public void delcon()
        {
            connection.Close();
        }


        public DataSet setdata_adaptor()
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-TQRCIBA";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";
            connection = new SqlConnection(builder.ConnectionString); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(sql, connection);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            bs = new BindingSource();
            bs.DataSource = ds.Tables[0];
            bs.ResetBindings(false);


            return ds;
        }
            
           


    }
}
