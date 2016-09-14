using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ErrorInfo : DBHelper.MSSQL
    {
        #region 操作
        public static string table = "ErrorInfo";//数据表

        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.ErrorInfo ei)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"
                                            message,
                                            createtime";
                    string str = @"
                                            @message,
                                            @createtime";

                    SqlParameter[] para ={
                                             new SqlParameter("@message",ei.Message),
                                             new SqlParameter("@createtime",ei.Createtime)
                                       };

                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ErrorInfo[public static int Add(Model.ErrorInfo ei)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        public static int AddError(string error)
        {
            Model.ErrorInfo ei = new Model.ErrorInfo();
            ei.Message = error;
            ei.Createtime = DateTime.Now;
            return Add(ei);
        }
        #endregion
    
        #endregion
    }
}
