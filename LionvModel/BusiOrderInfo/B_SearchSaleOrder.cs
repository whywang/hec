using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_SearchSaleOrder
    {
        #region Model
        private int _id;
        private string _csid = "";
        private string _sid = "";
        private string _ccode = "";
        private string _wcode = "";
        private string _scode = "";
        private string _otype = "";
        private string _dname = "";
        private string _dcode = "";
        private string _cityname = "";
        private string _customer = "";
        private string _telephone = "";
        private string _address = "";
        private string _mname = "";
        private string _remake = "";
        private string _factoryname;
        private string _factorycode;
        private decimal _gmoney = 0;
        private decimal _dmoney = 0;
        private int _ostate = 0;
        private string _pdate;
        private string _maker;
        private string _cdate;
        private string _fixs;
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
        public string csid
        {
            set { _csid = value; }
            get { return _csid; }
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
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        public string fixs
        {
            set { _fixs = value; }
            get { return _fixs; }
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
        public string cityname
        {
            set { _cityname = value; }
            get { return _cityname; }
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remake
        {
            set { _remake = value; }
            get { return _remake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string factoryname
        {
            set { _factoryname = value; }
            get { return _factoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string factorycode
        {
            set { _factorycode = value; }
            get { return _factorycode; }
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
        public decimal dmoney
        {
            set { _dmoney = value; }
            get { return _dmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ostate
        {
            set { _ostate = value; }
            get { return _ostate; }
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
