using System;
using System.Collections.Generic;
namespace BLL
{

    public class MenuInfo
    {

        #region 操作
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menu">menu实体类</param>
        /// <returns>int</returns>
        public static int Add(Model.MenuInfo menu)
        {
            try
            {
                return DAL.MenuInfo.Add(menu);
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
        /// <param name="menu">menu实体类</param>
        /// <returns>int</returns>
        public static int Edit(Model.MenuInfo menu)
        {
            try
            {
                return DAL.MenuInfo.Edit(menu);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照MenuId查询
        /// </summary>
        /// <param name="MenuId">菜单Id</param>
        /// <returns>MenuInfo实体类</returns>
        public static Model.MenuInfo Get(int MenuId)
        {
            try
            {
                return DAL.MenuInfo.Get(MenuId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns>IList</returns>
        public static IList<Model.MenuInfo> Get()
        {
            try
            {
                return DAL.MenuInfo.Get();
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Del
        /// <summary>
        /// 按照MenuId删除
        /// </summary>
        /// <param name="MenuId">条件MenuId</param>
        /// <returns>int</returns>
        public static int Del(int MenuId)
        {
            try
            {
                return DAL.MenuInfo.Del(MenuId);
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

