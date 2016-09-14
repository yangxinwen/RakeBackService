using System;
namespace Model
{
    /// <summary>
    /// MenuInfo:菜单实体类
    /// </summary>
    [Serializable]
    public partial class MenuInfo
    {
        public MenuInfo()
        { }
        #region Model
        private int _menuid;
        private string _menuname;
        private int _isenable = 0;
        private string _remark = "暂无备注";
        private DateTime _menudate;
        private int _adduser;
       
        /// <summary>
        ///菜单ID 
        /// </summary>
        public int MenuId
        {
            set { _menuid = value; }
            get { return _menuid; }
        }
        /// <summary>
        /// 菜单名称    
        /// </summary>
        public string MenuName
        {
            set { _menuname = value; }
            get { return _menuname; }
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
        public DateTime MenuDate
        {
            set { _menudate = value; }
            get { return _menudate; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int AddUser
        {
            set { _adduser = value; }
            get { return _adduser; }
        }

        public int OrderNum { get; set; }
        #endregion Model

    }
}

