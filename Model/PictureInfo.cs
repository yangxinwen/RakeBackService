using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class PictureInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int PictureId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string  PictureName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string  PictureContent { get; set; }
        /// <summary>
        /// 图片名字（含格式如123.jpg）
        /// </summary>
        public string  PictureImg { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string PictureTypeId { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime  PictureDate { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public int Adduser { get; set; }

    }
}
