using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public  class B_MeasureOrder
    {
        public B_MeasureOrder()
        { }
        #region Model
        private int _id;
        private string _sid;
        private string _osid = "";
        private string _scode = "";
        private string _sdcode = "";
        private string _zcode = "";
        private string _city = "";
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _address = "";
        private string _aprovince = "";
        private string _acity = "";
        private string _gzname = "";
        private string _gztelephone = "";
        private string _mname = "";
        private string _mdate ="";
        private string _mremark = "";
        private string _clperson = "";
        private string _qtimg = "";
        private string _maker = "";
        private string _cdate;
        private List<B_MeasureProduction> _bplist;
        private string _bpliststr = "";

        

        
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
        public string osid
        {
            set { _osid = value; }
            get { return _osid; }
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
        public string sdcode
        {
            set { _sdcode = value; }
            get { return _sdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zcode
        {
            set { _zcode = value; }
            get { return _zcode; }
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
        public string aprovince
        {
            set { _aprovince = value; }
            get { return _aprovince; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acity
        {
            set { _acity = value; }
            get { return _acity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gzname
        {
            set { _gzname = value; }
            get { return _gzname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gztelephone
        {
            set { _gztelephone = value; }
            get { return _gztelephone; }
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
        public string mdate
        {
            set { _mdate = value; }
            get { return _mdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mremark
        {
            set { _mremark = value; }
            get { return _mremark; }
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
        public string qtimg
        {
            set { _qtimg = value; }
            get { return _qtimg; }
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
        public List<B_MeasureProduction> bplist
        {
            get { return _bplist; }
            set { _bplist = value; }
        }
        public string bpliststr
        {
            get { return _bpliststr; }
            set { _bpliststr = value; }
        }
        #endregion Model
    }
}
