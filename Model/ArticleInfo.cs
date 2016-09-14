using System;
namespace Model
{
    /// <summary>
    /// ArticleInfo:文章实体类
    /// </summary>
    [Serializable]
    public partial class ArticleInfo
    {
        public ArticleInfo()
        { }
        #region Model
        private int _articleid;
        private string _articletitle;
        private string _articlecontent;
        private DateTime _articledate;
        private string _author;
        private int _isenable = 0;
        private int _istop = 1;
        private int _isnew = 1;
        private int _ishot = 1;
        private string _remark = "暂无备注";
        private int _adduser;
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ArticleId
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArticleTitle
        {
            set { _articletitle = value; }
            get { return _articletitle; }
        }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string ArticleContent
        {
            set { _articlecontent = value; }
            get { return _articlecontent; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ArticleDate
        {
            set { _articledate = value; }
            get { return _articledate; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 是否启用 0启用 1不启用（默认0）
        /// </summary>
        public int IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 是否置顶 0置顶 1不置顶（默认1）
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否加注“New”标记 0加注 1不加注（默认1）
        /// </summary>
        public int IsNew
        {
            set { _isnew = value; }
            get { return _isnew; }
        }
        /// <summary>
        /// 是否加注“Hot”标记 0加注 1不加注（默认1）
        /// </summary>
        public int IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }

        /// <summary>
        /// 菜单ID（外键）
        /// </summary>
        public int MenuId { get; set; }

        #endregion Model

    }
}

