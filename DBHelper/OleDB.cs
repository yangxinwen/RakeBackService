using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using DBCommon;

namespace DBHelper
{
    /// <summary>
    /// Access数据库操作类
    /// </summary>
    public class OleDB : DBOper
    {
        #region ConnectionString
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string dbName = DBConnectionString.ConnectionString("OleDB");
        #endregion
        #region OleGet
        /// <summary>
        /// Ole查询全部
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static OleDbDataReader OleGet(OleDbConnection conn, string table, string field)
        {
            try
            {
                string Ole = string.Format(@"select {0} from {1}", field, table);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(Ole, conn);
                return ExecuteReader(conn, Ole, cmd, CommandType.Text) as OleDbDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Ole有条件查询
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="str">查询条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static OleDbDataReader OleGet(OleDbConnection conn, string table, string field, string str, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"select {0} from {1} where {2}", field, table, str);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteReader(conn, Ole, cmd, CommandType.Text, para) as OleDbDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Ole分页基本
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="fieldkey">查询条件字段</param>
        /// <param name="str">排序字符串</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static OleDbDataReader OleGet(OleDbConnection conn, string table, string field, string fieldkey, string str, int pageSize, int pageIndex)
        {
            try
            {
                string Ole = @"select top " + pageSize + " " + field + " from " + table + "  where " + fieldkey + " not in (select top " + pageSize * (pageIndex - 1) + " " + fieldkey + " from " + table + " " + str + ") " + str;
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteReader(conn, Ole, cmd, CommandType.Text) as OleDbDataReader;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Ole分页有条件
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">查询表字段</param>
        /// <param name="fieldkey">查询条件字段</param>
        /// <param name="str">排序字符串</param>
        /// <param name="strkey">and条件</param>
        /// <param name="strKey">条件</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">每页显示条数</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static OleDbDataReader OleGet(OleDbConnection conn, string table, string field, string fieldkey, string str, string strkey, string strKey, OleDbParameter[] para, int pageSize, int pageIndex)
        {
            try
            {
                string Ole = @"select top " + pageSize + " " + field + " from " + table + " where  " + fieldkey + " not in (select top " + pageSize * (pageIndex - 1) + " " + fieldkey + " from " + table + " where " + strKey + " " + str + ")  " + strkey + " " + str;
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteReader(conn, Ole, cmd, CommandType.Text, para) as OleDbDataReader;
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
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleGet(OleDbConnection conn, string table, string str, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"select count(*) from {0} where {1}", table, str);
                OleDbCommand cmd = new OleDbCommand();
                return Convert.ToInt32(ExecuteScalar(conn, Ole, cmd, CommandType.Text, para));
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
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleGet(OleDbConnection conn, string table)
        {
            try
            {
                string Ole = string.Format(@"select count(*) from {0} ", table);
                OleDbCommand cmd = new OleDbCommand();
                return Convert.ToInt32(ExecuteScalar(conn, Ole, cmd, CommandType.Text));
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
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static object OleGet_obj(OleDbConnection conn, string count, string table, string str, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"select sum( {0}) from {1} where {2}", count, table, str);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteScalar(conn, Ole, cmd, CommandType.Text, para);
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
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static object OleGet_obj(OleDbConnection conn, string table, string count)
        {
            try
            {
                string Ole = string.Format(@"select sum({0}) from {1} ", count, table);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteScalar(conn, Ole, cmd, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region OleInsert
        /// <summary>
        /// Ole插入
        /// </summary>
        /// <param name="table">数据库表名</param>
        /// <param name="field">插入字段</param>
        /// <param name="str">VALUES</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleInsert(OleDbConnection conn, string table, string field, string str, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"INSERT INTO  {0}  ({1})  VALUES ({2})", table, field, str);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteNonQuery(conn, Ole, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region OleUpdate
        /// <summary>
        /// Ole修改
        /// </summary>
        /// <param name="table">数据库表名</param>
        /// <param name="field">修改字段</param>
        /// <param name="str">修改条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleUpdate(OleDbConnection conn, string table, string field, string str, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"UPDATE {0} SET {1}  WHERE {2} ", table, field, str);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteNonQuery(conn, Ole, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region OleDel
        /// <summary>
        /// Ole有条件删除
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="field">传入删除条件</param>
        /// <param name="para">执行参数</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleDel(OleDbConnection conn, string table, string field, OleDbParameter[] para)
        {
            try
            {
                string Ole = string.Format(@"delete  from {0} where {1}", table, field);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteNonQuery(conn, Ole, cmd, CommandType.Text, para);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Ole全部删除
        /// </summary>
        /// <param name="table">数据库表名称</param>
        /// <param name="conn">OleDbConnection</param>
        /// <returns></returns>
        public static int OleDel(OleDbConnection conn, string table)
        {
            try
            {
                string Ole = string.Format(@"delete  from {0} ", table);
                OleDbCommand cmd = new OleDbCommand();
                return ExecuteNonQuery(conn, Ole, cmd, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
