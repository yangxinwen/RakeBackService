using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    [ServiceContract]
    public interface IRakeBackService
    {
        /// <summary>
        /// 获取新建返佣的数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        //[OperationContract]
        //ResponseBase GetNewRakeBack(int pageSize,int pageIndex,Dictionary<string,string> conditions);



        /// <summary>
        /// 获取新建返佣的数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<IList<UserInfo>> GetNewRakeBack(int pageSize, int pageIndex, Dictionary<string, string> conditions);


        /// <summary>
        /// 获取返佣的数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<IList<OrderInfo>> GetRakeBack(int pageSize, int pageIndex, Dictionary<string, string> conditions);


        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<IList<RoleInfo>> GetRoleInfo();


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<IList<UserInfo>> GetUserInfo(int pageSize, int pageIndex, Dictionary<string, string> conditions);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<UserInfo> AddUserInfo(UserInfo info);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<UserInfo> UpdateUserInfo(UserInfo info);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<bool> DelUserInfo(int id);

    }
}
