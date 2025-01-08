using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Store
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public string GetConnectionString()

        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        }

        public void ProcessRequest(HttpContext context)

        {

            string id = context.Request.QueryString["id"]; //get the querystring value that was pass on the ImageURL (see GridView MarkUp in Page1.aspx)

            if (id != null)

            {



                MemoryStream memoryStream = new MemoryStream();

                SqlConnection connection = new SqlConnection(GetConnectionString());

                string sql = "SELECT ProfileImage FROM Profile WHERE ProfileID = @id";



                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();



                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();


                if (reader.HasRows)  // Check if there are any rows in the result set
                {



                    //Get Image Data

                    byte[] file = (byte[])reader["ProfileImage"];



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