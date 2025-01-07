using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using System.Data;

using System.IO;



namespace Store
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public string GetConnectionString()

        {

            //sets the connection string from your web config file "ConnString" is the name of your Connection String

            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        }

        public void ProcessRequest(HttpContext context)

        {

            string id = context.Request.QueryString["id"]; //get the querystring value that was pass on the ImageURL (see GridView MarkUp in Page1.aspx)

            if (id != null)

            {



                MemoryStream memoryStream = new MemoryStream();

                SqlConnection connection = new SqlConnection(GetConnectionString());

                string sql = "SELECT * FROM TblImages WHERE ImageID = @id";



                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();



                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();


                if (reader.HasRows)  // Check if there are any rows in the result set
                {



                    //Get Image Data

                    byte[] file = (byte[])reader["Image"];



                reader.Close();

                connection.Close();

                memoryStream.Write(file, 0, file.Length);

                context.Response.Buffer = true;

                context.Response.BinaryWrite(file);

                memoryStream.Dispose();

                }

            }

        }



        public bool IsReusable
        {

            get
            {

                return false;

            }

        }

    }
}