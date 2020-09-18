using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
  public  class CB_OrderProduceProcess
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _jdname = "";
        private string _jdcode = "";
        private string _ydate;
        private string _odate;
        private string _jtype = "";
        private int _jsort = 0;
        private int _jstate = 0;
        private string _cdate;
        private string _maker = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jdname
        {
            set { _jdname = value; }
            get { return _jdname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jdcode
        {
            set { _jdcode = value; }
            get { return _jdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydate
        {
            set { _ydate = value; }
            get { return _ydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string odate
        {
            set { _odate = value; }
            get { return _odate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int jsort
        {
            set { _jsort = value; }
            get { return _jsort; }
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
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jtype
        {
            set { _jtype = value; }
            get { return _jtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int jstate
        {
            set { _jstate = value; }
            get { return _jstate; }
        }
        #endregion Model

    }
}
