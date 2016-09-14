using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BankInfo
    {
        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns>IList</returns>
        public static IList<Model.BankInfo> Get()
        {
            try
            {
                return DAL.BankInfo.Get();
            }
            catch (Exception)
            {

                throw;
            }
        }        
    }
}
