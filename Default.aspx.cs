using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetConnectionString()
        {
            //string constring = "Data Source=.\\sqlexpress;Initial Catalog=Practice;Integrated Security=True;Encrypt=False";
            //return constring;
            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtlgnUsername.Text.Trim(); 
                string enteredPassword = txtlgnPassword.Text.Trim();

                string constring = GetConnectionString();
                using (SqlConnection con = new SqlConnection(constring))
                {
                    string query = "SELECT UserID, Password FROM [Userss] WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string storedHashedPassword = reader["Password"].ToString();
                        string userid = reader["UserID"].ToString();


                        if (VerifyPassword(enteredPassword, storedHashedPassword))
                        {
                            Session["UserID"] = userid;
                            Response.Redirect("~/Dashboard.aspx");
                        }
                        else
                        {
                            
                            errorMessage.Text = "Invalid username or password.";
                            errorMessage.Visible = true;
                        }
                    }
                    else
                    {
                        errorMessage.Text = "Invalid username or password.";
                        errorMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Text = "An error occurred: " + ex.Message;
                errorMessage.Visible = true;
            }
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);
            return enteredPasswordHash == storedHash;
        }

    }
}