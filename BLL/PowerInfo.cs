using System;
using System.Collections.Generic;
namespace BLL
{

    public class PowerInfo
    {

        #region 操作

        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="power">Power实体类</param>
        /// <returns>int</returns>
        public static int Add(Model.PowerInfo power)
        {
            try
            {
                return DAL.PowerInfo.Add(power);
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
        /// <param name="power">Power实体类</param>
        /// <returns>int</returns>
        public static int Edit(Model.PowerInfo power)
        {
            try
            {
                return DAL.PowerInfo.Edit(power);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get

        /// <summary>
        /// 按照PowerId读取一条信息
        /// </summary>
        /// <param name="PowerId"></param>
        /// <returns></returns>
        public static Model.PowerInfo Get(int PowerId)
        {
            try
            {
                return DAL.PowerInfo.Get(PowerId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns></returns>
        public static IList<Model.PowerInfo> Get()
        {
            try
            {
                return DAL.PowerInfo.Get();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 按照PowerId进行IN查询
        /// </summary>
        /// <param name="PowerStr"></param>
        /// <returns></returns>
        public static IList<Model.PowerInfo> Get(string PowerStr,int MenuId,int IsLeft)
        {
            try
            {
                return DAL.PowerInfo.Get(PowerStr,MenuId,IsLeft);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 按照MenuId进行查询
        /// </summary>
        /// <param name="PowerStr"></param>
        /// <returns></returns>
        public static IList<Model.PowerInfo> GetMenuId(int MenuId)
        {
            try
            {
                return DAL.PowerInfo.GetMenuId(MenuId);
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
        /// <param name="PowerId"></param>
        /// <returns></returns>
        public static int Del(int PowerId)
        {
            try
            {
                return DAL.PowerInfo.Del(PowerId);
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

