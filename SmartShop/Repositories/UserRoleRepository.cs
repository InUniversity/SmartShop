using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
namespace SmartShop.Repositories
{
    public class UserRoleRepository : BaseRepository
    {
        public UserRoleRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(UserRole urole)
        {
            string spCmd = $"sp_AddUserRole";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@RoleID", urole.ID),
                new SqlParameter("@RoleName", urole.Name)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteUserRole";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@RoleID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(UserRole urole)
        {
            string spCmd = $"sp_UpdateUserRole";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@RoleID", urole.ID),
                new SqlParameter("@NewRoleName", urole.Name)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public UserRole SearchByID(string id)
        {
            string spCmd = $"sp_Ser_UserR_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{uroleID}", id),
            };
            return (UserRole)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private UserRole Converter(SqlDataReader reader)
        {
            return new UserRole
            {
                ID = (string)reader[uroleID],
                Name = (string)reader[uroleName],
            };
        }
    }
}
