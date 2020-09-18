using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_SaleChangeOrder
    {
        #region
        private int _id;
        private string _osid = "";
        private string _sid;
        private string _oscode = "";
        private string _sqcode = "";
        private string _scode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _address = "";
        private string _community = "";
        private string _aname = "";
        private string _acode = "";
        private string _e_city = "";
        private string _e_citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _bdcode = "";
        private string _otype = "";
        private string _saletelephone = "";
        private string _mname = "";
        private string _remark = "";
        private string _zbremark = "";
        private string _mtype = "";
        private string _qbcode = "";
        private string _clperson = "";
        private string _azperson = "";
        private string _saddress = "";
        private string _source = "";
        private string _ydate;
        private string _sname = "";
        private string _qtimg = "";
        private string _colorpane = "";
        private string _creason = "";
        private string _maker = "";
        private string _cdate;
        private string _hasproduction = "0";
        private decimal _ccost = 0;
        private string _pjd = "";
        private string _cremark = "";

        public string cremark
        {
            get { return _cremark; }
            set { _cremark = value; }
        }

        public string pjd
        {
            get { return _pjd; }
            set { _pjd = value; }
        }

        public decimal ccost
        {
            get { return _ccost; }
            set { _ccost = value; }
        }

        // 是否产品已更改
        public string hasproduction
        {
            get { return _hasproduction; }
            set { _hasproduction = value; }
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
        public string oscode
        {
            set { _oscode = value; }
            get { return _oscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sqcode
        {
            set { _sqcode = value; }
            get { return _sqcode; }
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
        public string community
        {
            set { _community = value; }
            get { return _community; }
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
        public string e_city
        {
            set { _e_city = value; }
            get { return _e_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_citycode
        {
            set { _e_citycode = value; }
            get { return _e_citycode; }
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
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
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
        public string saletelephone
        {
            set { _saletelephone = value; }
            get { return _saletelephone; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zbremark
        {
            set { _zbremark = value; }
            get { return _zbremark; }
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
        public string qbcode
        {
            set { _qbcode = value; }
            get { return _qbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string clperson
        {
            set { _clperson = value; }
            get { return _clperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string azperson
        {
            set { _azperson = value; }
            get { return _azperson; }
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
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydate
        {
            set { _ydate = value; }
            get { return _ydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
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
        public string colorpane
        {
            set { _colorpane = value; }
            get { return _colorpane; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string creason
        {
            set { _creason = value; }
            get { return _creason; }
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
