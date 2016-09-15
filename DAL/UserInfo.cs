using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{

    public class UserInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "UserInfo";//数据表
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.UserInfo user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            userName,
                                            userPhone,
                                            userPwd,
                                            remark,
                                            roleId,
                                            loginId,
                                            createBank,
                                            branchBank,
                                            branchBankZH,
                                            bankNumber,
                                            belongTo,
                                            createtime,
                                            updatetime,
                                            api,
                                            isUpdatePass,
                                            inputPerson,
                                            iseable";
                    string str = @"
                                            @userName,
                                            @userPhone,
                                            @userPwd,
                                            @remark,
                                            @roleId,
                                            @loginId,
                                            @createBank,
                                            @branchBank,
                                            @branchBankZH,
                                            @bankNumber,
                                            @belongTo,
                                            @createtime,
                                            @updatetime,
                                            @api,
                                            @isUpdatePass,
                                            @inputPerson,
                                            @iseable";

                    SqlParameter[] para ={
                                             new SqlParameter("@userName",user.UserName),
                                             new SqlParameter("@userPhone",user.UserPhone),
                                             new SqlParameter("@userPwd",user.UserPwd),
                                             new SqlParameter("@remark",user.Remark),
                                             new SqlParameter("@roleId",user.RoleId),
                                             new SqlParameter("@loginId",user.LoginId),
                                             new SqlParameter("@createBank",user.CreateBank),
                                             new SqlParameter("@branchBank",user.BranchBank),
                                             new SqlParameter("@branchBankZH",user.BranchBankZH),
                                             new SqlParameter("@bankNumber",user.BankNumber),
                                             new SqlParameter("@belongTo",user.BelongTo),
                                             new SqlParameter("@createtime",user.Createtime),
                                             new SqlParameter("@updatetime",user.Updatetime),
                                             new SqlParameter("@api",user.Api),
                                             new SqlParameter("@isUpdatePass",user.IsUpdatePass),
                                             new SqlParameter("@inputPerson",user.InputPerson),
                                             new SqlParameter("@iseable",user.Iseable),
                                       };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static int Add(Model.UserInfo user)],错误信息：{0}", ex.ToString()));
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
        public static int Edit(Model.UserInfo user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            userName=@userName,
                                            userPhone=@userPhone,
                                            userPwd=@userPwd,
                                            remark=@remark,
                                            roleId=@roleId,
                                            loginId=@loginId,
                                            createBank=@createBank,
                                            branchBank=@branchBank,
                                            branchBankZH=@branchBankZH,
                                            bankNumber=@bankNumber,
                                            belongTo=@belongTo,
                                            updatetime=@updatetime,
                                            api=@api,
                                            isUpdatePass=@isUpdatePass,
                                            inputPerson=@inputPerson,
                                            iseable=@iseable";

                    string str = "UserId=@UserId";
                    SqlParameter[] para ={

                                          new SqlParameter("@UserId",user.UserId),
                                          new SqlParameter("@UserName",user.UserName),
                                          new SqlParameter("@userPhone",user.UserPhone),
                                          new SqlParameter("@userPwd",user.UserPwd),
                                          new SqlParameter("@remark",user.Remark),
                                          new SqlParameter("@roleId",user.RoleId),
                                          new SqlParameter("@loginId",user.LoginId),
                                          new SqlParameter("@createBank",user.CreateBank),
                                          new SqlParameter("@branchBank",user.BranchBank),
                                          new SqlParameter("@branchBankZH",user.BranchBankZH),
                                          new SqlParameter("@bankNumber",user.BankNumber),
                                          new SqlParameter("@belongTo",user.BelongTo),
                                          new SqlParameter("@updatetime",user.Updatetime),
                                          new SqlParameter("@api",user.Api),
                                          new SqlParameter("@isUpdatePass",user.IsUpdatePass),
                                          new SqlParameter("@inputPerson",user.InputPerson),
                                          new SqlParameter("@iseable",user.Iseable),
                                       };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static int Edit(Model.UserInfo user)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照UserId读取一条信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static Model.UserInfo Get(int UserId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "UserId=@UserId and iseable=@iseable";
                    SqlParameter[] para ={
                                             new SqlParameter("@UserId",UserId),
                                             new SqlParameter("@iseable","1")
                                        };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.UserInfo user = new Model.UserInfo();
                    if (dr.Read())
                    {
                        user.UserId = Convert.ToInt32(dr["UserId"]);
                        user.UserName = dr["UserName"].ToString();
                        user.UserPhone = dr["UserPhone"].ToString();
                        user.UserPwd = dr["userPwd"].ToString();
                        user.Remark = dr["remark"].ToString();
                        user.RoleId = Convert.ToInt32(dr["roleId"]);
                        user.LoginId = dr["loginId"].ToString();
                        user.CreateBank = dr["createBank"].ToString();
                        user.BranchBank = dr["branchBank"].ToString();
                        user.BranchBankZH = dr["branchBankZH"] == null ? "" : dr["branchBankZH"].ToString();
                        user.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        user.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        user.Createtime = dr["createtime"] == null ? "" : dr["createtime"].ToString();
                        user.Updatetime = dr["updatetime"] == null ? "" : dr["updatetime"].ToString();
                        user.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        user.IsUpdatePass = dr["isUpdatePass"] == null ? "" : dr["isUpdatePass"].ToString();
                        user.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();
                        user.Iseable = dr["iseable"] == null ? "0" : dr["iseable"].ToString();
                        user.Province = dr["province"] == null ? "0" : dr["province"].ToString();
                        user.City = dr["city"] == null ? "0" : dr["city"].ToString();
                    }
                    dr.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static Model.UserInfo Get(int UserId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 按照loginId读取一条信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static Model.UserInfo GetByLoginId(string loginId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "loginId=@loginId and iseable=@iseable";
                    SqlParameter[] para ={
                                             new SqlParameter("@loginId",loginId),
                                             new SqlParameter("@iseable","1")
                                        };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.UserInfo user = new Model.UserInfo();
                    if (dr.Read())
                    {
                        user.UserId = Convert.ToInt32(dr["UserId"]);
                        user.UserName = dr["UserName"].ToString();
                        user.UserPhone = dr["UserPhone"].ToString();
                        user.UserPwd = dr["userPwd"].ToString();
                        user.Remark = dr["remark"].ToString();
                        user.RoleId = Convert.ToInt32(dr["roleId"]);
                        user.LoginId = dr["loginId"].ToString();
                        user.CreateBank = dr["createBank"].ToString();
                        user.BranchBank = dr["branchBank"].ToString();
                        user.BranchBankZH = dr["branchBankZH"] == null ? "" : dr["branchBankZH"].ToString();
                        user.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        user.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        user.Createtime = dr["createtime"] == null ? "" : dr["createtime"].ToString();
                        user.Updatetime = dr["updatetime"] == null ? "" : dr["updatetime"].ToString();
                        user.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        user.IsUpdatePass = dr["isUpdatePass"] == null ? "" : dr["isUpdatePass"].ToString();
                        user.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();
                        user.Iseable = dr["iseable"] == null ? "0" : dr["iseable"].ToString();
                        //user.Province = dr["province"] == null ? "0" : dr["province"].ToString();
                        //user.City = dr["city"] == null ? "0" : dr["city"].ToString();
                    }
                    dr.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static Model.UserInfo GetByLoginId(string loginId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.UserInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.UserInfo> list = new List<Model.UserInfo>();                    
                    SqlDataReader dr = null;
                    if (pagesize != 0 && pageindex != 0)
                    {
                        dr = SqlGet(conn, table, " * ", " UserId ", " order by createtime desc ", pagesize, pageindex,dic);
                    }
                    else
                    {
                        dr = SqlGet(conn, table, " * ", dic, " order by createtime desc");
                    }
                    
                    while (dr.Read())
                    {
                        Model.UserInfo user = new Model.UserInfo();
                        user.UserId = Convert.ToInt32(dr["UserId"]);
                        user.UserName = dr["UserName"].ToString();
                        user.UserPhone = dr["UserPhone"].ToString();
                        user.UserPwd = dr["userPwd"].ToString();
                        user.Remark = dr["remark"].ToString();
                        user.RoleId = Convert.ToInt32(dr["roleId"]);
                        user.LoginId = dr["loginId"].ToString();
                        user.CreateBank = dr["createBank"].ToString();
                        user.BranchBank = dr["branchBank"].ToString();
                        user.BranchBankZH = dr["branchBankZH"] == null ? "" : dr["branchBankZH"].ToString();
                        user.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        user.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        user.Createtime = dr["createtime"] == null ? "" : dr["createtime"].ToString();
                        user.Updatetime = dr["updatetime"] == null ? "" : dr["updatetime"].ToString();
                        user.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        user.IsUpdatePass = dr["isUpdatePass"] == null ? "" : dr["isUpdatePass"].ToString();
                        user.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();
                        user.Iseable = dr["iseable"] == null ? "" : dr["iseable"].ToString();
                        //user.Province = dr["province"] == null ? "0" : dr["province"].ToString();
                        //user.City = dr["city"] == null ? "0" : dr["city"].ToString();
                        list.Add(user);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static IList<Model.UserInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserLogin">登录名称</param>
        /// <param name="UserPwdMD5">登录密码</param>
        /// <returns></returns>
        public static Model.UserInfo Get(string loginId, string userPwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string str = "loginId=@loginId and userPwd=@userPwd and iseable=@iseable";
                    SqlParameter[] para ={
                                             new SqlParameter("@loginId",loginId),
                                             new SqlParameter("@userPwd",userPwd),
                                             new SqlParameter("@iseable","1")
                                        };
                    SqlDataReader dr = SqlGet(conn, table, " * ", str, para);
                    Model.UserInfo user = new Model.UserInfo();
                    if (dr.Read())
                    {
                        user.UserId = Convert.ToInt32(dr["UserId"]);
                        user.UserName = dr["UserName"].ToString();
                        user.UserPhone = dr["UserPhone"].ToString();
                        user.UserPwd = dr["userPwd"].ToString();
                        user.Remark = dr["remark"].ToString();
                        user.RoleId = Convert.ToInt32(dr["roleId"]); 
                        user.LoginId = dr["loginId"].ToString();
                        user.CreateBank = dr["createBank"].ToString();
                        user.BranchBank = dr["branchBank"].ToString();
                        user.BranchBankZH = dr["branchBankZH"]==null ? "" : dr["branchBankZH"].ToString();
                        user.BankNumber = dr["bankNumber"] == null ? "" : dr["bankNumber"].ToString();
                        user.BelongTo = dr["belongTo"] == null ? "" : dr["belongTo"].ToString();
                        user.Createtime = dr["createtime"] == null ? "" : dr["createtime"].ToString();
                        user.Updatetime = dr["updatetime"] == null ? "" : dr["updatetime"].ToString();
                        user.Api = dr["api"] == null ? "" : dr["api"].ToString();
                        user.IsUpdatePass = dr["isUpdatePass"] == null ? "" : dr["isUpdatePass"].ToString();
                        user.InputPerson = dr["inputPerson"] == null ? "" : dr["inputPerson"].ToString();
                        user.Iseable = dr["iseable"] == null ? "" : dr["iseable"].ToString();
                        //user.Province = dr["province"] == null ? "0" : dr["province"].ToString();
                        //user.City = dr["city"] == null ? "0" : dr["city"].ToString();
                    }
                    dr.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static Model.UserInfo Get(string loginId, string userPwd)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }


        #endregion

        #region Del
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static int Del(int UserId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "UserId=@UserId";
                    SqlParameter[] para ={
                                             new SqlParameter("@UserId",UserId)
                                       };
                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.UserInfo[public static int Del(int UserId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #endregion


    }
}

