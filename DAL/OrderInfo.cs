using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "OrderInfo";//数据表
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.OrderInfo order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            orderid,
                                            batchno,
                                            amount,
                                            createtime,
                                            submittime,
                                            batchContent,
                                            uid,
                                            orderstatus,
                                            remark,
                                            iseable,
                                            updatetime,
                                            createBank,
                                            branchBank,
                                            branchBankZH,
                                            bankNumber,
                                            belongTo,
                                            api,
                                            userName,
                                            loginId,
                                            inputPerson";
                    string str = @"
                                            @orderid,
                                            @batchno,
                                            @amount,
                                            @createtime,
                                            @submittime,
                                            @batchContent,
                                            @uid,
                                            @orderstatus,
                                            @remark,
                                            @iseable,
                                            @updatetime,
                                            @createBank,
                                            @branchBank,
                                            @branchBankZH,
                                            @bankNumber,
                                            @belongTo,
                                            @api,
                                            @userName,
                                            @loginId,
                                            @inputPerson";

                    SqlParameter[] para ={
                                             new SqlParameter("@orderid",order.OrderId),
                                             new SqlParameter("@batchno",order.BatchNo),
                                             new SqlParameter("@amount",order.Amount),
                                             new SqlParameter("@createtime",order.CreateTime),
                                             new SqlParameter("@submittime",order.SubmitTime),
                                             new SqlParameter("@batchContent",order.BatchContent),
                                             new SqlParameter("@uid",order.Uid),
                                             new SqlParameter("@orderstatus",order.OrderStatus),
                                             new SqlParameter("@remark",order.Remark),
                                             new SqlParameter("@iseable",order.Iseable),
                                             new SqlParameter("@updatetime",order.UpdateTime),
                                             new SqlParameter("@createBank",order.CreateBank),
                                             new SqlParameter("@branchBank",order.BranchBank),
                                             new SqlParameter("@branchBankZH",order.BranchBankZH),
                                             new SqlParameter("@bankNumber",order.BankNumber),
                                             new SqlParameter("@belongTo",order.BelongTo),
                                             new SqlParameter("@api",order.Api),
                                             new SqlParameter("@userName",order.UserName),
                                             new SqlParameter("@loginId",order.LoginId),
                                             new SqlParameter("@inputPerson",order.InputPerson)
                                       };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static int Add(Model.OrderInfo order)],错误信息：{0}", ex.ToString()));
                throw;
            }            
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照orderId读取一条信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static Model.OrderInfo Get(int orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "id=@id";
                    SqlParameter[] para ={
                                             new SqlParameter("@id",orderId),
                                             new SqlParameter("@iseable","1")
                                        };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.OrderInfo order = new Model.OrderInfo();
                    if (dr.Read())
                    {
                        order.Id = Convert.ToInt32(dr["id"]);
                        order.OrderId = dr["orderid"] == null ? "" : dr["orderid"].ToString();
                        order.BatchNo = dr["batchno"] == null ? "" : dr["batchno"].ToString();
                        order.Amount = dr["amount"] == null ? "" : dr["amount"].ToString();
                        order.CreateTime = dr["createtime"] == null ? DateTime.Now : DateTime.Parse(dr["createtime"].ToString());
                        order.SubmitTime = dr["submittime"] == null ? DateTime.Now : DateTime.Parse(dr["submittime"].ToString());
                        order.BatchContent = dr["batchContent"] == null ? "" : dr["batchContent"].ToString();
                        order.Uid = dr["uid"] == null ? 0 :int.Parse(dr["uid"].ToString());
                        order.OrderStatus = dr["orderstatus"] == null ? "" : dr["orderstatus"].ToString();
                        order.Remark = dr["remark"] == null ? "" : dr["remark"].ToString();
                        order.Iseable = dr["iseable"] == null ? "" : dr["iseable"].ToString();
                        order.UpdateTime = dr["updatetime"] == null ? DateTime.Now : DateTime.Parse(dr["updatetime"].ToString());
                        order.CreateBank = dr["createBank"] == null ? "" : dr["createBank"].ToString();
                        order.BranchBank = dr["branchBank"] == null ? "" : dr["branchBank"].ToString();
                        order.BranchBankZH = dr["branchBankZH"] == null ? "" : dr["branchBankZH"].ToString();
                        order.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        order.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        order.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        order.UserName = dr["userName"] == null ? "" : dr["userName"].ToString();
                        order.LoginId = dr["loginId"] == null ? "" : dr["loginId"].ToString();
                        order.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();  
                    }
                    dr.Close();
                    return order;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static Model.OrderInfo Get(int orderId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 统计金额
        /// </summary>
        /// <param name="dic">查询条件</param>
        /// <returns></returns>
        public static string AmountStatistics(Dictionary<string, string> dic)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    SqlDataReader dr = null;
                    string field = @"sum(cast(amount as money)) amount";
                    dr = SqlGet(conn, table, field, dic, "");
                    while (dr.Read())
                    {
                        result = dr["amount"].ToString().Length == 0 ? "0" : float.Parse(dr["amount"].ToString()).ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static string Statistics(Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
            return result;
        }

        /// <summary>
        /// 统计订单笔数
        /// </summary>
        /// <param name="dic">查询条件</param>
        /// <returns></returns>
        public static string AmountStatisticsCount(Dictionary<string, string> dic)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    SqlDataReader dr = null;
                    string field = @" count(*) as  count ";
                    dr = SqlGet(conn, table, field, dic, "");
                    while (dr.Read())
                    {
                        result = dr["count"].ToString().Length == 0 ? "0" : dr["count"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static string AmountStatisticsCount(Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
            return result;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.OrderInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.OrderInfo> list = new List<Model.OrderInfo>();
                    SqlDataReader dr = null;
                    string field = @"id,
                                     orderid,
                                     batchno,
                                     amount,
                                     createtime,
                                     submittime,
                                     batchContent,
                                     uid,
                                     orderstatus ,
                                     (case orderstatus 
                                     when '1' then '新单' 
                                     when '6' then '已审核' 
                                     when '2' then '会员已浏览' 
                                     when '3' then '银行已返回成功' 
                                     when '4' then '银行已返回失败'
                                     when '5' then '银行处理中'
                                     else '不正常订单' end) as status,
                                     remark,
                                     iseable,
                                     updatetime,
                                     createBank,
                                     branchBank,
                                     branchBankZH,
                                     bankNumber,
                                     belongTo,
                                     api,
                                     userName,
                                     loginId,
                                     inputPerson";
                    if (pagesize != 0 && pageindex != 0)
                    {
                        dr = SqlGet(conn, table, field, " id ", " order by createtime desc ", pagesize, pageindex, dic);
                    }
                    else
                    {
                        dr = SqlGet(conn, table, field, dic, " order by createtime desc");
                    }

                    while (dr.Read())
                    {
                        Model.OrderInfo order = new Model.OrderInfo();
                        order.Id = Convert.ToInt32(dr["id"]);
                        order.OrderId = dr["orderid"] == null ? "" : dr["orderid"].ToString();
                        order.BatchNo = dr["batchno"] == null ? "" : dr["batchno"].ToString();
                        order.Amount = dr["amount"] == null ? "" : dr["amount"].ToString();
                        order.CreateTime = dr["createtime"] == null ? DateTime.Now : DateTime.Parse(dr["createtime"].ToString());
                        order.SubmitTime = dr["submittime"] == null ? DateTime.Now : DateTime.Parse(dr["submittime"].ToString());
                        order.BatchContent = dr["batchContent"] == null ? "" : dr["batchContent"].ToString();
                        order.Uid = dr["uid"] == null ? 0 : int.Parse(dr["uid"].ToString());
                        order.OrderStatus = dr["orderstatus"] == null ? "" : dr["orderstatus"].ToString();
                        order.Remark = dr["remark"] == null ? "" : dr["remark"].ToString();
                        order.Iseable = dr["iseable"] == null ? "" : dr["iseable"].ToString();
                        order.UpdateTime = dr["updatetime"] == null ? DateTime.Now : DateTime.Parse(dr["updatetime"].ToString());
                        order.CreateBank = dr["createBank"] == null ? "" : dr["createBank"].ToString();
                        order.BranchBank = dr["branchBank"] == null ? "" : dr["branchBank"].ToString();
                        order.BranchBankZH = dr["branchBankZH"] == null ? "" : dr["branchBankZH"].ToString();
                        order.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        order.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        order.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        order.UserName = dr["userName"] == null ? "" : dr["userName"].ToString();
                        order.LoginId = dr["loginId"] == null ? "" : dr["loginId"].ToString();
                        order.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();
                        order.Status = dr["status"] == null ? "" : dr["status"].ToString();
                        list.Add(order);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static IList<Model.OrderInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Del(Model.OrderInfo order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            iseable=@iseable,
                                            inputPerson=@inputPerson";

                    string str = "id=@id";
                    SqlParameter[] para ={
                                          new SqlParameter("@iseable",order.Iseable),
                                          new SqlParameter("@inputPerson",order.InputPerson),
                                          new SqlParameter("@id",order.Id)
                                       };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static int Edit(Model.OrderInfo order)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }        
        #endregion

        #region Edit

        /// <summary>
        /// 状态编辑
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Edit(Model.OrderInfo order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            orderstatus=@orderstatus,
                                            inputPerson=@inputPerson";

                    string str = "id=@id";
                    SqlParameter[] para ={
                                          new SqlParameter("@orderstatus",order.OrderStatus),
                                          new SqlParameter("@inputPerson",order.InputPerson),
                                          new SqlParameter("@id",order.Id)
                                       };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.OrderInfo[public static int Edit(Model.OrderInfo order)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion
    }
}
