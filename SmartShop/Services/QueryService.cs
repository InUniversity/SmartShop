using System.Data;
using System.Data.SqlClient;

namespace SmartShop.Services
{
    public class QueryService
    {
        public string CmdStr { get; set; }
        public CommandType CmdType { get; set; }
        public SqlParameter[] Paras { get; set; }

        public QueryService(string cmdStr, CommandType cmdType)
        {
            CmdStr = cmdStr;
            CmdType = cmdType;
            Paras = new SqlParameter[] {};
        }
    }
}