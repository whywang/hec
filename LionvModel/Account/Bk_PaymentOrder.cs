using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class Bk_PaymentOrder
    { 
        #region Model
        private int _id;
        private string _sid = "";
        private string _pcode = "";
        private string _bankname = "";
        private string _baccount = "";
        private string _bperson = "";
        private decimal _bmoney = 0;
        private string _gbank = "";
        private string _gaccount = "";
        private string _bremark = "";
        private string _pdate;
        private string _pmethod = "";
        private string _pimg = "";
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
        public string bankname
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string baccount
        {
            set { _baccount = value; }
            get { return _baccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bperson
        {
            set { _bperson = value; }
            get { return _bperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bmoney
        {
            set { _bmoney = value; }
            get { return _bmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gbank
        {
            set { _gbank = value; }
            get { return _gbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gaccount
        {
            set { _gaccount = value; }
            get { return _gaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bremark
        {
            set { _bremark = value; }
            get { return _bremark; }
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
        public string pmethod
        {
            set { _pmethod = value; }
            get { return _pmethod; }
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
