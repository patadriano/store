using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Register : System.Web.UI.Page
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
        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtrgstrUsername.Text) || string.IsNullOrEmpty(txtrgstrPassword.Text))
                {
                    errorrgstrMessage.Text = "Complete all fields.";
                    errorrgstrMessage.Visible = true;
                    //make error message for each textbox
                }
                else
                {
                    User user = new User();
                    //user.UserID = t.Text.ToString();
                    user.Name = txtName.Text.ToString();
                    user.Username = txtrgstrUsername.Text.ToString();
                    user.Password = txtrgstrPassword.Text.ToString();

                    if (!isUsernameUnique())
                    {
                        errorrgstrMessage.Text = "Username is taken";
                        errorrgstrMessage.Visible = true;
                    }
                    else
                    {
                        string hashedPassword = HashPassword(user.Password);
                        string constring = GetConnectionString();
                        string query = $"insert into [Userss] (Name, Username, Password) values (@Name,@Username,@Password)";

                        using (SqlConnection con = new SqlConnection(constring))
                        {
                            con.Open();

                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = query;
                            cmd.CommandType = System.Data.CommandType.Text;

                            cmd.Parameters.AddWithValue("@Name", txtName.Text.ToString());
                            cmd.Parameters.AddWithValue("@Username", txtrgstrUsername.Text.ToString());
                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                            

                            cmd.ExecuteNonQuery();
                        } 
                        Response.Redirect("Default.aspx");
                    }
                    
                }
               

            }
            catch (Exception ex)
            {

            }

           
        }
        protected bool isUsernameUnique()
        {
            
            string constring = GetConnectionString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT COUNT(*) FROM Userss WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", txtrgstrUsername.Text); 
                    con.Open();

                    int numberOfUsername = (int)cmd.ExecuteScalar();
                    return numberOfUsername == 0; 
                }
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

        
    }


    //protected string EncryptPassword(string plainpassword)
    //{
    //    string password = plainpassword; 
    //    string salt = GenerateSalt();  
    //    string hashedPassword = HashPassword(password, salt);
    //    return hashedPassword;
    //}
    //public static string GenerateSalt(int length = 32)
    //{
    //    using (var rng = new RNGCryptoServiceProvider())
    //    {
    //        byte[] saltBytes = new byte[length];
    //        rng.GetBytes(saltBytes);
    //        return Convert.ToBase64String(saltBytes);
    //    }
    //}
    //public static string HashPassword(string password, string salt)
    //{
    //    using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256))
    //    {
    //        byte[] hashedPassword = pbkdf2.GetBytes(32); 
    //        return Convert.ToBase64String(hashedPassword);
    //    }
    //}


    //protected void CheckforCharactersPassword(object sender, EventArgs e)
    //    {
    //        // check for characters

    //        //string password = txtPassword.Text; // assuming txtPassword is the ID of your password TextBox

    //        //// Check for minimum length of 8 characters
    //        //if (password.Length < 8)
    //        //{
    //        //    lblMessage.Text = "Password must be at least 8 characters long.";
    //        //    return;
    //        //}

    //        //// Check for at least one uppercase letter
    //        //if (!password.Any(char.IsUpper))
    //        //{
    //        //    lblMessage.Text = "Password must contain at least one uppercase letter.";
    //        //    return;
    //        //}

    //        //// Check for at least one lowercase letter
    //        //if (!password.Any(char.IsLower))
    //        //{
    //        //    lblMessage.Text = "Password must contain at least one lowercase letter.";
    //        //    return;
    //        //}

    //        //// Check for at least one digit (number)
    //        //if (!password.Any(char.IsDigit))
    //        //{
    //        //    lblMessage.Text = "Password must contain at least one number.";
    //        //    return;
    //        //}

    //        //// Optionally, check for at least one special character
    //        //if (!password.Any(ch => "!@#$%^&*()_+[]{}|;:,.<>?".Contains(ch)))
    //        //{
    //        //    lblMessage.Text = "Password must contain at least one special character.";
    //        //    return;
    //        //}

    //        //// If all checks pass, clear the message or proceed further
    //        //lblMessage.Text = "Password is valid.";
    //    }

    
}
