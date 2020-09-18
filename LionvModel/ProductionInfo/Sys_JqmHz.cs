using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
  public  class Sys_JqmHz
    {
        #region Model
        private int _id;
        private string _hzname = "";
        private string _hzcode;
        private string _mcode = "";
        private string _maker = "";
        private string _cdate = "";
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
        public string hzname
        {
            set { _hzname = value; }
            get { return _hzname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hzcode
        {
            set { _hzcode = value; }
            get { return _hzcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        #endregion Model
    }
}
