using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class B_CityPayOrder
    {
        #region Model
        private int _id;
        private string _sid;
        private string _pcode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _caccount = "";
        private string _cbank = "";
        private string _cperson = "";
        private string _ctype = "";
        private string _cbcode = "";
        private string _pperson = "";
        private string _paccount = "";
        private string _pbank = "";
        private string _pbcode = "";
        private string _sacode = "";
        private string _pmethod = "";
        private string _pdate;
        private decimal _pmoney = 0M;
        private int _pstate = 0;
        private string _pimg;
        private string _remark = "";
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
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string caccount
        {
            set { _caccount = value; }
            get { return _caccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbank
        {
            set { _cbank = value; }
            get { return _cbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cperson
        {
            set { _cperson = value; }
            get { return _cperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pperson
        {
            set { _pperson = value; }
            get { return _pperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string paccount
        {
            set { _paccount = value; }
            get { return _paccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbank
        {
            set { _pbank = value; }
            get { return _pbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pmethod
        {
            set { _pmethod = value; }
            get { return _pmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pdate
        {
            set { _pdate = value; }
            get { return _pdate; }
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
        public string pimg
        {
            set { _pimg = value; }
            get { return _pimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public string cbcode
        {
            set { _cbcode = value; }
            get { return _cbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbcode
        {
            set { _pbcode = value; }
            get { return _pbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sacode
        {
            set { _sacode = value; }
            get { return _sacode; }
        }
        #endregion Model

    }
}
