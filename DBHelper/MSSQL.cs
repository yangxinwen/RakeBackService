using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBCommon;
using System.Data.SqlClient;
using System.Data;

namespace DBHelper
{
    /// <summary>
    /// MsSql数据库操作类
    /// </summary>
   public  class MSSQL:DBOper
    {
        #region ConnectionString
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string dbName = DBConnectionString.ConnectionString("mssql");
        #endregion
        #region SqlGet
        /// <summary>
        /// sql查询全部
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field)
        {
            try
            {
                string sql = string.Format(@"select {0} from {1}", field, table);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return ExecuteReader(conn, sql, cmd, CommandType.Text) as SqlDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// sql查询全部
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field,Dictionary<string,string> dic,string orderBy)
        {
            try
            {
                string condtion = string.Empty;
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    if (kvp.Key.Equals("startDate"))
                    {
                        condtion += string.Format(" and {0} > '{1} 0:00:01' ", "createtime", kvp.Value);
                    }
                    else if (kvp.Key.Equals("endDate"))
                    {
                        condtion += string.Format(" and {0} < '{1} 23:59:59' ", "createtime", kvp.Value);
                    }
                    else
                    {
                        condtion += string.Format(" and {0} = '{1}' ", kvp.Key, kvp.Value);
                    }
                }

                string sql = string.Format(@"select {0} from {1} where 1=1 {2} {3}", field, table, condtion,orderBy);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return ExecuteReader(conn, sql, cmd, CommandType.Text) as SqlDataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sql有条件查询
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="str">查询条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field, string str, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"select {0} from {1} where {2}", field, table, str);
                SqlCommand cmd = new SqlCommand();
                return ExecuteReader(conn, sql, cmd, CommandType.Text, para) as SqlDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// sql分页基本
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="fieldkey">查询条件字段</param>
        /// <param name="str">排序字符串</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field, string fieldkey, string str, int pageSize, int pageIndex)
        {
            try
            {
                string sql = @"select top " + pageSize + " " + field + " from " + table + "  where " + fieldkey + " not in (select top " + pageSize * (pageIndex - 1) + " " + fieldkey + " from " + table + " " + str + ") " + str;
                SqlCommand cmd = new SqlCommand();
                return ExecuteReader(conn, sql, cmd, CommandType.Text) as SqlDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// sql分页基本
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="fieldkey">查询条件字段</param>
        /// <param name="str">排序字符串</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field, string fieldkey, string str, int pageSize, int pageIndex,Dictionary<string,string> dic)
        {
            try
            {
                string condtion = string.Empty;
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    if (kvp.Key.Equals("startDate"))
                    {
                        condtion += string.Format(" and {0} > '{1} 0:00:01' ", "createtime", kvp.Value);
                    }
                    else if (kvp.Key.Equals("endDate"))
                    {
                        condtion += string.Format(" and {0} < '{1} 23:59:59' ", "createtime", kvp.Value);
                    }
                    else
                    {
                        condtion += string.Format(" and {0} = '{1}' ", kvp.Key, kvp.Value);
                    }
                }
                string sql = @"select top " + pageSize + " " + field + " from " + table + "  where " + fieldkey + " not in (select top " + pageSize * (pageIndex - 1) + " " + fieldkey + " from " + table + " where 1=1 " + condtion + str + ") " + condtion + str;
                SqlCommand cmd = new SqlCommand();
                return ExecuteReader(conn, sql, cmd, CommandType.Text) as SqlDataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sql分页有条件
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="fieldkey">查询条件字段</param>
        /// <param name="str">排序字符串</param>
        /// <param name="strkey">and条件</param>
        /// <param name="strKey">条件</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">每页显示条数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static SqlDataReader SqlGet(SqlConnection conn, string table, string field, string fieldkey, string str, string strkey, string strKey, SqlParameter[] para, int pageSize, int pageIndex)
        {
            try
            {
                string sql = @"select top " + pageSize + " " + field + " from " + table + " where  " + fieldkey + " not in (select top " + pageSize * (pageIndex - 1) + " " + fieldkey + " from " + table + " where " + strKey + " " + str + ")  " + strkey + " " + str;
                SqlCommand cmd = new SqlCommand();
                return ExecuteReader(conn, sql, cmd, CommandType.Text, para) as SqlDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 统计记录，有条件查询
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="str">查询条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlGet(SqlConnection conn, string table, string str, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"select count(*) from {0} where {1}", table, str);
                SqlCommand cmd = new SqlCommand();
                return Convert.ToInt32(ExecuteScalar(conn, sql, cmd, CommandType.Text, para));
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 统计所有记录
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlGet(SqlConnection conn, string table)
        {
            try
            {
                string sql = string.Format(@"select count(*) from {0} ", table);
                SqlCommand cmd = new SqlCommand();
                return Convert.ToInt32(ExecuteScalar(conn, sql, cmd, CommandType.Text));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 统计金额
        /// </summary>
        /// <param name="count">统计字段</param>
        /// <param name="table">数据库表名称</param>
        /// <param name="str">查询条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static object SqlGet_obj(SqlConnection conn, string count, string table, string str, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"select sum( {0}) from {1} where {2}", count, table, str);
                SqlCommand cmd = new SqlCommand();
                return ExecuteScalar(conn, sql, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 统计金额
        /// </summary>
        /// <param name="count">统计字段</param>
        /// <param name="table">数据库表名称</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static object SqlGet_obj(SqlConnection conn, string table, string count)
        {
            try
            {
                string sql = string.Format(@"select sum({0}) from {1} ", count, table);
                SqlCommand cmd = new SqlCommand();
                return ExecuteScalar(conn, sql, cmd, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region SqlInsert
        /// <summary>
        /// sql插入
        /// </summary>
        /// <param name="table">数据库表名</param>
        /// <param name="field">插入字段</param>
        /// <param name="str">VALUES</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlInsert(SqlConnection conn, string table, string field, string str, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"INSERT INTO  {0}  ({1})  VALUES ({2})", table, field, str);
                SqlCommand cmd = new SqlCommand();
                return ExecuteNonQuery(conn, sql, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region SqlUpdate
        /// <summary>
        /// sql修改
        /// </summary>
        /// <param name="table">数据库表名</param>
        /// <param name="field">修改字段</param>
        /// <param name="str">修改条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlUpdate(SqlConnection conn, string table, string field, string str, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"UPDATE {0} SET {1}  WHERE {2} ", table, field, str);
                SqlCommand cmd = new SqlCommand();
                return ExecuteNonQuery(conn, sql, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region SqlDel
        /// <summary>
        /// sql有条件删除
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">传入删除条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlDel(SqlConnection conn, string table, string field, SqlParameter[] para)
        {
            try
            {
                string sql = string.Format(@"delete  from {0} where {1}", table, field);
                SqlCommand cmd = new SqlCommand();
                return ExecuteNonQuery(conn, sql, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// sql全部删除
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns></returns>
        public static int SqlDel(SqlConnection conn, string table)
        {
            try
            {
                string sql = string.Format(@"delete  from {0} ", table);
                SqlCommand cmd = new SqlCommand();
                return ExecuteNonQuery(conn, sql, cmd, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
