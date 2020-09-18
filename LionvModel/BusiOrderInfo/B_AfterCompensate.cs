using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_AfterCompensate
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _customer = "";
        private string _scode = "";
        private string _telephone = "";
        private string _address = "";
        private string _reason = "";
        private string _cljg = "";
        private decimal _pmoney = 0M;
        private int _pstate = 0;
        private string _qtreason = "";
        private string _maker = "";
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
        public string customer
        {
            set { _customer = value; }
            get { return _customer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qtreason
        {
            set { _qtreason = value; }
            get { return _qtreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cljg
        {
            set { _cljg = value; }
            get { return _cljg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pmoney
        {
            set { _pmoney = value; }
            get { return _pmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pstate
        {
            set { _pstate = value; }
            get { return _pstate; }
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
