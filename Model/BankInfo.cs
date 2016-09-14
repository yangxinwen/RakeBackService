using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [Serializable]
    [DataContract]
    public class BankInfo
    {
        private int id;
        [DataMember]

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string bankName;
        [DataMember]

        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
        private string bankValue;
        [DataMember]

        public string BankValue
        {
            get { return bankValue; }
            set { bankValue = value; }
        }
    }
}
