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
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtlgnUsername.Text.Trim(); 
                string enteredPassword = txtlgnPassword.Text.Trim();  

                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    string query = "SELECT Password FROM [Userss] WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string storedHashedPassword = reader["Password"].ToString();
                       

                        if (VerifyPassword(enteredPassword, storedHashedPassword))
                        {
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
            // Create a new SHA256 instance
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password to a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash from the password
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hash to a Base64 string (optional: you could also use Hex format)
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Hash the entered password
            string enteredPasswordHash = HashPassword(enteredPassword);

            // Compare the entered password hash with the stored hash
            return enteredPasswordHash == storedHash;
        }



    }
}