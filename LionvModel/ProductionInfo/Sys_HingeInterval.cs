using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
  public  class Sys_HingeInterval
    {
        #region Model
        private int _id;
        private string _hname = "";
        private string _hcode;
        private int  _lv = 0;
        private int  _tv = 0;
        private int  _iv = 0;
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
        public string hname
        {
            set { _hname = value; }
            get { return _hname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hcode
        {
            set { _hcode = value; }
            get { return _hcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lv
        {
            set { _lv = value; }
            get { return _lv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tv
        {
            set { _tv = value; }
            get { return _tv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  iv
        {
            set { _iv = value; }
            get { return _iv; }
        }
        #endregion Model
    }
}
