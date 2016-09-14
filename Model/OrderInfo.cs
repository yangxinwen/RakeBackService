using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    /// <summary>
    /// OrderInfo:订单实体类
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrderInfo
    {
        private int _id;

        [DataMember]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _orderId;
        [DataMember]

        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private string _batchNo;
        [DataMember]

        public string BatchNo
        {
            get { return _batchNo; }
            set { _batchNo = value; }
        }
        private string _amount;
        [DataMember]

        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private DateTime _createTime;//创建时间
        [DataMember]

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
     
        private DateTime _submitTime;//审核提交时间
        [DataMember]

        public DateTime SubmitTime
        {
            get { return _submitTime; }
            set { _submitTime = value; }
        }
        private string _batchContent;
        [DataMember]

        public string BatchContent
        {
            get { return _batchContent; }
            set { _batchContent = value; }
        }
        private int _uid;
        [DataMember]

        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        private string _orderStatus;//1为新建 2为已浏览 3为已返回成功 4为已返回失败 5为银行处理中 6为已审核 已审核后的单才能提交发起提现
        [DataMember]

        public string OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        private string _remark;
        [DataMember]

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _iseable;//0为已删除 1为已启用
        [DataMember]

        public string Iseable
        {
            get { return _iseable; }
            set { _iseable = value; }
        }
        private DateTime _updateTime;
        [DataMember]

        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        private string _createBank;
        [DataMember]

        public string CreateBank
        {
            get { return _createBank; }
            set { _createBank = value; }
        }
        private string _branchBank;

        [DataMember]
        public string BranchBank
        {
            get { return _branchBank; }
            set { _branchBank = value; }
        }
        private string _branchBankZH;
        [DataMember]

        public string BranchBankZH
        {
            get { return _branchBankZH; }
            set { _branchBankZH = value; }
        }
        private string _bankNumber;
        [DataMember]

        public string BankNumber
        {
            get { return _bankNumber; }
            set { _bankNumber = value; }
        }
        private string _belongTo;
        [DataMember]

        public string BelongTo
        {
            get { return _belongTo; }
            set { _belongTo = value; }
        }
        private string _api;
        [DataMember]

        public string Api
        {
            get { return _api; }
            set { _api = value; }
        }

        private string _userName;
        [DataMember]

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _loginId;
        [DataMember]

        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }
        private string _inputPerson;
        [DataMember]

        public string InputPerson
        {
            get { return _inputPerson; }
            set { _inputPerson = value; }
        }

        private string _status;
        [DataMember]

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
