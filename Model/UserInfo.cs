using System;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// UserInfo:用户实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class UserInfo
    {
        public UserInfo()
        { }
        #region Model
        private int _userId;

        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _userName;//用户姓名

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _userPhone;//手机号码

        [DataMember]
        public string UserPhone
        {
            get { return _userPhone; }
            set { _userPhone = value; }
        }
        private string _userPwd;//密码

        [DataMember]
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
        private string _remark;//备注

        [DataMember]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _roleId;//权限

        [DataMember]
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        private string _loginId;//登陆账号

        [DataMember]
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }
        private string _createBank;//开户银行

        [DataMember]
        public string CreateBank
        {
            get { return _createBank; }
            set { _createBank = value; }
        }
        private string _branchBank;//分行

        [DataMember]
        public string BranchBank
        {
            get { return _branchBank; }
            set { _branchBank = value; }
        }
        private string _branchBankZH;//支行

        [DataMember]
        public string BranchBankZH
        {
            get { return _branchBankZH; }
            set { _branchBankZH = value; }
        }
        private string _bankNumber;//银行卡号

        [DataMember]
        public string BankNumber
        {
            get { return _bankNumber; }
            set { _bankNumber = value; }
        }
        private string _belongTo;//定值

        [DataMember]
        public string BelongTo
        {
            get { return _belongTo; }
            set { _belongTo = value; }
        }
        private string _createtime;//创建时间

        [DataMember]
        public string Createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        private string _updatetime;//修改时间

        [DataMember]
        public string Updatetime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
       
        private string _api;//开户银行对应的代码

        [DataMember]
        public string Api
        {
            get { return _api; }
            set { _api = value; }
        }
        private string _isUpdatePass;//是否修改了密码

        [DataMember]
        public string IsUpdatePass
        {
            get { return _isUpdatePass; }
            set { _isUpdatePass = value; }
        }

        private string _inputPerson;//操作人员

        [DataMember]
        public string InputPerson
        {
            get { return _inputPerson; }
            set { _inputPerson = value; }
        }

        private string _iseable;//1可用 0不可用

        [DataMember]
        public string Iseable
        {
            get { return _iseable; }
            set { _iseable = value; }
        }

        private string _province;//开户省

        [DataMember]
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _city;//开户市

        [DataMember]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _menuId;//管理员权限

        [DataMember]
        public string MenuId
        {
            get { return _menuId; }
            set { _menuId = value; }
        }

        #endregion Model

    }
}

