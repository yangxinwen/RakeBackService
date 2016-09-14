using System;
using System.Collections.Generic;
namespace BLL
{
    public class RoleInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static int Add(Model.RoleInfo role)
        {
            try
            {
                return DAL.RoleInfo.Add(role);
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
        /// <param name="role"></param>
        /// <returns></returns>
        public static int Edit(Model.RoleInfo role)
        {
            try
            {
                return DAL.RoleInfo.Edit(role);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照RoleId读取一条信息
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static Model.RoleInfo Get(int RoleId)
        {

            try
            {
                return DAL.RoleInfo.Get(RoleId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 读取全部信息
        /// </summary>
        /// <returns></returns>
        public static IList<Model.RoleInfo> Get()
        {
            try
            {
                return DAL.RoleInfo.Get();
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
        /// <returns></returns>
        public static int Del(int RoleId)
        {
            try
            {
                return DAL.RoleInfo.Del(RoleId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}

