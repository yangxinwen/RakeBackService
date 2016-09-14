using System;
using System.Collections.Generic;
namespace BLL
{

    public class UserInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.UserInfo user)
        {
            try
            {
                return DAL.UserInfo.Add(user);
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
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Edit(Model.UserInfo user)
        {
            try
            {
                return DAL.UserInfo.Edit(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 按照UserId读取一条信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static Model.UserInfo Get(int UserId)
        {
            try
            {
                return DAL.UserInfo.Get(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 按照loginId读取一条信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static Model.UserInfo GetByLoginId(string loginId)
        {
            try
            {
                return DAL.UserInfo.GetByLoginId(loginId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.UserInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                return DAL.UserInfo.Get(pagesize, pageindex,dic);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserLogin">登录名称</param>
        /// <param name="UserPwdMD5">登录密码</param>
        /// <returns></returns>
        public static Model.UserInfo Get(string loginId, string userPwd)
        {
            try
            {
                return DAL.UserInfo.Get(loginId, userPwd);
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
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static int Del(int UserId)
        {
            try
            {
                return DAL.UserInfo.Del(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}

