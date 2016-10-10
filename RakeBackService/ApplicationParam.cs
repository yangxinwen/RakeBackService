using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// 应用程序参数
    /// </summary>
    public class ApplicationParam
    {
        /// <summary>
        /// 出金地址
        /// </summary>
        public static string OutMoneyUrl { get; set; }
        /// <summary>
        /// b2c结算key
        /// </summary>
        public static string B2CSettleKey { get; set; }
        /// <summary>
        /// 客户端当前版本号
        /// </summary>
        public static string ClientVersion { get; set; }
        /// <summary>
        /// 客户端版本号不匹配是是否强制升级
        /// </summary>
        public static bool IsForceUpdate { get; set; }
        /// <summary>
        /// 客户端升级地址
        /// </summary>
        public static string UpdateUrl { get; set; }


        static ApplicationParam()
        {
            OutMoneyUrl = ConfigurationManager.AppSettings["OutMoneyUrl"].ToString();
            B2CSettleKey = ConfigurationManager.AppSettings["B2CSettleKey"].ToString();
            ClientVersion = ConfigurationManager.AppSettings["ClientVersion"].ToString();
            IsForceUpdate = ConfigurationManager.AppSettings["IsForceUpdate"].ToString().ToLower().Equals("true") ? true : false;
            UpdateUrl = ConfigurationManager.AppSettings["UpdateUrl"].ToString();
        }
    }
}
