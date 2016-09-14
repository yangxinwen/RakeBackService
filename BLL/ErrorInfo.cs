using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ErrorInfo
    {
        #region Add
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int Add(Model.ErrorInfo ei)
        {
            try
            {
                return DAL.ErrorInfo.Add(ei);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
