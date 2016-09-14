using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ArticleTypeInfo
    {


        /// <summary>
        /// 文章类别Id
        /// </summary>
        public int ArticleTypeId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string ArticleTypeName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime ArticleTypeDate { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddUser { get; set; }

    }
}
