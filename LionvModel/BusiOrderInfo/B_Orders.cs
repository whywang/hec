using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_Orders
    {
        #region Model
        private int _id;
        private string _csid = "";
        private string _sid;
        private string _zcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _community = "";
        private string _address = "";
        private string _city = "";
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private bool _mqmo = false;
        private bool _yqmo = false;
        private bool _qbo = false;
        private bool _czo = false;
        private bool _dso = false;
        private bool _ymo = false;
        private string _maker = "";
        private string _cdate;
        private string _acity = "";
        private string _aprovince = "";

        public string acity
        {
            get { return _acity; }
            set { _acity = value; }
        }
        public string aprovince
        {
            get { return _aprovince; }
            set { _aprovince = value; }
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
        public string zcode
        {
            set { _zcode = value; }
            get { return _zcode; }
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
        public bool mqmo
        {
            set { _mqmo = value; }
            get { return _mqmo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool yqmo
        {
            set { _yqmo = value; }
            get { return _yqmo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool qbo
        {
            set { _qbo = value; }
            get { return _qbo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool czo
        {
            set { _czo = value; }
            get { return _czo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool dso
        {
            set { _dso = value; }
            get { return _dso; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ymo
        {
            set { _ymo = value; }
            get { return _ymo; }
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
