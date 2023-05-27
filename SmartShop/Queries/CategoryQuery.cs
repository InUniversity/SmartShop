using System.Data;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class CategoryQuery
    {
        public QueryService GetAll()
        {
            return new QueryService("SELECT * FROM Categories", CommandType.Text);
        }
    }
}