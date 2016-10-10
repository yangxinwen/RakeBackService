using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 升级信息
    /// </summary>
    [DataContract]
    public class UpdateInfo
    {
        /// <summary>
        /// 是否需要提示升级
        /// </summary>
        [DataMember]
        public bool IsNeedUpdate { get; set; }
        /// <summary>
        /// 最新版本号
        /// </summary>
        [DataMember]
        public string NewVersion { get; set; }
        /// <summary>
        /// 是否需要强制升级
        /// </summary>
        [DataMember]
        public bool IsForceUpdate { get; set; }
        /// <summary>
        /// 客户端升级地址
        /// </summary>
        [DataMember]
        public  string UpdateUrl { get; set; }
    }
}
