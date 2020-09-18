using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_ProductionPriceTempCate
    {
        public Sys_ProductionPriceTempCate()
        { }
        #region Model
        private int _id;
        private string _ppiname = "";
        private string _ppicode;
        private string _ppms = "";
        private string _maker = "";
        private string _cdate;
        private bool _pread = false;
        private string _ptype = "";
        private string _dcode = "";
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
        public string ppiname
        {
            set { _ppiname = value; }
            get { return _ppiname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppicode
        {
            set { _ppicode = value; }
            get { return _ppicode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppms
        {
            set { _ppms = value; }
            get { return _ppms; }
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
        #endregion Model

    }
}
