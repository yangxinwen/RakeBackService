using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class RoleInfo : DBHelper.MSSQL
    {

        #region 操作
        public static string table = "RoleInfo";//数据表
        #region Add

        public static int Add(Model.RoleInfo role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "RoleName, PowerStr, AddUser,RoleDate";
                    string str = "@RoleName, @PowerStr, @AddUser,@RoleDate";
                    SqlParameter[] para ={
                                             new SqlParameter("@RoleName",role.RoleName),
                                             new SqlParameter("@PowerStr",role.PowerStr),
                                             new SqlParameter("@AddUser",role.AddUser),
                                             new SqlParameter("@RoleDate",DateTime.Now.ToString())
                                         };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.RoleInfo[public static int Add(Model.RoleInfo role)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Edit

        public static int Edit(Model.RoleInfo role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                        RoleName=@RoleName,
                                        PowerStr=@PowerStr, 
                                        IsEnable=@IsEnable";


                    string str = " RoleId=@RoleId";

                    SqlParameter[] para ={
                                             new SqlParameter("@RoleId",role.RoleId),
                                             new SqlParameter("@RoleName",role.RoleName),
                                             new SqlParameter("@PowerStr",role.PowerStr),
                                             new SqlParameter("@IsEnable",role.IsEnable)
                                         };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.RoleInfo[public static int Edit(Model.RoleInfo role)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照RoleId读取一条信息
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static Model.RoleInfo Get(int RoleId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " * ";
                    string str = "RoleId=@RoleId";
                    SqlParameter[] para ={
                                             new SqlParameter("@RoleId",RoleId)
                                       };
                    SqlDataReader dr = SqlGet(conn, table, field, str, para);
                    Model.RoleInfo role = new Model.RoleInfo();
                    if (dr.Read())
                    {
                        role.RoleId = Convert.ToInt32(dr["RoleId"]);
                        role.RoleName = dr["RoleName"].ToString();
                        role.RoleDate = Convert.ToDateTime(dr["RoleDate"]);
                        role.PowerStr = dr["PowerStr"].ToString();
                        role.Remark = dr["Remark"].ToString();
                        role.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        role.AddUser = Convert.ToInt32(dr["AddUser"]);

                    }
                    dr.Close();
                    return role;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.RoleInfo[public static Model.RoleInfo Get(int RoleId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        /// <summary>
        /// 读取全部信息
        /// </summary>
        /// <returns></returns>
        public static IList<Model.RoleInfo> Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " * ";
                    IList<Model.RoleInfo> list = new List<Model.RoleInfo>();
                    SqlDataReader dr = SqlGet(conn, table, field);
                    while (dr.Read())
                    {
                        Model.RoleInfo role = new Model.RoleInfo();
                        role.RoleId = Convert.ToInt32(dr["RoleId"]);
                        role.RoleName = dr["RoleName"].ToString();
                        role.RoleDate = Convert.ToDateTime(dr["RoleDate"]);
                        role.PowerStr = dr["PowerStr"].ToString();
                        role.Remark = dr["Remark"].ToString();
                        role.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        role.AddUser = Convert.ToInt32(dr["AddUser"]);
                        list.Add(role);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.RoleInfo[public static IList<Model.RoleInfo> Get()],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Del
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public static int Del(int RoleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "RoleId=@RoleId";
                    SqlParameter[] para ={
                                             new SqlParameter("@RoleId",RoleId)
                                       };
                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.RoleInfo[public static int Del(int RoleId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion

    }
}

