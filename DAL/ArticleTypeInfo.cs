using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ArticleTypeInfo : DBHelper.MSSQL
    {

        #region 操作

        public static string table = "ArticleTypeInfo";
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(Model.ArticleTypeInfo artictype)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleTypeName, OrderNum,  AddUser";
                    string str = " @ArticleTypeName, @OrderNum,  @AddUser";
                    SqlParameter[] para ={
                                          new SqlParameter("@ArticleTypeName",artictype.ArticleTypeName),
                                          new SqlParameter("@OrderNum",artictype.OrderNum),
                                          new SqlParameter("@AddUser",artictype.AddUser)
                                    };


                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleTypeInfo[public static int Add(Model.ArticleTypeInfo artictype)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #region Edit
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="artictype"></param>
        /// <returns></returns>
        public static int Edit(Model.ArticleTypeInfo artictype)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleTypeName=@ArticleTypeName, OrderNum=@OrderNum";
                    string str = "ArticleTypeId=@ArticleTypeId";
                    SqlParameter[] para ={
                                          new SqlParameter("@ArticleTypeId",artictype.ArticleTypeId),
                                          new SqlParameter("@ArticleTypeName",artictype.ArticleTypeName),
                                          new SqlParameter("@OrderNum",artictype.OrderNum),
                                         
                                        };
                    return SqlUpdate(conn, table, field, str, para);

                }

            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleTypeInfo[public static int Edit(Model.ArticleTypeInfo artictype)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #region Get
        /// <summary>
        ///ArticleTypeId查询
        /// </summary>
        /// <returns></returns>
        public static Model.ArticleTypeInfo Get(int ArticleTypeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "ArticleTypeId=@ArticleTypeId";
                    SqlParameter[] para ={
                                         new SqlParameter("@ArticleTypeId",ArticleTypeId)
                                       };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.ArticleTypeInfo arttype = new Model.ArticleTypeInfo();
                    if (dr.Read())
                    {
                        arttype.ArticleTypeId = Convert.ToInt32(dr["ArticleTypeId"]);
                        arttype.ArticleTypeName = dr["ArticleTypeName"].ToString();
                        arttype.ArticleTypeDate = Convert.ToDateTime(dr["ArticleTypeDate"]);
                        arttype.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        arttype.AddUser = Convert.ToInt32(dr["AddUser"]);
                    }
                    dr.Close();
                    return arttype;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleTypeInfo[public static Model.ArticleTypeInfo Get(int ArticleTypeId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public static IList<Model.ArticleTypeInfo> Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.ArticleTypeInfo> list = new List<Model.ArticleTypeInfo>();

                    SqlDataReader dr = SqlGet(conn, table, " * ");

                    while (dr.Read())
                    {
                        Model.ArticleTypeInfo arttype = new Model.ArticleTypeInfo();
                        arttype.ArticleTypeId = Convert.ToInt32(dr["ArticleTypeId"]);
                        arttype.ArticleTypeName = dr["ArticleTypeName"].ToString();
                        arttype.ArticleTypeDate = Convert.ToDateTime(dr["ArticleTypeDate"]);
                        arttype.OrderNum = Convert.ToInt32(dr["OrderNum"]);
                        arttype.AddUser = Convert.ToInt32(dr["AddUser"]);
                        list.Add(arttype);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleTypeInfo[public static IList<Model.ArticleTypeInfo> Get()],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion
        #region Del
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ArticleTypeId"></param>
        /// <returns></returns>
        public static int Del(int ArticleTypeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleTypeId=@ArticleTypeId";
                    SqlParameter[] para ={
                                           new SqlParameter("@ArticleTypeId",ArticleTypeId)
                                         };
                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleTypeInfo[public static int Del(int ArticleTypeId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion
    }
}
