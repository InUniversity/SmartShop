using System.Collections.Generic;
using System.Data.SqlClient;
using SmartShop.ConvertToModel;

namespace SmartShop.Database
{
    public class DbConverter
    {
        private readonly ConvModelFactory convModelFactory; 
        
        public DbConverter(ConvModelFactory convModelFactory)
        {
            this.convModelFactory = convModelFactory;
        }

        public T ToSingleObject<T>(SqlDataReader reader) where T : class
        {
            var list = ToList<T>(reader);
            return list.Count > 0 ? list[0] : null;
        }
        
        public List<T> ToList<T>(SqlDataReader reader) where T : class
        {
            if (reader == null) return new List<T>();
            var list = new List<T>();
            var factory = convModelFactory.Create(typeof(T));
            while (reader.Read())
                list.Add((T)factory.Conv(reader));
            return list;
        }
    }
}