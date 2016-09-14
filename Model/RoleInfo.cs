using System;
namespace Model
{
	/// <summary>
	/// RoleInfo:角色实体类
	/// </summary>
	[Serializable]
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _powerstr;
		private int  _isenable=0;
		private string _remark="暂无备注";
		private DateTime  _roledate;
		private int  _adduser;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 权限字符串
		/// </summary>
		public string PowerStr
		{
			set{ _powerstr=value;}
			get{return _powerstr;}
		}
		/// <summary>
        /// 是否启用 0启用 1不启用（默认0）
        /// </summary>
		public int  IsEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime  RoleDate
		{
			set{ _roledate=value;}
			get{return _roledate;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public int  AddUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		#endregion Model

	}
}

