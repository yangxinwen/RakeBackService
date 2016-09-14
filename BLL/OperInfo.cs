using System;
using System.Collections.Generic;
using System.Linq;
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
