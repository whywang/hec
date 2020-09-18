using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class Sbk_Account
    {
        #region Model
        private int _id;
        private string _acode;
        private string _aname = "";
        private string _dname = "";
        private string _dcode = "";
        private string _manager = "";
        private string _telephone = "";
        private string _atype = "";
        private decimal _credit = 0M;
        private decimal _ucredit = 0M;
        private decimal _umoney = 0M;
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
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
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
        public string manager
        {
            set { _manager = value; }
            get { return _manager; }
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
        public string atype
        {
            set { _atype = value; }
            get { return _atype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal credit
        {
            set { _credit = value; }
            get { return _credit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ucredit
        {
            set { _ucredit = value; }
            get { return _ucredit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal umoney
        {
            set { _umoney = value; }
            get { return _umoney; }
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
