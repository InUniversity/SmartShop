using System.Data.SqlClient;
using SmartShop.Database;

namespace SmartShop.Repositories
{
    public class UserRoleRepository : BaseRepository
    {
        public UserRoleRepository(DbConnection dbConn, DbConverter dbConv) : base(dbConn, dbConv)
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
                new SqlParameter($"@ID", id),
            };
            return dbConn.GetSingleObject(spCmd, paras, dbConv.ToModel<UserRole>);
        }
    }
}
