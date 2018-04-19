using System;
using System.IO;
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



namespace Practice
{
    public partial class Admin : System.Web.UI.Page
    {

        
         String que;
        SqlDataReader rd;
        SqlConnection con;
        SqlCommand cmd;
        
       List<Employee> emp = new List<Employee>();
        

        List<String> urls = new List<String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["AdminID"] == null)
            {
                Response.Redirect("default.aspx");
            }

            

        }

        


        protected void resultsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp = Session["employees"] as List<Employee>;
            ListItem curItem = resultsBox.SelectedItem;
            int current= resultsBox.Items.IndexOf(curItem);

           
            String un = emp[current].getun();
            String url;

            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.CommandText = "SELECT * FROM pictures WHERE username="+un;
            
            rd = cmd.ExecuteReader();
            
            while(rd.Read())
            {
                
                    url=rd["path"].ToString();
                    urls.Add(url);
                
                
            }
            rd.Close();
            con.Close();
            imageBox.ImageUrl = urls[0];
            imageBox.Visible = true;
            Session["pics"] = urls;

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
                var empl = new Employee(); 
                username = rd["username"].ToString();
                fname = rd["fname"].ToString();
                lname = rd["lname"].ToString();
                address = rd["address"].ToString();
                position = rd["position"].ToString();

                empl.setun(username);
                empl.setfn(fname);
                empl.setln(lname);
                empl.setad(address);
                empl.setpo(position);

                emp.Add(empl);
                

                resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");
                
            }
            Session["employees"] = emp;
            rd.Close();
            con.Close();
            searchBox.Text="";
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            urls = Session["pictures"] as List<String>;
            int u =urls.Count();
            int p=0;
            String s = imageBox.ImageUrl;
            for(int i=0;i<u;i++)
            {
                if(s==urls[i])
                {
                    p = i;
                }
            }
            if(p>0)
            {
                p = p - 1;
                imageBox.ImageUrl = urls[p];
                
            }
            
            

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            urls = Session["pictures"] as List<String>;
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

            String strDelimiter =",";
            String cs = ConfigurationManager.ConnectionStrings["PracticeConnectionString"].ConnectionString;
            StringBuilder sb = new StringBuilder();



            if (emp != null)
            {


                emp = Session["employees"] as List<Employee>;
                foreach (Employee epl in emp)
                {
                    sb.Append(epl.getfn() + strDelimiter);
                    sb.Append(epl.getln() + strDelimiter);
                    sb.Append(epl.getad() + strDelimiter);
                    sb.Append(epl.getpo() + strDelimiter);
                    sb.Append("\r\n");
                }


                Console.Clear();
                StreamWriter file = new StreamWriter(@"C:\Users\Owner\Desktop\Data.csv");
                file.WriteLine(sb.ToString());
                file.Close();

                String FileName = "Data.csv";
                String FilePath = "C:/Users/Owner/Desktop/Data.csv";
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);
                response.Flush();
                response.End();
                System.IO.File.Delete(@"C:\Users\Owner\Desktop\Data.csv");

            }

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

            if (Label1.Visible == true && Label2.Visible == false)
            {
                cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1";
                cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var empl = new Employee();
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    empl.setun(username);
                    empl.setfn(fname);
                    empl.setln(lname);
                    empl.setad(address);
                    empl.setpo(position);

                    emp.Add(empl);


                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");

                }
                Session["employees"] = emp;
                rd.Close();
                con.Close();
            }


            
            
                if (Label1.Visible == true && Label2.Visible == true && Label3.Visible == false)
                {
                    cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 AND " + Label2.Text.ToString()
                        + "=@label2";
                    cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                    cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);

                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                    var empl = new Employee();
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    empl.setun(username);
                    empl.setfn(fname);
                    empl.setln(lname);
                    empl.setad(address);
                    empl.setpo(position);

                    emp.Add(empl);


                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");

                }
                Session["employees"] = emp;
                rd.Close();
                    con.Close();
                }
            


           
            
                if (Label1.Visible == true && Label2.Visible == true && Label3.Visible == true && Label4.Visible == false)
                {
                    cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 AND "
                        + Label2.Text.ToString() + "=@label2 AND "
                        + Label3.Text.ToString() + "=@Label3";
                    cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                    cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);
                    cmd.Parameters.AddWithValue("@label3", filterSearchBox3.Text);

                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                    var empl = new Employee();
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    empl.setun(username);
                    empl.setfn(fname);
                    empl.setln(lname);
                    empl.setad(address);
                    empl.setpo(position);

                    emp.Add(empl);


                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");

                }
                Session["employees"] = emp;
                rd.Close();
                    con.Close();
                }
            

            
            
                if (Label1.Visible == true && Label2.Visible == true && Label3.Visible == true && Label4.Visible == true)
                {
                    cmd.CommandText = "SELECT * FROM staff WHERE " + Label1.Text.ToString() + "=@label1 AND "
                        + Label2.Text.ToString() + "=@label2 AND "
                        + Label3.Text.ToString() + "=@Label3 AND "
                        + Label4.Text.ToString() + "=@Label4";
                    cmd.Parameters.AddWithValue("@label1", filterSearchBox1.Text);
                    cmd.Parameters.AddWithValue("@label2", filterSearchBox2.Text);
                    cmd.Parameters.AddWithValue("@label3", filterSearchBox3.Text);
                    cmd.Parameters.AddWithValue("@label4", filterSearchBox4.Text);

                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                    var empl = new Employee();
                    username = rd["username"].ToString();
                    fname = rd["fname"].ToString();
                    lname = rd["lname"].ToString();
                    address = rd["address"].ToString();
                    position = rd["position"].ToString();

                    empl.setun(username);
                    empl.setfn(fname);
                    empl.setln(lname);
                    empl.setad(address);
                    empl.setpo(position);

                    emp.Add(empl);


                    resultsBox.Items.Add(fname + "    " + lname + "    " + address + "    " + position + "    ");

                }
                Session["employees"] = emp;
                rd.Close();
                    con.Close();
                }
                filterSearchBox1.Text = "";
                filterSearchBox2.Text = "";
                filterSearchBox3.Text = "";
                filterSearchBox4.Text = "";


                con.Close();

                panel.Visible = false;
            }
        

        protected void filterButton_Click(object sender, EventArgs e)
        {
            
            resultsBox.Items.Clear();
            emp.Clear();
            urls.Clear();

             

            panel.Visible = true;

            Label2.Visible = false;
            filterSearchBox2.Visible = false;
            Label3.Visible = false;
            filterSearchBox3.Visible = false;
            Label4.Visible = false;
            filterSearchBox4.Visible = false;


        }


        protected void addButton_Click(object sender, EventArgs e)
        {

            if (Label1.Visible == true && Label2.Visible == true && Label3.Visible == true && Label4.Visible==false)
            {
                Label4.Visible = true;
                filterSearchBox4.Visible = true;
                

            }
            if (Label1.Visible == true && Label2.Visible==true&& Label3.Visible == false)
            {
                Label3.Visible = true;
                filterSearchBox3.Visible = true;
                

            }
            if (Label1.Visible==true&&Label2.Visible==false)
            {
                Label2.Visible = true;
                filterSearchBox2.Visible = true;
                

            }
            
            

           



        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            Label1.Text = filterSearchBox1.Text;
            Label2.Text = filterSearchBox2.Text;
            Label3.Text = filterSearchBox3.Text;
            Label4.Text = filterSearchBox4.Text;

            filterSearchBox1.Text="";
            filterSearchBox2.Text = "";
            filterSearchBox3.Text = "";
            filterSearchBox4.Text = "";



        }
    }
}