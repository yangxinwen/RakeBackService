using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BankInfo : DBHelper.MSSQL
    {
        public static string table = "BankInfo";//公共参数（数据表名）

        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns>IList</returns>
        public static IList<Model.BankInfo> Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    IList<Model.BankInfo> list = new List<Model.BankInfo>();
                    string field = " * ";
                    SqlDataReader dr = SqlGet(conn, table + " order by id asc  ", field);
                    while (dr.Read())
                    {
                        Model.BankInfo bank = new Model.BankInfo();
                        bank.Id = (int)dr["id"];
                        bank.BankName = dr["bankName"].ToString();
                        bank.BankValue = dr["bankValue"].ToString();
                        list.Add(bank);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.BankInfo[public static IList<Model.BankInfo> Get()],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
    }
}
