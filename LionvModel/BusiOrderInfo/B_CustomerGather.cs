using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_CustomerGather
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
        public string gdate
        {
            set { _gdate = value; }
            get { return _gdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        #endregion Model
    }
}
