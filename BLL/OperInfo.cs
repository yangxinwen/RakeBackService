using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace BLL
{
    public class OperInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.OperInfo oper)
        {
            try
            {
                return DAL.OperInfo.Add(oper);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static int Add(int userId,string userName, string info)
        {
            try
            {
                var oper= new Model.OperInfo();

                //提供方法执行的上下文环境
                OperationContext context = OperationContext.Current;
                //获取传进的消息属性
                MessageProperties properties = context.IncomingMessageProperties;
                //获取消息发送的远程终结点IP和端口
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                
                oper.Createtime = DateTime.Now;
                oper.Ip = endpoint.Address;
                oper.UserId = userId;
                oper.UserName = userName;
                oper.Info = info;
                return DAL.OperInfo.Add(oper);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.OperInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                return DAL.OperInfo.Get(pagesize, pageindex, dic);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
