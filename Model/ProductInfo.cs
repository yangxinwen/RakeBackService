using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class ProductInfo
    {


        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ProductImg { get; set; }
        /// <summary>
        /// 录入时期
        /// </summary>
        public DateTime ProductDate { get; set; }
        /// <summary>
        /// 是否启用 0启用 1不启用 （默认0）
        /// </summary>
        public int IsEnable { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public int ProductTypeId { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public int AddUser { get; set; }
        /// <summary>
        /// 产品介绍
        /// </summary>
        public string ProductContent { get; set; }


    }
}
