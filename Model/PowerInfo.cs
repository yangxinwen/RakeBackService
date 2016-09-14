using System;
namespace Model
{
    /// <summary>
    /// PowerInfo:权限实体类
    /// </summary>
    [Serializable]
    public partial class PowerInfo
    {
        public PowerInfo()
        { }
        #region Model
        private int _powerid;
        private string _powername;
        private int _menuid;
        private int _isenable = 0;
        private string _remark = "暂无备注";
        private DateTime _powerdate;
        private int _adduser;
        /// <summary>
        /// 是否左侧显示 0显示 1不显示
        /// </summary>
        public int IsLeft { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerId
        {
            set { _powerid = value; }
            get { return _powerid; }
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName
        {
            set { _powername = value; }
            get { return _powername; }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
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
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime PowerDate
        {
            set { _powerdate = value; }
            get { return _powerdate; }
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
        /// 序号
        /// </summary>
        public int OrderNum
        {
            get;
            set;
        }

        private string pageurl;
        /// <summary>
        /// 页面Url
        /// </summary>
        public string PageUrl
        {
            get { return pageurl; }
            set { pageurl = value; }
        }

        #endregion Model

    }
}

