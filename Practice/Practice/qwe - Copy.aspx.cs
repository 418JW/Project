using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Practice
{
    public partial class qwe : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;


        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;





        }

        
    }
}