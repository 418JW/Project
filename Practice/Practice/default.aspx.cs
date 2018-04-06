using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Practice
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand dmc;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            con = new SqlConnection();
            cmd = new SqlCommand();
            dmc = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            cmd.Connection = con;
            dmc.Connection = con;
            cmd.CommandType = CommandType.Text;
            dmc.CommandType = CommandType.Text;


        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string pos="";
            string p = "";
            
            con.Open();
            cmd.CommandText = "SELECT * FROM staff WHERE username=@username AND password=@password";
            cmd.Parameters.AddWithValue("@username", tb_username.Text);
            cmd.Parameters.AddWithValue("@password", tb_password.Text);
            reader=cmd.ExecuteReader();

            if (reader.Read())
            {
                pos = reader["position"].ToString();
                if (pos == "Admin")
                {
                    Session["AdminID"] = reader[0].ToString();
                    reader.Close();
                    Response.Redirect("Admin.aspx");
                }
                
            }
            reader.Close();
               
           
                dmc.CommandText = "SELECT * FROM staff WHERE username=@nusername AND password=@npassword";
                dmc.Parameters.AddWithValue("@nusername", tb_username.Text);
                dmc.Parameters.AddWithValue("@npassword", tb_password.Text);
                reader = dmc.ExecuteReader();
                if (reader.Read())
                {
                    p = reader["position"].ToString();
                    if (p != "Admin")
                    {
                        Session["NonadminID"] = reader[0].ToString();
                        reader.Close();
                        Response.Redirect("Nonadmin.aspx");
                    }
                }
                else
                {
                    reader.Close();
                    lb_msg.Text= "Wrong username and/or password";
                }
            


            con.Close();
        }
           




    }
}