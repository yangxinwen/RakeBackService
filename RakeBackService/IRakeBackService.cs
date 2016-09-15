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
        /// 添加返佣
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<bool> AddRakeBack(OrderInfo info);


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


        /// <summary>
        /// 更新返佣信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<bool> UpdateOrderInfo(OrderInfo info);

        /// <summary>
        /// 删除返佣信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<bool> DelOrderInfo(OrderInfo info);

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<UserInfo> Login(string loginCode,string password);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<bool> UpdateUserPassword(int userId,string oldPwd,string newPwd);

        /// <summary>
        /// 获取返佣统计信息
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [OperationContract]
        ResponseBase<Tuple<string, string>> GetAmountStatistics(Dictionary<string, string> conditions);

    }
}
