﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 回应基类
    /// </summary>
    [DataContract]
    public class ResponseBase<T>
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public T Content { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }
    }
}
