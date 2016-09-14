using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class OperInfo
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
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
