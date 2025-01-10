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
                BindProfile();
            }
        }
        protected string GetConnectionString()
        {
            //string constring = "Data Source=.\\sqlexpress;Initial Catalog=Practice;Integrated Security=True;Encrypt=False";
            //return constring;
            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }
        protected void BindProfile()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Name FROM Userss where UserID = @UserID"; // Example query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Move to the next record
                            {
                                // Access the "Name" column
                                ProfileNameLabel.Text = reader["Name"].ToString();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Image2.ImageUrl = $"~/Handler2.ashx?id={Convert.ToInt32(Session["UserID"])}";
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
                        string query = "SELECT PostID, PostTitle, PostDesc FROM Post where UserID = @UserID"; // Example query
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
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
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
           moll.Visible = true;
        }
        //protected void UpdatePrfl(string query)
        //{
        //    modal.Visible = false;

        //    List<ProfileUser> postList = new List<ProfileUser>();
        //    string connectionString = GetConnectionString();
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@Name", txtProfName.Text.ToString());
        //            cmd.Parameters.AddWithValue("@PrflImage", );
        //            cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        ProfileUser profile = new ProfileUser();
        //                        profile.ProfileID = reader.GetInt32(0);
        //                        profile.ProfileName = reader.GetString(1);
        //                        profile.ProfileImage = reader.GetString(2);
        //                        postList.Add(profile);
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("No rows found.");
        //                }
        //            }
        //            prfleProducts.DataSource = postList;
        //            prfleProducts.DataBind();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //        }
        //    }
        //}
        protected void btnSavee_Click(object sender, EventArgs e)
        {
            StartUpLoad();
            //prfupdate.Update();
            moll.Visible = false;
        }




        protected void StartUpLoad()

        {
            byte[] theImage = new byte[FileUpload2.PostedFile.ContentLength];
            HttpPostedFile Image = FileUpload2.PostedFile;
            Image.InputStream.Read(theImage, 0, (int)FileUpload2.PostedFile.ContentLength);
            int length = theImage.Length;
            if (FileUpload2.PostedFile != null && FileUpload2.PostedFile.FileName != "")
            {
                ExecuteInsert(theImage);
                Response.Write("Save Successfully!");
            }

        }

        private void ExecuteInsert(byte[] Image)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "UPDATE Userss SET Name = @Name, PrfImage = @PrfImage WHERE UserID = @UserID; ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", txtProfName.Text.ToString());
                cmd.Parameters.AddWithValue("@PrfImage", Image);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            catch (System.Data.SqlClient.SqlException ex){
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally{
                conn.Close();
            }
        }               
    }
}