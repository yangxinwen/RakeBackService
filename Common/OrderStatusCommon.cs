using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public enum OrderStatusCommon
    {
        /// <summary>
        /// 新单
        /// </summary>
        New = 1,

        /// <summary>
        /// IE已浏览
        /// </summary>
        IEOpen = 2,

        /// <summary>
        /// 银行已返回成功
        /// </summary>
        BankRetOK = 3,

        /// <summary>
        /// 银行已返回失败
        /// </summary>
        BankRetErr = 4,

        /// <summary>
        /// 银行处理中
        /// </summary>
        BankDoing=5,

        /// <summary>
        /// 已审核
        /// </summary>
        Examine = 6,
    }
}
