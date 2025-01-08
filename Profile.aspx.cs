using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                        prfleProducts.DataSource = postList;
                        prfleProducts.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            
        }
        //protected void btnEdit_Click(object sender, EventArgs e)
        //{
        //    modal.Visible = true;
        //}
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            modal.Visible = false;

            List<ProfileUser> postList = new List<ProfileUser>();
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProfileUser profile = new ProfileUser();
                                profile.ProfileID = reader.GetInt32(0);
                                profile.ProfileName = reader.GetString(1);
                                profile.ProfileImage = reader.GetString(2);

                                // Add the Post object to the list
                                postList.Add(profile);


                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                    prfleProducts.DataSource = postList;
                    prfleProducts.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        protected string CheckProfileIfNull(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "Select * from Profile; ";
            string queryy;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                             queryy = "UPDATE Profile SET ProfileName = @ProfileName, ProfileImage = @ProfileImage WHERE ProfileID = @UserID;";
                             


                        }
                        else
                        {
                            queryy = "INSERT INTO (ProfileName, ProfileImage, UserID) VALUES (@ProfileName, @ProfileImage, @UserID)";
                        }
                    return queryy;
                }
                   
                }
                    // Handle any errors
                    Console.WriteLine($"Error: {ex.Message}");
                
            }

        }


        //protected void btnSavee_Click(object sender, EventArgs e)
        //{
        //    StartUpLoad();
        //    modal.Visible = false;


        //}
        //protected void StartUpLoad()

        //{


        //    byte[] theImage = new byte[FileUpload1.PostedFile.ContentLength];
        //    HttpPostedFile Image = FileUpload1.PostedFile;
        //    Image.InputStream.Read(theImage, 0, (int)FileUpload1.PostedFile.ContentLength);
        //    int length = theImage.Length;
        //    if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        //    {
        //        ExecuteInsert(theImage, length);
        //        Response.Write("Save Successfully!");
        //    }

        //}

        //public string GetConnectionString()

        //{
        //    return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //}



        //private void ExecuteInsert(byte[] Image, int length)
        //{
        //    SqlConnection conn = new SqlConnection(GetConnectionString());



        //    string sql = "INSERT INTO Post (PostTitle, PostDesc, PostImage) VALUES "

        //                + " (@PostTitle, @PostDesc, @PostImage)";

        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@PostTitle", SqlDbType.VarChar, 50);
        //        param[1] = new SqlParameter("@PostDesc", SqlDbType.VarChar, 50);
        //        param[2] = new SqlParameter("@PostImage", SqlDbType.Image, length);


        //        param[0].Value = txtItemTitle.Text.ToString();
        //        param[1].Value = txtItemDesc.Text.ToString();
        //        param[2].Value = Image;

        //        for (int i = 0; i < param.Length; i++)
        //        {
        //            cmd.Parameters.Add(param[i]);
        //        }

        //        cmd.CommandType = CommandType.Text;

        //        cmd.ExecuteNonQuery();
        //    }

        //    catch (System.Data.SqlClient.SqlException ex){
        //        string msg = "Insert Error:";

        //        msg += ex.Message;

        //        throw new Exception(msg);
        //    }

        //    finally{

        //        conn.Close();

        //    }

        //}
    }
}