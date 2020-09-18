using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_CustomeGroupProduction
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _psid;
        private int  _gnum = 0;
        private string _itype = "";
        private string _place = "";
        private string _direction = "";
        private string _locks = "";
        private string _hing = "";
        private decimal _pnum = 0;
        private string _remark = "";
        private string _blgy = "";

        public string blgy
        {
            get { return _blgy; }
            set { _blgy = value; }
        }
        private string _blname = "";

        public string blname
        {
            get { return _blname; }
            set { _blname = value; }
        }
        private string _msname = "";

        public string msname
        {
            get { return _msname; }
            set { _msname = value; }
        }
        private string _mtname = "";

        public string mtname
        {
            get { return _mtname; }
            set { _mtname = value; }
        }
        private string _dtype = "";

        public string dtype
        {
            get { return _dtype; }
            set { _dtype = value; }
        }
        private string _psize = "";

        public string psize
        {
            get { return _psize; }
            set { _psize = value; }
        }
        private string _maker = "";
        private string _cdate = "";
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
        public string gsid
        {
            set { _gsid = value; }
            get { return _gsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psid
        {
            set { _psid = value; }
            get { return _psid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  gnum
        {
            set { _gnum = value; }
            get { return _gnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itype
        {
            set { _itype = value; }
            get { return _itype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string direction
        {
            set { _direction = value; }
            get { return _direction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string locks
        {
            set { _locks = value; }
            get { return _locks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hing
        {
            set { _hing = value; }
            get { return _hing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  pnum
        {
            set { _pnum = value; }
            get { return _pnum; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
