﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_FeedBackImg
    {
        public B_FeedBackImg()
        { }
        #region Model
        private int _id;
        private string _iname = "";
        private string _url = "";
        private string _sid = "";
        private string _maker = "";
        private string _remark = "";
        private string _cdate;
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
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
