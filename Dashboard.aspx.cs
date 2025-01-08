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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Code to execute when the button is clicked
            string searchTerm = txtSearch.Text.Trim(); // Get the search term from a TextBox control

            if (!string.IsNullOrEmpty(searchTerm))
            {
                List<Posts> postList2 = new List<Posts>();
                // Define your connection string (modify with actual database details)
                string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

                // Create a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Create a SQL command
                        string query = "SELECT * FROM Post Where PostTitle LIKE @searchTerm"; // Example query

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        
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
                    catch (Exception ex)
                    {

                    }

                    Results.Update();
                }
            }
            else
            {
                // Optionally, display a message if no search term is entered
                //lblMessage.Text = "Please enter a search term.";
            }
        }
      


        protected void BindRepeater()

        {
            List<Posts> postList = new List<Posts>();
            // Define your connection string (modify with actual database details)
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            // Create a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create a SQL command
                    string query = "SELECT PostID, PostTitle, PostDesc FROM Post"; // Example query
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Execute the command and get a DataReader
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