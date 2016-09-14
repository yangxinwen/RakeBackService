using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace BLL
{
    public class FlowInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.FlowInfo flow)
        {
            try
            {
                return DAL.FlowInfo.Add(flow);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        public static void AddFlow(string Info, string optypes, string orderid)
        {
            //写入流水
            Model.FlowInfo fm = new Model.FlowInfo();
            fm.Orderid = orderid;
            fm.Ip = HttpContext.Current.Request.UserHostAddress.ToString();
            fm.Optypes = optypes;
            fm.Createtime = DateTime.Now;
            fm.Info = Info;            
            Add(fm);
        }


        #region Get
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static IList<Model.FlowInfo> Get(int pagesize, int pageindex, Dictionary<string, string> dic)
        {
            try
            {
                return DAL.FlowInfo.Get(pagesize, pageindex, dic);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
