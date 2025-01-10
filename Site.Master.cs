using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            Session.Clear();   
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            modal.Visible = true;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            StartUpLoad();

            Cache["WTF"] = true;

            modal.Visible = false;
            Response.Redirect("~/Dashboard.aspx", false);

        }
        protected void StartUpLoad()

        {


            byte[] theImage = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile Image = FileUpload1.PostedFile;
            Image.InputStream.Read(theImage, 0, (int)FileUpload1.PostedFile.ContentLength);
            int length = theImage.Length;
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                ExecuteInsert(theImage, length);
                Response.Write("Save Successfully!");
            }

        }

        public string GetConnectionString()

        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            //string constring = "Data Source=.\\sqlexpress;Initial Catalog=Practice;Integrated Security=True;Encrypt=False";
            //return constring;
        }



        private void ExecuteInsert(byte[] Image, int length)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());



            string sql = "INSERT INTO Post (PostTitle, PostDesc, PostImage, UserID) VALUES "

                        + " (@PostTitle, @PostDesc, @PostImage, @UserID)";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PostTitle", SqlDbType.VarChar, 50);
                param[1] = new SqlParameter("@PostDesc", SqlDbType.VarChar, 50);
                param[2] = new SqlParameter("@PostImage", SqlDbType.Image, length);
                param[3] = new SqlParameter("@UserID", SqlDbType.Int);


                param[0].Value = txtItemTitle.Text.ToString();
                param[1].Value = txtItemDesc.Text.ToString();
                param[2].Value = Image;
                param[3].Value = Convert.ToInt32(Session["UserID"]);

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }

            catch (System.Data.SqlClient.SqlException ex)

            {
                string msg = "Insert Error:";

                msg += ex.Message;

                throw new Exception(msg);
            }

            finally

            {

                conn.Close();

            }

        }


    }
}