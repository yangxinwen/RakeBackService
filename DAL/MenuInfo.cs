using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace DAL
{
    /// <summary>
    /// 菜单DAL
    /// </summary>
    public class MenuInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "MenuInfo";//公共参数（数据表名）
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu">menu实体类</param>
        /// <returns>int</returns>
        public static int Add(Model.MenuInfo menu)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " MenuName, AddUser,OrderNum";
                    string str = "@MenuName, @AddUser,@OrderNum";
                    SqlParameter[] para ={
                                             new SqlParameter("@MenuName",menu.MenuName),
                                             new SqlParameter("@AddUser",menu.AddUser),
                                             new SqlParameter("@OrderNum",menu.OrderNum)

                                        };
                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.MenuInfo[public static int Add(Model.MenuInfo menu)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        #endregion

        #region Edit
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="menu">menu实体类</param>
        /// <returns>int</returns>
        public static int Edit(Model.MenuInfo menu)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                           
                                            MenuName=@MenuName,
                                            IsEnable=@IsEnable,
                                           OrderNum=@OrderNum
                                          ";
                    string str = "MenuId=@MenuId";
                    SqlParameter[] para ={
                                             new SqlParameter("@MenuId",menu.MenuId),
                                             new SqlParameter("@MenuName",menu.MenuName),
                                             new SqlParameter("@IsEnable",menu.IsEnable),
                                            new SqlParameter("@OrderNum",menu.OrderNum)

                                        };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.MenuInfo[public static int Edit(Model.MenuInfo menu)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照MenuId查询
        /// </summary>
        /// <param name="MenuId">菜单Id</param>
        /// <returns>MenuInfo实体类</returns>
        public static Model.MenuInfo Get(int MenuId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = " * ";
                    string str = "MenuId=@MenuId";
                    SqlParameter[] para ={
                                             new SqlParameter("@MenuId",MenuId)
                                         };
                    SqlDataReader dr = SqlGet(conn, table, field, str, para);
                    Model.MenuInfo menu = new Model.MenuInfo();
                    if (dr.Read())
                    {
                        menu.MenuId = (int)dr["MenuId"];
                        menu.MenuName = dr["MenuName"].ToString();
                        menu.IsEnable = (int)dr["IsEnable"];
                        menu.Remark = dr["Remark"].ToString();
                        menu.MenuDate = (DateTime)dr["MenuDate"];
                        menu.AddUser = (int)dr["AddUser"];
                        menu.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                    }
                    dr.Close();
                    return menu;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.MenuInfo[public static Model.MenuInfo Get(int MenuId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns>IList</returns>
        public static IList<Model.MenuInfo> Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.MenuInfo> list = new List<Model.MenuInfo>();
                    string field = " * ";
                    SqlDataReader dr = SqlGet(conn, table + " order by OrderNum asc  ", field);
                    while (dr.Read())
                    {
                        Model.MenuInfo menu = new Model.MenuInfo();
                        menu.MenuId = (int)dr["MenuId"];
                        menu.MenuName = dr["MenuName"].ToString();
                        menu.IsEnable = (int)dr["IsEnable"];
                        menu.Remark = dr["Remark"].ToString();
                        menu.MenuDate = (DateTime)dr["MenuDate"];
                        menu.AddUser = (int)dr["AddUser"];
                        menu.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        list.Add(menu);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.MenuInfo[public static IList<Model.MenuInfo> Get()],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        #endregion

        #region Del
        /// <summary>
        /// 按照MenuId删除
        /// </summary>
        /// <param name="MenuId">条件MenuId</param>
        /// <returns>int</returns>
        public static int Del(int MenuId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "MenuId=@MenuId";
                    SqlParameter[] para ={
                                             new SqlParameter("@MenuId",MenuId)
                                        };
                    return SqlDel(conn, table, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.MenuInfo[public static int Del(int MenuId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #endregion
    }
}

