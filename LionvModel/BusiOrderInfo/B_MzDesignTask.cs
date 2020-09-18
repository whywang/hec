using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
  public  class B_MzDesignTask
    {
         
        #region Model
        private int _id;
        private string _sid;
        private string _designer;
        private int _dstate = 0;
        private bool _curstate = false;
        private string _maker = "‘’";
        private string _bdate;
        private string _edate;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string designer
        {
            set { _designer = value; }
            get { return _designer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dstate
        {
            set { _dstate = value; }
            get { return _dstate; }
        }
        /// <summary>
        /// 是否为选择设计师
        /// </summary>
        public bool curstate
        {
            set { _curstate = value; }
            get { return _curstate; }
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
        public string bdate
        {
            set { _bdate = value; }
            get { return _bdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string edate
        {
            set { _edate = value; }
            get { return _edate; }
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
