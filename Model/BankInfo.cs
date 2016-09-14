using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class BankInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string bankName;

        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
        private string bankValue;

        public string BankValue
        {
            get { return bankValue; }
            set { bankValue = value; }
        }
    }
}
