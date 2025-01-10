using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

                BindRepeater();
                if (Session["UserID"] != null)
                {
                    lblUsername.Text = "Hello, " + Session["UserID"];
                }
                else
                {
                    lblUsername.Text = "Hello, Guest!";
                }
            }

            if (Convert.ToBoolean(Cache["WTF"]))
            {
                Cache.Remove("WTF");
                BindRepeater();
            }
        }
        protected string GetConnectionString()

        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            ////string constring = "Data Source=.\\sqlexpress;Initial Catalog=Practice;Integrated Security=True;Encrypt=False";
            ////return constring;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                List<Posts> postList2 = new List<Posts>();
                string connectionString = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT * FROM Post Where PostTitle LIKE @searchTerm"; 
                        SqlCommand cmd = new SqlCommand(query, conn);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Posts post = new Posts();
                                    post.PostID = reader.GetInt32(0);  
                                    post.PostTitle = reader.GetString(1);  
                                    post.PostDesc = reader.GetString(2); 
                                    postList2.Add(post);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found.");
                            }
                        }
                        rptProducts.DataSource = postList2;
                        rptProducts.DataBind();

                    }
                    catch (Exception ex){}
                    Results.Update();
                }
            }
            else
            {
               
            }
        }
      


        protected void BindRepeater()

        {
            List<Posts> postList = new List<Posts>();
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PostID, PostTitle, PostDesc FROM Post"; // Example query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if there are rows
                        if (reader.HasRows)
                        {
                            // Read each row
                            while (reader.Read())
                            {
                                // Access data by column index or name
                                Posts post = new Posts();

                                // Access data by column index or name and assign it to the Post object
                                post.PostID = reader.GetInt32(0);  // Column 0: PostID
                                post.PostTitle = reader.GetString(1);  // Column 1: PostTitle
                                post.PostDesc = reader.GetString(2);  // Column 2: PostDesc

                                // Add the Post object to the list
                                postList.Add(post);


                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                    rptProducts.DataSource = postList;
                    rptProducts.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        
    }
}