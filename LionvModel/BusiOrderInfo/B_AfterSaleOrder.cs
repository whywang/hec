using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_AfterSaleOrder
    {
        #region Model
        private int _id;
        private string _osid = "";
        private string _sid = "";
        private string _fcode = "";
        private string _scode = "";
        private string _oscode = "";
        private string _pcode = "";
        private string _bdcode;
        private string _khcode;
        private string _customer = "";
        private string _telephone = "";
        private string _community = "";
        private string _address = "";
        private string _saddress = "";
        private string _aname = "";
        private string _acode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _city = "";
        private string _citytype = "";
        private string _citycode = "";
        private string _otype = "";
        private string _mtype = "";
        private string _atype = "";
        private string _mname = "";
        private string _source = "";
        private string _areason = "";
        private string _aduty = "";
        private string _method;
        private string _wlcompany = "";
        private string _qtimg = "";
        private decimal _omoney = 0M;
        private string _designer = "";
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
        public string osid
        {
            set { _osid = value; }
            get { return _osid; }
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
        public string fcode
        {
            set { _fcode = value; }
            get { return _fcode; }
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
        public string oscode
        {
            set { _oscode = value; }
            get { return _oscode; }
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
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string khcode
        {
            set { _khcode = value; }
            get { return _khcode; }
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
        public string community
        {
            set { _community = value; }
            get { return _community; }
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
        public string saddress
        {
            set { _saddress = value; }
            get { return _saddress; }
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
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citytype
        {
            set { _citytype = value; }
            get { return _citytype; }
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
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areason
        {
            set { _areason = value; }
            get { return _areason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aduty
        {
            set { _aduty = value; }
            get { return _aduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string method
        {
            set { _method = value; }
            get { return _method; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wlcompany
        {
            set { _wlcompany = value; }
            get { return _wlcompany; }
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
        public decimal omoney
        {
            set { _omoney = value; }
            get { return _omoney; }
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
        #endregion Model

    }
}
