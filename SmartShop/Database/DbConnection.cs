using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SmartShop.Services;

namespace SmartShop.Database
{
    public class DbConnection
    {
        private readonly SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public bool ExecuteNonQuery(QueryService query)
        {
            int rowsAffected = 1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);
                
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

        public DataTable GetTable(QueryService query)
        {
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
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
            return table; 
        }

        public T GetSingleObject<T>(QueryService query, Func<SqlDataReader, T> converter) where T : class
        {
            var list = GetEnumerable(query, converter).ToList();
            return list.Count > 0 ? list[0] : null;
        }

        public IEnumerable<T> GetEnumerable<T>(QueryService query, Func<SqlDataReader, T> converter)
        {
            List<T> list = new List<T>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);
                
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
        
        public T GetTotalDecimal<T>(QueryService query)
        {
            var total = default(T);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.CmdStr, conn);
                cmd.CommandType = query.CmdType;
                cmd.Parameters.AddRange(query.Paras);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value && result is T tResult)
                {
                    total = tResult;
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
