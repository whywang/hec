using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.WxChat
{
    public  class Sys_EmplyeeFouseWx
    {
        #region Model
        private int _id;
        private string _ename = "";
        private string _openid = "";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string openid
        {
            set { _openid = value; }
            get { return _openid; }
        }
        #endregion Model
    }
}
