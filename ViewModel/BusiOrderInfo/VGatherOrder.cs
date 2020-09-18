using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
   public class VGatherOrder
    {
        #region Model
        private int _id;
        private string _sid;
        private decimal _gmoney = 0;
        private string _gmethod = "";
        private string _remark = "";
        private string _gperson = "";
        private string _cdate;
        private string _gdate;
        private string _maker = "";
        private string _customer = "";

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _wcode = "";

        public string wcode
        {
            get { return _wcode; }
            set { _wcode = value; }
        }
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
        public decimal gmoney
        {
            set { _gmoney = value; }
            get { return _gmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gmethod
        {
            set { _gmethod = value; }
            get { return _gmethod; }
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
        public string gperson
        {
            set { _gperson = value; }
            get { return _gperson; }
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
        public string gdate
        {
            set { _gdate = value; }
            get { return _gdate; }
        }
        #endregion Model
    }
}
