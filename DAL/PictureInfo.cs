using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class PictureInfo : DBHelper.MSSQL
    {

        #region 操作

        public static string table = "PictureInfo";
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(Model.PictureInfo pict)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "PictureName,  AddUser,PictureTypeId,PictureImg";
                    string str = "@PictureName,  @AddUser,@PictureTypeId,@PictureImg";
                    SqlParameter[] para ={
                                         new SqlParameter("@PictureName",pict.PictureName),
                                        
                                         new SqlParameter("@AddUser",pict.Adduser),
                                         new SqlParameter("@PictureTypeId",pict.PictureTypeId),
                                         new SqlParameter("@PictureImg",pict.PictureImg)
                                      };
                    return SqlInsert(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PictureInfo[public static int Add(Model.PictureInfo pict)],错误信息：{0}", ex.ToString()));
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
        public static int Edit(Model.PictureInfo pict)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = "PictureName=@PictureName, PictureImg=@PictureImg";
                    string str = " PictureId=@PictureId";
                    SqlParameter[] para ={
                                         new SqlParameter("@PictureName",pict.PictureName),
                                        
                                        
                                         new SqlParameter("@PictureImg",pict.PictureImg),
                                         new SqlParameter("@PictureId",pict.PictureId)

                                      };
                    return SqlUpdate(conn, table, field, str, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PictureInfo[public static int Edit(Model.PictureInfo pict)],错误信息：{0}", ex.ToString()));
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
        public static Model.PictureInfo Get(int PictureId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"PictureId, PictureName, PictureContent, PictureImg, PictureTypeId, PictureDate, Adduser";
                    string str = "PictureId=@PictureId";
                    SqlParameter[] para ={
                                           new SqlParameter("@PictureId",PictureId)
                                        };
                    SqlDataReader dr = SqlGet(conn, table, field, str, para);
                    Model.PictureInfo pict = new Model.PictureInfo();
                    if (dr.Read())
                    {
                        pict.PictureId = Convert.ToInt32(dr["PictureId"]);
                        pict.PictureName = dr["PictureName"].ToString();
                        pict.PictureContent = dr["PictureContent"].ToString();
                        pict.PictureImg = dr["PictureImg"].ToString();
                        pict.PictureTypeId = dr["PictureTypeId"].ToString();
                        pict.PictureDate = Convert.ToDateTime(dr["PictureDate"]);
                        pict.Adduser = Convert.ToInt32(dr["Adduser"]);

                    }
                    dr.Close();
                    return pict;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PictureInfo[public static Model.PictureInfo Get(int PictureId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public static IList<Model.PictureInfo> Get(int pagesize, int pageindex, string PictureTypeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {
                    string field = @"PictureId, PictureName, PictureContent, PictureImg, PictureTypeId, PictureDate, Adduser";
                    string fieldkey = "PictureId";
                    string str = " order by PictureDate desc";
                    string strkey = " and PictureTypeId=@PictureTypeId";
                    string strKey = " PictureTypeId=@PictureTypeId";
                    SqlParameter[] para ={
                                           new SqlParameter("@PictureTypeId",PictureTypeId)
                                        };
                    SqlDataReader dr = null;

                    if (pagesize != 0 && pageindex != 0 && PictureTypeId != "")
                    {
                        dr = SqlGet(conn, table, field, fieldkey, str, strkey, strKey, para, pagesize, pageindex);
                    }
                    else if (PictureTypeId != "")
                    {
                        dr = SqlGet(conn, table, field, strKey, para);
                    }

                    IList<Model.PictureInfo> list = new List<Model.PictureInfo>();
                    while (dr.Read())
                    {
                        Model.PictureInfo pict = new Model.PictureInfo();
                        pict.PictureId = Convert.ToInt32(dr["PictureId"]);
                        pict.PictureName = dr["PictureName"].ToString();
                        pict.PictureContent = dr["PictureContent"].ToString();
                        pict.PictureImg = dr["PictureImg"].ToString();
                        pict.PictureTypeId = dr["PictureTypeId"].ToString();
                        pict.PictureDate = Convert.ToDateTime(dr["PictureDate"]);
                        pict.Adduser = Convert.ToInt32(dr["Adduser"]);


                        list.Add(pict);
                    }
                    dr.Close();
                    return list;
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PictureInfo[public static IList<Model.PictureInfo> Get(int pagesize, int pageindex, string PictureTypeId)],错误信息：{0}", ex.ToString()));
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
        public static int Del(int PictureId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbName))
                {

                    string field = "PictureId=@PictureId";
                    SqlParameter[] para ={
                                           new SqlParameter("@PictureId",PictureId)
                                        };

                    return SqlDel(conn, table, field, para);
                }
            }
            catch (Exception ex)
            {
                DAL.ErrorInfo.AddError(string.Format("错误地址:DAL.PictureInfo[public static int Del(int PictureId)],错误信息：{0}", ex.ToString()));
                throw;
            }
        }

        #endregion
        #endregion

    }
}
