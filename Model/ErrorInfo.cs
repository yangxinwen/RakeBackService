using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ErrorInfo
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private DateTime _createtime;

        public DateTime Createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
    }
}
