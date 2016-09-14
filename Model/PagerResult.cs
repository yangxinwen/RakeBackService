using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 返回分页查询结果
    /// </summary>
    [Serializable]
    public class PagerResult<T>
    {
        public int Count { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public T Content { get; set; }
    }
}
