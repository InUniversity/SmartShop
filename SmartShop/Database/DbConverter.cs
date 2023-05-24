using System.Collections.Generic;
using System.Data;
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
        
        public List<T> ToList<T>(DataTable table) where T : class
        {
            var list = new List<T>();
            var factory = convModelFactory.Create(typeof(T));
            foreach (DataRow row in table.Rows)
            {

                var obj = factory.Conv(row);
                list.Add((T)obj);
            }
            return list;
        }

        public T ToModel<T>(DataRow row) where T : class
        {
            var factory = convModelFactory.Create(typeof(T));
            return (T)factory.Conv(row);
        }
        
        public T ToModel<T>(SqlDataReader reader) where T : class
        {
            var factory = convModelFactory.Create(typeof(T));
            return (T)factory.Conv(reader);
        }
    }
}