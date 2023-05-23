﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SmartShop.Database
{
    public class DbConnection
    {
        private readonly SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public bool ExecuteNonQuery(string spCmd, SqlParameter[] paras)
        {
            int rowsAffected = 1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(spCmd, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paras);
                rowsAffected = cmd.ExecuteNonQuery();
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

        public object? GetSingleObject<T>(string sqlStr, SqlParameter[] paras, Func<SqlDataReader, T> converter)
        {
            var list = GetEnumerable(sqlStr, paras, converter).ToList();
            return list.Count > 0 ? list[0] : null;
        }

        public IEnumerable<T> GetEnumerable<T>(string sqlStr, SqlParameter[] paras, Func<SqlDataReader, T> converter)
        {
            List<T> list = new List<T>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paras);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(converter(reader));
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            { 
                conn.Close(); 
            }
            return list;
        }
       
        public object? GetSingleObject<T>(string sqlStr, Func<SqlDataReader, T> converter)
        {
            var list = GetEnumerable(sqlStr, converter).ToList();
            return list.Count > 0 ? list[0] : null;
        }
        
        public IEnumerable<T> GetEnumerable<T>(string sqlStr, Func<SqlDataReader, T> converter)
        {
            List<T> list = new List<T>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(converter(reader));
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            { 
                conn.Close(); 
            }
            return list;
        }
        
        public decimal GetTotalDecimal(string sqlStr)
        {
            var total = default(decimal);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    total = Convert.ToDecimal(result);
                }
                
                cmd.Dispose();
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
