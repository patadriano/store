using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }
        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            modal.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            modal.Visible = false;
            //Posts post = new Posts();
            ////post.PostID =
            //post.PostTitle = txtItemTitle.Text;
            //post.PostDesc = txtItemDesc.Text;
            ////post.PostImage = 

            if (fileUpload.HasFile)
            {
                try
                {
                    byte[] imageBytes = null;
                    using (BinaryReader reader = new BinaryReader(fileUpload.PostedFile.InputStream))
                    {
                        imageBytes = reader.ReadBytes(fileUpload.PostedFile.ContentLength);
                    }

                    string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString; ;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string sql = "INSERT INTO Posts (PostTitle, PostDesc, PostImage) VALUES (@Title, @Desc, @Image)";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Title", txtItemTitle.Text);
                            cmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text);
                            cmd.Parameters.AddWithValue("@Image", imageBytes);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }


                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }

        }
        //protected void btnpop_Click(object sender, EventArgs e)
        //{

        //    //HtmlGenericControl popupModal = (HtmlGenericControl)FindControl("popupModal");

        //    //// Show the modal by setting its display style to "block"
        //    //if (popupModal != null)
        //    //{
        //    //    popupModal.Style["display"] = "block";
        //    //} 
        //    popupModal.Visible = true;

        //}
        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    popupModal.Visible = false; // Hide the modal
        //}
    }
}