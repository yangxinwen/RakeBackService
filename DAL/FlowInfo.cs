using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FlowInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "FlowInfo";//数据表

        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.FlowInfo flow)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            orderid,
                                            ip,
                                            optypes,
                                            createtime,
                                            info";
                    string str = @"
                                            @orderid,
                                            @ip,
                                            @optypes,
                                            @createtime,
                                            @info";

                    SqlParameter[] para ={
                                             new SqlParameter("@orderid",flow.Orderid),
                                             new SqlParameter("@ip",flow.Ip),
                                             new SqlParameter("@optypes",flow.Optypes),
                                             new SqlParameter("@createtime",flow.Createtime),
                                             new SqlParameter("@info",flow.Info)
                                       };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.FlowInfo[public static int Add(Model.FlowInfo flow)],错误信息：{0}", ex.ToString()));
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
        public static IList<Model.FlowInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.FlowInfo> list = new List<Model.FlowInfo>();
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
                        Model.FlowInfo flow = new Model.FlowInfo();
                        flow.Id = Convert.ToInt32(dr["id"]);
                        flow.Orderid=dr["orderid"]==null?"":dr["orderid"].ToString();
                        flow.Ip=dr["ip"]==null?"":dr["ip"].ToString();
                        flow.Optypes=dr["optypes"]==null?"":dr["optypes"].ToString();
                        flow.Createtime = dr["createtime"] == null ? DateTime.Now : DateTime.Parse(dr["createtime"].ToString());
                        flow.Info=dr["info"]==null?"":dr["info"].ToString();
                        list.Add(flow);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.FlowInfo[public static IList<Model.FlowInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }      
        #endregion
    }
}
