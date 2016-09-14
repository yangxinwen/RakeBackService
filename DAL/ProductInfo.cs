using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductInfo : DBHelper.MSSQL
    {

        #region 操作

        public static string table = "ProductInfo";
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(Model.ProductInfo prod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ProductName, ProductContent, AddUser";
                    string str = "@ProductName, @ProductContent, @AddUser";
                    SqlParameter[] para ={
                                         new SqlParameter("@ProductName",prod.ProductName),
                                         new SqlParameter("@ProductContent",prod.ProductContent),
                                         new SqlParameter("@AddUser",prod.AddUser)

                                      };
                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ProductInfo[public static int Add(Model.ProductInfo prod)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion
        #region Edit
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static int Edit(Model.ProductInfo prod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "ProductName=@ProductName, ProductContent=@ProductContent";
                    string str = " ProductId=@ProductId";
                    SqlParameter[] para ={
                                         new SqlParameter("@ProductName",prod.ProductName),
                                         new SqlParameter("@ProductContent",prod.ProductContent),
                                         new SqlParameter("@ProductId",prod.ProductId)

                                      };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ProductInfo[public static int Edit(Model.ProductInfo prod)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion
        #region Get
        /// <summary>
        /// ProductId查询
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public static Model.ProductInfo Get(int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"ProductId, ProductName, ProductImg, ProductDate, IsEnable, Remark, ProductTypeId, AddUser, ProductContent";
                    string str = "ProductId=@ProductId";
                    SqlParameter[] para ={
                                           new SqlParameter("@ProductId",ProductId)
                                        };
                    SqlDataReader dr = SqlGet(conn, table, field, str, para);
                    Model.ProductInfo prod = new Model.ProductInfo();
                    if (dr.Read())
                    {
                        prod.ProductId = Convert.ToInt32(dr["ProductId"]);
                        prod.ProductName = dr["ProductName"].ToString();
                        prod.ProductImg = dr["ProductImg"].ToString();
                        prod.ProductDate = Convert.ToDateTime(dr["ProductDate"]);
                        prod.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        prod.Remark = dr["Remark"].ToString();
                        prod.ProductTypeId = Convert.ToInt32(dr["ProductTypeId"]);
                        prod.AddUser = Convert.ToInt32(dr["AddUser"]);
                        prod.ProductContent = dr["ProductContent"].ToString();
                    }
                    dr.Close();
                    return prod;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ProductInfo[public static Model.ProductInfo Get(int ProductId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public static IList<Model.ProductInfo> Get(int pagesize, int pageindex)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"ProductId, ProductName, ProductImg, ProductDate, IsEnable, Remark, ProductTypeId, AddUser, ProductContent";
                    string fieldkey = "ProductId";
                    string str = " order by ProductDate desc";
                    SqlDataReader dr = null;

                    if (pagesize != 0 && pageindex != 0)
                    {
                        dr = SqlGet(conn, table, field, fieldkey, str, pagesize, pageindex);
                    }
                    else
                    {
                        dr = SqlGet(conn, table, field);
                    }

                    IList<Model.ProductInfo> list = new List<Model.ProductInfo>();
                    while (dr.Read())
                    {
                        Model.ProductInfo prod = new Model.ProductInfo();
                        prod.ProductId = Convert.ToInt32(dr["ProductId"]);
                        prod.ProductName = dr["ProductName"].ToString();
                        prod.ProductImg = dr["ProductImg"].ToString();
                        prod.ProductDate = Convert.ToDateTime(dr["ProductDate"]);
                        prod.IsEnable = Convert.ToInt32(dr["IsEnable"]);
                        prod.Remark = dr["Remark"].ToString();
                        prod.ProductTypeId = Convert.ToInt32(dr["ProductTypeId"]);
                        prod.AddUser = Convert.ToInt32(dr["AddUser"]);
                        prod.ProductContent = dr["ProductContent"].ToString();
                        list.Add(prod);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ProductInfo[public static IList<Model.ProductInfo> Get(int pagesize, int pageindex)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }
        #endregion
        #region Del
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public static int Del(int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {

                    string field = "ProductId=@ProductId";
                    SqlParameter[] para ={
                                           new SqlParameter("@ProductId",ProductId)
                                        };

                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.ProductInfo[public static int Del(int ProductId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion
        #endregion

    }
}
