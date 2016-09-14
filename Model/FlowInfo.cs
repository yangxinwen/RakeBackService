using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class FlowInfo
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _orderid;

        public string Orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        private string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private string _optypes;

        public string Optypes
        {
            get { return _optypes; }
            set { _optypes = value; }
        }
        private DateTime _createtime;

        public DateTime Createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        private string _info;

        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
    }
}
