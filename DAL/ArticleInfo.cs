using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{

    public class ArticleInfo : DBHelper.MSSQL
    {
        #region 操作  
        public static string table = "ArticleInfo";
        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static int Add(Model.ArticleInfo article)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleTitle, ArticleContent,  Author,AddUser, MenuId";
                    string str = "@ArticleTitle, @ArticleContent,  @Author,@AddUser, @MenuId";
                    SqlParameter[] para ={
                                         new SqlParameter("@ArticleTitle",article.ArticleTitle),
                                         new SqlParameter("@ArticleContent",article.ArticleContent),
                                         new SqlParameter("@Author",article.Author),
                                         new SqlParameter("@AddUser",article.AddUser),
                                         new SqlParameter("@MenuId",article.MenuId),
                                     };
                    return SqlInsert(conn, table, field, str, para);

                }

            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleInfo[public static int Add(Model.ArticleInfo article)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public static int Edit(Model.ArticleInfo article)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleTitle=@ArticleTitle, ArticleContent=@ArticleContent,   MenuId=@MenuId";
                    string str = "ArticleId=@ArticleId";
                    SqlParameter[] para ={              
                                         new SqlParameter("@ArticleId",article.ArticleId),
                                         new SqlParameter("@ArticleTitle",article.ArticleTitle),
                                         new SqlParameter("@ArticleContent",article.ArticleContent),
                                         //new SqlParameter("@Author",article.Author),
                                         //new SqlParameter("@AddUser",article.AddUser),
                                         new SqlParameter("@MenuId",article.MenuId),
                                     };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleInfo[public static int Edit(Model.ArticleInfo article)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// ArticleId查询
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static Model.ArticleInfo Get(int ArticleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "ArticleId=@ArticleId";
                    SqlParameter[] para ={
                                                        new SqlParameter("@ArticleId",ArticleId)
                                        };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.ArticleInfo art = new Model.ArticleInfo();
                    if (dr.Read())
                    {
                        art.ArticleId = Convert.ToInt32(dr["ArticleId"]);
                        art.ArticleTitle = dr["ArticleTitle"].ToString();
                        art.ArticleContent = dr["ArticleContent"].ToString();
                        art.ArticleDate = Convert.ToDateTime(dr["ArticleDate"]);
                        art.Author = dr["Author"].ToString();
                        art.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        art.IsHot = Convert.ToInt32(dr["IsHot"]);
                        art.IsNew = Convert.ToInt32(dr["IsNew"]);
                        art.IsTop = Convert.ToInt32(dr["IsTop"]);
                        art.MenuId = Convert.ToInt32(dr["MenuId"]);
                        art.Remark = dr["Remark"].ToString();
                        art.AddUser = Convert.ToInt32(dr["AddUser"]);

                    }
                    dr.Close();
                    return art;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleInfo[public static Model.ArticleInfo Get(int ArticleId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        /// <summary>
        /// 分页
        /// 四中查询
        /// 1.若pagesize pageindex MenuId 全部不等于0，则是按照MenuId分页查询
        /// 2.若pagesize pageindex  全部不等于0，则是基本分页查询
        /// 3.若MenuId不等于0，则是按照MenuId查询
        /// 4.若是没有出现前三种情况，则是查询全部
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <param name="MenuId">查询条件</param>
        /// <returns></returns>

        public static IList<Model.ArticleInfo> Get(int pagesize, int pageindex, int MenuId)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(dbName))
                {

                    SqlDataReader dr = null;
                    IList<Model.ArticleInfo> list = new List<Model.ArticleInfo>();
                    if (MenuId != 0 && pageindex != 0 && pagesize != 0)
                    {
                        string field = "  *  ";
                        string fieldkey = "ArticleId";
                        string str = " order by  ArticleDate desc ";
                        string strkey = " and MenuId=@MenuId";
                        string strKey = " MenuId=@MenuId";
                        SqlParameter[] para ={

                                             new SqlParameter("@MenuId",MenuId)
                                        };

                        dr = SqlGet(conn, table, field, fieldkey, str, strkey, strKey, para, pagesize, pageindex);
                    }
                    else if (pagesize != 0 && pageindex != 0)
                    {
                        string field = " * ";
                        string fieldkey = "ArticleId";
                        string str = " order by  ArticleDate desc ";


                        dr = SqlGet(conn, table, field, fieldkey, str, pagesize, pageindex);
                    }
                    else if (MenuId != 0)
                    {
                        string field = " * ";


                        string str = " MenuId=@MenuId";
                        SqlParameter[] para ={

                                             new SqlParameter("@MenuId",MenuId)
                                        };
                        dr = SqlGet(conn, table, field, str, para);

                    }
                    else
                    {
                        dr = SqlGet(conn, table, " * ");
                    }


                    while (dr.Read())
                    {
                        Model.ArticleInfo art = new Model.ArticleInfo();
                        art.ArticleId = Convert.ToInt32(dr["ArticleId"]);
                        art.ArticleTitle = dr["ArticleTitle"].ToString();
                        art.ArticleContent = dr["ArticleContent"].ToString();
                        art.ArticleDate = Convert.ToDateTime(dr["ArticleDate"]);
                        art.Author = dr["Author"].ToString();
                        art.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        art.IsHot = Convert.ToInt32(dr["IsHot"]);
                        art.IsNew = Convert.ToInt32(dr["IsNew"]);
                        art.IsTop = Convert.ToInt32(dr["IsTop"]);
                        art.MenuId = Convert.ToInt32(dr["MenuId"]);
                        art.Remark = dr["Remark"].ToString();
                        art.AddUser = Convert.ToInt32(dr["AddUser"]);
                        list.Add(art);
                    }

                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleInfo[public static IList<Model.ArticleInfo> Get(int pagesize, int pageindex, int MenuId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Del

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static int Del(int ArticleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ArticleId=@ArticleId";
                    SqlParameter[] para ={
                                         new  SqlParameter("@ArticleId",ArticleId)
                                        };

                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ArticleInfo[public static int Del(int ArticleId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion
    }
}

