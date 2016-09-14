using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{



    public class PictureInfo
    {

        #region 操作

        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(Model.PictureInfo pict)
        {
            try
            {
                return DAL.PictureInfo.Add(pict);
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
        public static int Edit(Model.PictureInfo pict)
        {
            try
            {
                return DAL.PictureInfo.Edit(pict);
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
        public static Model.PictureInfo Get(int PictureId)
        {
            try
            {
                return DAL.PictureInfo.Get(PictureId);
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
        public static IList<Model.PictureInfo> Get(int pagesize, int pageindex, string  PictureTypeId)
        {
            try
            {
                return DAL.PictureInfo.Get(pagesize, pageindex, PictureTypeId);
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
        public static int Del(int PictureId)
        {
            try
            {
                return DAL.PictureInfo.Del(PictureId);
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
