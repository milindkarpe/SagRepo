using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SAGDAL
{
    public static class clsDb
    {
        public static string getConnectionString()
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return ConnectionString;
        }       

        public static string ReplaceText(string Str)
        {
            return (Str.Replace("'", "''").Trim().ToString());
        }

        public static DataSet GetDatasets(string Str)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = getConnectionString();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            if (conn.State == ConnectionState.Open)
            {
                cmd.CommandText = Str.ToString();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                conn.Close();
            }
            return ds;
        }

        

        public static DataSet GetTransactionDataSet(string Str, SqlConnection conn, SqlTransaction Trans)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            if (conn.State == ConnectionState.Open)
            {
                cmd.CommandText = Str.ToString();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Transaction = Trans;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                conn.Close();

            }
            return ds;
        }

        public static void InsertUpdate(string Str)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = getConnectionString();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            if (conn.State == ConnectionState.Open)
            {
                cmd.CommandText = Str.ToString();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
