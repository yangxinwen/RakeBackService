using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ArticleTypeInfo
    {
        #region 操作

      
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(Model.ArticleTypeInfo artictype)
        {
            try
            {
                return DAL.ArticleTypeInfo.Add(artictype);
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
        /// <param name="artictype"></param>
        /// <returns></returns>
        public static int Edit(Model.ArticleTypeInfo artictype)
        {
            try
            {
                return DAL.ArticleTypeInfo.Edit(artictype);


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Get
        /// <summary>
        ///ArticleTypeId查询
        /// </summary>
        /// <returns></returns>
        public static Model.ArticleTypeInfo Get(int ArticleTypeId)
        {
            try
            {
                return DAL.ArticleTypeInfo.Get(ArticleTypeId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public static IList<Model.ArticleTypeInfo> Get()
        {
            try
            {
                return DAL.ArticleTypeInfo.Get();
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
        /// <param name="ArticleTypeId"></param>
        /// <returns></returns>
        public static int Del(int ArticleTypeId)
        {
            try
            {
                return DAL.ArticleTypeInfo.Del(ArticleTypeId);
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
