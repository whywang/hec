using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
  public  class Sys_WorkLine
    {
        #region Model
        private int _id;
        private string _wname = "";
        private string _wcode="";
        private string _wcname = "";
        private string _wccode = "";
        private string _wrattr = "";
        private int _wrlv = 0;
        private int _wrtv = 0;
        private string _wrtype = "";
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
        public string wname
        {
            set { _wname = value; }
            get { return _wname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcname
        {
            set { _wcname = value; }
            get { return _wcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wccode
        {
            set { _wccode = value; }
            get { return _wccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wrattr
        {
            set { _wrattr = value; }
            get { return _wrattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wrlv
        {
            set { _wrlv = value; }
            get { return _wrlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int wrtv
        {
            set { _wrtv = value; }
            get { return _wrtv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wrtype
        {
            set { _wrtype = value; }
            get { return _wrtype; }
        }
        #endregion Model
    }
}
