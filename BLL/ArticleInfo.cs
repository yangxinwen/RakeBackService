using System;
using System.Collections.Generic;
namespace BLL
{

    public class ArticleInfo
    {

        #region 操作
        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static int Add(Model.ArticleInfo article)
        {
            try
            {
                return DAL.ArticleInfo.Add(article);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        public static int Edit(Model.ArticleInfo article)
        {
            try
            {
                return DAL.ArticleInfo.Edit(article);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// ArticleId查询
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static Model.ArticleInfo Get(int ArticleId)
        {
            try
            {
                return DAL.ArticleInfo.Get(ArticleId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 分页
        /// 四中查询
        /// 1.若pagesize pageindex MenuId 全部不等于0，则是按照MenuId分页查询
        /// 2.若pagesize pageindex  全部不等于0，则是基本分页查询
        /// 3.若MenuId不等于0，则是按照MenuId查询
        /// 4.若是没有出现前三种情况，则是查询全部
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <param name="MenuId">查询条件</param>
        /// <returns></returns>

        public static IList<Model.ArticleInfo> Get(int pagesize, int pageindex, int MenuId)
        {
            try
            {
                return DAL.ArticleInfo.Get(pagesize, pageindex, MenuId);
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
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static int Del(int ArticleId)
        {
            try
            {
                return DAL.ArticleInfo.Del(ArticleId);
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

