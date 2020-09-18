using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public  class Sys_ProductionTempCate
    {
        public Sys_ProductionTempCate()
        { }
        #region Model
        private int _id;
        private string _ptcode = "";
        private string _ptname = "";
        private string _ptms = "";
        private string _ptattr = "";
        private string _maker = "";
        private string _cdate;
        private bool _pread = false;
        private string _ptype = "";
        private string _dcode = "";
        private bool _pisbk = false;
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
        public string ptcode
        {
            set { _ptcode = value; }
            get { return _ptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptname
        {
            set { _ptname = value; }
            get { return _ptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptms
        {
            set { _ptms = value; }
            get { return _ptms; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptattr
        {
            set { _ptattr = value; }
            get { return _ptattr; }
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
        /// <summary>
        /// 
        /// </summary>
        public bool pread
        {
            set { _pread = value; }
            get { return _pread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
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
        public bool pisbk
        {
            set { _pisbk = value; }
            get { return _pisbk; }
        }
        #endregion Model

    }
}
