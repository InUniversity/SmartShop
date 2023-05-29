﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using SmartShop.Services;

namespace SmartShop.Database
{
    public class DbConnection
    {
        private readonly SqlConnection conn;

        public DbConnection(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool ExecuteNonQuery(QueryService query)
        {
            int rowsAffected = 1;
            try
            {
                conn.Open();
                using var cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                rowsAffected = -1;
            }
            finally 
            { 
                conn.Close(); 
            }
            return rowsAffected > 0;
        }

        /// <summary>
        /// Call the Close() method of the SqlDataReader instance after use
        /// </summary>
        public SqlDataReader ExecuteReader(QueryService query)
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                using var cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return reader;
        }
        
        public T ExecuteScalar<T>(QueryService query)
        {
            var total = default(T);
            try
            {
                conn.Open();
                using var cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value && result is T tResult)
                {
                    total = tResult;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            { 
                conn.Close(); 
            }
            return total;
        }
    }
}
