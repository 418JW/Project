using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.Text;
using System.IO;

namespace Practice
{
    public partial class Nonadmin : System.Web.UI.Page
    {

        int k = 1;
        String que;
        SqlDataReader rd;
        SqlConnection con;
        SqlCommand cmd;
        List<employee> emp = new List<employee>();
        List<String> urls = new List<String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NonadminID"] == null)
            {
                Response.Redirect("default.aspx");
            }

        }




        protected void resultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int current = resultsBox.SelectedIndex;
            String un = emp[current].getun();
            String url;

            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.CommandText = "SELECT * FROM pictures WHERE username=" + un;

            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                url = rd["path"].ToString();
                urls.Add(url);


            }
            rd.Close();
            con.Close();
            imageBox.ImageUrl = urls[0];
            imageBox.Visible = true;


        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            resultsBox.Items.Clear();
            emp.Clear();
            urls.Clear();
            String username;
            String fname;
            String lname;
            String address;
            String position;

            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.CommandText = "SELECT * FROM staff WHERE fname=@search OR lname=@search OR position=@search";
            cmd.Parameters.AddWithValue("@search", searchBox.Text);

            que = cmd.CommandText;

            foreach (SqlParameter p in cmd.Parameters)
            {
                que = que.Replace(p.ParameterName, p.Value.ToString());
            }

            que = "SELECT * FROM staff";

            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                username = rd["username"].ToString();
                fname = rd["fname"].ToString();
                lname = rd["lname"].ToString();
                address = rd["address"].ToString();
                position = rd["position"].ToString();

                emp.Add(new employee(username, fname, lname, address, position));

                resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
            }

            rd.Close();
            con.Close();

        }

        protected void previousButton_Click(object sender, EventArgs e)
        {

            int u = urls.Count();
            int p = 0;
            String s = imageBox.ImageUrl;
            for (int i = 0; i < u; i++)
            {
                if (s == urls[i])
                {
                    p = i;
                }
            }
            if (p > 0)
            {
                p = p - 1;
                imageBox.ImageUrl = urls[p];

            }



        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int u = urls.Count();
            int p = 0;
            String s = imageBox.ImageUrl;
            for (int i = 0; i < u; i++)
            {
                if (s == urls[i])
                {
                    p = i;
                }
            }
            if (p < u)
            {
                p = p + 1;

                imageBox.ImageUrl = @urls[p];

            }



        }



        protected void exportButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;

            String strDelimiter = ",";
            String cs = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            StringBuilder sb = new StringBuilder();


            conn.Open();
            String query = "SELECT * FROM staff";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();



            da.Fill(dt);


            foreach (DataRow staffDR in dt.Rows)
            {
                sb.Append(staffDR["fname"].ToString() + strDelimiter);
                sb.Append(staffDR["lname"].ToString() + strDelimiter);
                sb.Append(staffDR["address"].ToString() + strDelimiter);
                sb.Append(staffDR["position"].ToString());
                sb.Append("\r\n");


            }

            conn.Close();





            Console.Clear();
            StreamWriter file = new StreamWriter(@"C:\Users\Owner\Desktop\expo\Data.csv");
            file.WriteLine(sb.ToString());
            file.Close();

            String FileName = "Data.csv";
            String FilePath = "C:/Users/Owner/Desktop/expo/Data.csv"; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(FilePath);
            response.Flush();
            response.End();

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true);
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            resultsBox.Items.Clear();
            emp.Clear();
            urls.Clear();
            String username;
            String fname;
            String lname;
            String address;
            String position;

            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            con.Open();

            if (k == 1)
            {
                cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1";
                cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();




                    emp.Add(new employee(username, fname, lname, address, position));

                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
                }
                que = cmd.CommandText;
                rd.Close();
                con.Close();
            }

            if (k == 2)
            {
                cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 OR " + Label2.Text.ToString()
                    + "=@label2";
                cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    emp.Add(new employee(username, fname, lname, address, position));

                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
                }
                que = cmd.CommandText;
                rd.Close();
                con.Close();
            }
            if (k == 3)
            {
                cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 OR "
                    + Label2.Text.ToString() + "=@label2 OR "
                    + Label3.Text.ToString() + "=@Label3";
                cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);
                cmd.Parameters.AddWithValue("@label3", filterSearchBox3.Text);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    emp.Add(new employee(username, fname, lname, address, position));

                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
                }
                que = cmd.CommandText;
                rd.Close();
                con.Close();
            }
            if (k == 4)
            {
                cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 OR "
                    + Label2.Text.ToString() + "=@label2 OR "
                    + Label3.Text.ToString() + "=@Label3 OR "
                    + Label4.Text.ToString() + "=@Label4";
                cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);
                cmd.Parameters.AddWithValue("@label3", filterSearchBox3.Text);
                cmd.Parameters.AddWithValue("@label4", filterSearchBox4.Text);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    emp.Add(new employee(username, fname, lname, address, position));

                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
                }
                que = cmd.CommandText;
                rd.Close();
                con.Close();
            }



            con.Close();

            panel.Visible = false;
        }

        protected void filterButton_Click(object sender, EventArgs e)
        {
            resultsBox.Items.Clear();
            emp.Clear();
            urls.Clear();
            k = 1;


            panel.Visible = true;

            addButton.Visible = false;
            changeButton.Visible = false;
            Label2.Visible = false;
            filterSearchBox2.Visible = false;
            Label3.Visible = false;
            filterSearchBox3.Visible = false;
            Label4.Visible = false;
            filterSearchBox4.Visible = false;


        }


        protected void addButton_Click(object sender, EventArgs e)
        {

            if (k == 2)
            {
                Label3.Visible = true;
                filterSearchBox3.Visible = true;
                k = k + 1;

            }
            if (k == 1)
            {
                Label3.Visible = true;
                filterSearchBox3.Visible = true;
                k = k + 1;

            }
            if (k == 0)
            {
                Label2.Visible = true;
                filterSearchBox2.Visible = true;
                k = k + 1;

            }







        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            Label1.Text = filterSearchBox1.Text;
            Label2.Text = filterSearchBox2.Text;
            Label3.Text = filterSearchBox3.Text;
            Label4.Text = filterSearchBox4.Text;

            filterSearchBox1.Text = "";
            filterSearchBox2.Text = "";
            filterSearchBox3.Text = "";
            filterSearchBox4.Text = "";



        }
    }
}