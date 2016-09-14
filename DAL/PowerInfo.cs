using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{

    public class PowerInfo : DBHelper.MSSQL
    {

        #region 操作

        public static string table = "PowerInfo";//数据表
        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="power">Power实体类</param>
        /// <returns>int</returns>
        public static int Add(Model.PowerInfo power)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "PowerName, AddUser, IsLeft, PageUrl,MenuId,OrderNum,Remark";
                    string str = "@PowerName,@AddUser, @IsLeft, @PageUrl,@MenuId,@OrderNum,@Remark";
                    SqlParameter[] para ={
                                          
                                             new SqlParameter("@PowerName",power.PowerName),
                                             new SqlParameter("@AddUser",power.AddUser),
                                             new SqlParameter("@IsLeft",power.IsLeft),
                                             new SqlParameter("@PageUrl",power.PageUrl),
                                             new SqlParameter("@MenuId",power.MenuId),
                                             new SqlParameter("@OrderNum",power.OrderNum),
                                             new SqlParameter("@Remark",power.Remark)
                                        };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static int Add(Model.PowerInfo power)],错误信息：{0}", ex.ToString()));
                throw;
            }

        }

        #endregion

        #region Edit
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="power">Power实体类</param>
        /// <returns>int</returns>
        public static int Edit(Model.PowerInfo power)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                          
                                            PowerName=@PowerName, 
                                            MenuId=@MenuId, 
                                            IsEnable=@IsEnable,
                                            IsLeft=@IsLeft, 
                                            PageUrl=@PageUrl,OrderNum=@OrderNum,Remark=@Remark";

                    string str = "PowerId=@PowerId";

                    SqlParameter[] para ={
                                             new SqlParameter("@PowerId",power.PowerId),
                                             new SqlParameter("@PowerName",power.PowerName),
                                             new SqlParameter("@IsLeft",power.IsLeft),
                                             new SqlParameter("@PageUrl",power.PageUrl),
                                             new SqlParameter("@MenuId",power.MenuId),
                                             new SqlParameter("@IsEnable",power.IsEnable),                                           
                                             new SqlParameter("@OrderNum",power.OrderNum),
                                             new SqlParameter("@Remark",power.Remark)

                                        };

                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static int Edit(Model.PowerInfo power)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Get

        /// <summary>
        /// 按照PowerId读取一条信息
        /// </summary>
        /// <param name="PowerId"></param>
        /// <returns></returns>
        public static Model.PowerInfo Get(int PowerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " * ";
                    string str = "PowerId=@PowerId";
                    SqlParameter[] para ={
                                           new  SqlParameter("@PowerId",PowerId)
                                        };
                    SqlDataReader dr = SqlGet(conn, table, field, str, para);
                    Model.PowerInfo power = new Model.PowerInfo();
                    if (dr.Read())
                    {
                        power.PowerId = (int)dr["PowerId"];
                        power.PowerName = dr["PowerName"].ToString();
                        power.PowerDate = Convert.ToDateTime(dr["PowerDate"]);
                        power.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        power.IsLeft = Convert.ToInt32(dr["IsLeft"]);
                        power.MenuId = Convert.ToInt32(dr["MenuId"]);
                        power.PageUrl = dr["PageUrl"].ToString();
                        power.Remark = dr["Remark"].ToString();
                        power.AddUser = Convert.ToInt32(dr["AddUser"]);
                        power.OrderNum = Convert.ToInt32(dr["OrderNum"]);

                    }
                    dr.Close();
                    return power;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static Model.PowerInfo Get(int PowerId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns></returns>
        public static IList<Model.PowerInfo> Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " * ";

                    IList<Model.PowerInfo> list = new List<Model.PowerInfo>();

                    SqlDataReader dr = SqlGet(conn, table, field);

                    while (dr.Read())
                    {
                        Model.PowerInfo power = new Model.PowerInfo();
                        power.PowerId = (int)dr["PowerId"];
                        power.PowerName = dr["PowerName"].ToString();
                        power.PowerDate = Convert.ToDateTime(dr["PowerDate"]);
                        power.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        power.IsLeft = Convert.ToInt32(dr["IsLeft"]);
                        power.MenuId = Convert.ToInt32(dr["MenuId"]);
                        power.PageUrl = dr["PageUrl"].ToString();
                        power.Remark = dr["Remark"].ToString();
                        power.AddUser = Convert.ToInt32(dr["AddUser"]);
                        power.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        list.Add(power);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static IList<Model.PowerInfo> Get()],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 按照PowerId进行IN查询
        /// </summary>
        /// <param name="PowerStr"></param>
        /// <returns></returns>
        public static IList<Model.PowerInfo> Get(string PowerStr, int MenuId, int isleft)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    conn.Open();
                    IList<Model.PowerInfo> list = new List<Model.PowerInfo>();
                    string sql = string.Empty;
                    if (MenuId != 0)
                    {
                        sql = @"select  *  from PowerInfo  where PowerId  in (" + PowerStr + ") and MenuId=" + MenuId + " and IsLeft=" + isleft;
                    }
                    else
                    {
                        sql = @"select  *  from PowerInfo  where PowerId  in (" + PowerStr + ")  and IsLeft=" + isleft;

                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Model.PowerInfo power = new Model.PowerInfo();
                        power.PowerId = (int)dr["PowerId"];
                        power.PowerName = dr["PowerName"].ToString();
                        power.PowerDate = Convert.ToDateTime(dr["PowerDate"]);
                        power.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        power.IsLeft = Convert.ToInt32(dr["IsLeft"]);
                        power.MenuId = Convert.ToInt32(dr["MenuId"]);
                        power.PageUrl = dr["PageUrl"].ToString();
                        power.Remark = dr["Remark"].ToString();
                        power.AddUser = Convert.ToInt32(dr["AddUser"]);
                        power.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        list.Add(power);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static IList<Model.PowerInfo> Get(string PowerStr, int MenuId, int isleft)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        /// <summary>
        /// 按照MenuId进行查询
        /// </summary>
        /// <param name="PowerStr"></param>
        /// <returns></returns>
        public static IList<Model.PowerInfo> GetMenuId(int MenuId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    conn.Open();
                    IList<Model.PowerInfo> list = new List<Model.PowerInfo>();

                    string sql = @"select  *  from PowerInfo  where MenuId  = " + MenuId;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Model.PowerInfo power = new Model.PowerInfo();
                        power.PowerId = (int)dr["PowerId"];
                        power.PowerName = dr["PowerName"].ToString();
                        power.PowerDate = Convert.ToDateTime(dr["PowerDate"]);
                        power.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        power.IsLeft = Convert.ToInt32(dr["IsLeft"]);
                        power.MenuId = Convert.ToInt32(dr["MenuId"]);
                        power.PageUrl = dr["PageUrl"].ToString();
                        power.Remark = dr["Remark"].ToString();
                        power.AddUser = Convert.ToInt32(dr["AddUser"]);
                        power.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        list.Add(power);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static IList<Model.PowerInfo> GetMenuId(int MenuId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        public static IList<Model.PowerInfo> GetMenuId(int MenuId, int isleft)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    conn.Open();
                    IList<Model.PowerInfo> list = new List<Model.PowerInfo>();

                    string sql = @"select  *  from PowerInfo  where MenuId  = " + MenuId + "and IsLeft=" + isleft;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Model.PowerInfo power = new Model.PowerInfo();
                        power.PowerId = (int)dr["PowerId"];
                        power.PowerName = dr["PowerName"].ToString();
                        power.PowerDate = Convert.ToDateTime(dr["PowerDate"]);
                        power.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        power.IsLeft = Convert.ToInt32(dr["IsLeft"]);
                        power.MenuId = Convert.ToInt32(dr["MenuId"]);
                        power.PageUrl = dr["PageUrl"].ToString();
                        power.Remark = dr["Remark"].ToString();
                        power.AddUser = Convert.ToInt32(dr["AddUser"]);
                        power.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        list.Add(power);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static IList<Model.PowerInfo> GetMenuId(int MenuId, int isleft)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion

        #region Del

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="PowerId"></param>
        /// <returns></returns>
        public static int Del(int PowerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "PowerId=@PowerId";
                    SqlParameter[] para ={
                                             new SqlParameter("@PowerId",PowerId)
                                        };
                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PowerInfo[public static int Del(int PowerId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion

    }
}

