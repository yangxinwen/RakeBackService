using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OperInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "OperInfo";//数据表

        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.OperInfo oper)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            userId,
                                            userName,
                                            ip,
                                            createtime,
                                            info";
                    string str = @"
                                            @userId,
                                            @userName,
                                            @ip,
                                            @createtime,
                                            @info";

                    SqlParameter[] para ={
                                             new SqlParameter("@userId",oper.UserId),
                                             new SqlParameter("@userName",oper.UserName),
                                             new SqlParameter("@ip",oper.Ip),
                                             new SqlParameter("@createtime",oper.Createtime),
                                             new SqlParameter("@info",oper.Info)
                                       };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OperInfo[public static int Add(Model.OperInfo oper)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.OperInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.OperInfo> list = new List<Model.OperInfo>();
                    SqlDataReader dr = null;
                    if (pagesize != 0 && pageindex != 0)
                    {
                        dr = SqlGet(conn, table, " * ", " id ", " order by createtime desc ", pagesize, pageindex, dic);
                    }
                    else
                    {
                        dr = SqlGet(conn, table, " * ", dic, " order by createtime desc");
                    }
                    while (dr.Read())
                    {
                        Model.OperInfo oper = new Model.OperInfo();
                        oper.Id = Convert.ToInt32(dr["id"]);
                        oper.UserId = Convert.ToInt32(dr["userId"]);
                        oper.UserName = dr["userName"] == null ? "" : dr["userName"].ToString();
                        oper.Ip = dr["ip"] == null ? "" : dr["ip"].ToString();
                        oper.Createtime = dr["createtime"] == null ? DateTime.Now : DateTime.Parse(dr["createtime"].ToString());
                        oper.Info = dr["info"] == null ? "" : dr["info"].ToString();
                        list.Add(oper);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OperInfo[public static IList<Model.OperInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
    }
}
