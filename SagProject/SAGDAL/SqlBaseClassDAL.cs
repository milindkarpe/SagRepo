using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace SAGDAL
{
    public class SqlBaseClassDAL
    {
        SqlConnection con = new SqlConnection(); //= new SqlConnection("Data Source=D-3;Initial Catalog=MyExamFunda;User ID=sa");
        SqlCommand cmd = new SqlCommand();

        public SqlBaseClassDAL()
        {
            con = new SqlConnection();
        }

        private void OpenConnection()
        {
            try
            {
                ////if(con!=null)
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetSqlConnectionString();
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// Method For Execute Query
        public void ExecuteSQL(string sSQL)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sSQL, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //ExecuteSP Method with parameter
        public void ExecuteSP(string SPName, SqlParameter[] ParamArray)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ExecuteSP Method without parameter
        public void ExecuteSP(string SPName)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //ExecuteDataset Method with parameters
        public DataSet ExecuteDatasetSP(string SPName, SqlParameter[] ParamArray)
        {
            try
            {
                OpenConnection();

                DataSet ds = new DataSet();
                SqlDataAdapter da;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                da = new SqlDataAdapter(cmd);
                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }
                da.Fill(ds);
                con.Close();   //$ Milind 17-10-2011 ADDED --

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        //ExecuteDataset Method without parameter
        public DataSet ExecuteDatasetSP(string SPName)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                SqlDataAdapter da;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                con.Close();   //$ Milind 17-10-2011 ADDED --
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //ExecuteScalarSP Method 
        public object ExecuteScalarSP(string SPName)
        {
            try
            {
                object obj = new object();
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                obj = cmd.ExecuteScalar().ToString();
                con.Close();   //$ Milind 17-10-2011 ADDED --
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public object ExecuteScalarSP(string SPName, SqlParameter[] ParamArray)
        {
            try
            {
                object obj = new object();
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }
                //obj = cmd.ExecuteScalar().ToString();
                obj = Convert.ToString(cmd.ExecuteScalar());
                con.Close();   //$ Milind 17-10-2011 ADDED --
                return obj;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public SqlDataReader ExecuteReaderSP(string SPName)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;
                SqlDataReader reader;
                //foreach (SqlParameter p in ParamArray)
                //{
                //    cmd.Parameters.Add(p);
                //}
                reader = cmd.ExecuteReader();
                return reader;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }



        public SqlDataReader ExecuteReaderSP(string SPName, SqlParameter[] ParamArray)
        {
            SqlDataReader reader;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        //ExecuteReader Methode for simple query 
        public DataTable ExecuteReader(string sSQL)
        {
            DataTable table;
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand(sSQL, con);

                SqlDataReader reader = cmd.ExecuteReader();
                table = new DataTable();
                table.Load(reader);

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return table;
        }

        //ExecuteScalar Methode for simple query 
        public string ExecuteScalar(string sSQL)
        {
            string value = "";
            try
            {
                //cmd.Connection.Open();
                SqlCommand cmd = new SqlCommand(sSQL, con);
                value = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return value;
        }
        // MIlind--
        public String ExecuteMMScalarSP(string SPName)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                string value = Convert.ToString(cmd.ExecuteScalar());
                con.Close();   //$ Milind 17-10-2011 ADDED --
                //obj = cmd.ExecuteScalar().ToString();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        //Dipti
        public Object ExecuteScalarBoolSP(string SPName, SqlParameter[] ParamArray)
        {
            try
            {
                object obj = new object();
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }

                obj = cmd.ExecuteScalar();

                con.Close();   //$ Milind 17-10-2011 ADDED --
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        // End Dipti
        //MIlind



        public string ExecuteMMScalarSP(string SPName, SqlParameter[] ParamArray)
        {
            try
            {

                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = SPName;

                foreach (SqlParameter p in ParamArray)
                {
                    cmd.Parameters.Add(p);
                }
                //obj = cmd.ExecuteScalar().ToString();

                string value = Convert.ToString(cmd.ExecuteScalar());
                con.Close();   //$ Milind 17-10-2011 ADDED --
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        //Connection String    
        private string GetSqlConnectionString()
        {
            string Constr;
            Constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return Constr;
        }

    }
}
