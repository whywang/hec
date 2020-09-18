using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_SaleMaterielOrder
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _scode = "";
        private string _otype = "";
        private string _aname = "";
        private string _acode = "";
        private string _city = "";
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private decimal _gdiscount = 0M;
        private string _wltype = "";
        private string _qtimg = "";
        private string _remark = "";
        private string _saddress = "";
        private string _stelephone = "";
        private string _bdcode = "";
        private string _sperson = "";
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
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
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
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citycode
        {
            set { _citycode = value; }
            get { return _citycode; }
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
        public decimal gdiscount
        {
            set { _gdiscount = value; }
            get { return _gdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wltype
        {
            set { _wltype = value; }
            get { return _wltype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qtimg
        {
            set { _qtimg = value; }
            get { return _qtimg; }
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
        public string saddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stelephone
        {
            set { _stelephone = value; }
            get { return _stelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sperson
        {
            set { _sperson = value; }
            get { return _sperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
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
