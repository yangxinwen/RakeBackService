using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProductInfo
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
                return DAL.ProductInfo.Add(prod);
            }
            catch (Exception)
            {

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
                return DAL.ProductInfo.Edit(prod);
            }
            catch (Exception)
            {

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
                return DAL.ProductInfo.Get(ProductId);
            }
            catch (Exception)
            {

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
                return DAL.ProductInfo.Get(pagesize, pageindex);
            }
            catch (Exception)
            {

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
                return DAL.ProductInfo.Del(ProductId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #endregion

    }
}
