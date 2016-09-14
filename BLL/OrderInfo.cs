using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OrderInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.OrderInfo order)
        {
            try
            {
                return DAL.OrderInfo.Add(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Edit(Model.OrderInfo order)
        {
            try
            {
                return DAL.OrderInfo.Edit(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Del(Model.OrderInfo order)
        {
            try
            {
                return DAL.OrderInfo.Del(order);
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
        public static Model.OrderInfo Get(int orderId)
        {
            try
            {
                return DAL.OrderInfo.Get(orderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

         /// <summary>
        /// 统计金额
        /// </summary>
        /// <param name="dic">查询条件</param>
        /// <returns></returns>
        public static string AmountStatistics(Dictionary<string, string> dic)
        {
            try
            {
                return DAL.OrderInfo.AmountStatistics(dic);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 统计订单笔数
        /// </summary>
        /// <param name="dic">查询条件</param>
        /// <returns></returns>
        public static string AmountStatisticsCount(Dictionary<string, string> dic)
        {
            try
            {
                return DAL.OrderInfo.AmountStatisticsCount(dic);

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
        public static IList<Model.OrderInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                return DAL.OrderInfo.Get(pagesize, pageindex, dic);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
