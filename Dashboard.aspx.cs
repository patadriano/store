using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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

                // Example list of posts (can be replaced with data from a database)
                //    var posts = new List<Post>
                //    {
                //new Post { PostID = 1, PostTitle = "First Post", PostDesc = "This is the first post description." },
                //new Post { PostID = 2, PostTitle = "Second Post", PostDesc = "This is the second post description." },
                // new Post { PostID = 3, PostTitle = "Third Post", PostDesc = "This is the third post description." }

                BindRepeater();
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
                    string query = "SELECT PostID, PostTitle, PostDesc FROM Posts"; // Example query
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