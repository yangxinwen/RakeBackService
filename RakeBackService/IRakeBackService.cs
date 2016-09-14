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



        [OperationContract]
        UserInfo sdfsdf(int pageSize, int pageIndex, Dictionary<string, string> conditions);


    }
}
