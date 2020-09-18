using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvSqlServerDal.ProductionInfo
{
    public  class Sys_Component
    {
        public Sys_Component()
        { }
        #region Model
        private int _id;
        private string _cname;
        private string _ccode;
        private string _ccname;
        private string _cccode;
        private bool _cisshow;
        private string _cggtype;
        private decimal _xsprice;
        private decimal _ghprice;
        private decimal _cgprice;
        private string _mname;
        private string _csize;
        private string _maker;
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
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
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
        public string ccname
        {
            set { _ccname = value; }
            get { return _ccname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cccode
        {
            set { _cccode = value; }
            get { return _cccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool cisshow
        {
            set { _cisshow = value; }
            get { return _cisshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cggtype
        {
            set { _cggtype = value; }
            get { return _cggtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal xsprice
        {
            set { _xsprice = value; }
            get { return _xsprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ghprice
        {
            set { _ghprice = value; }
            get { return _ghprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cgprice
        {
            set { _cgprice = value; }
            get { return _cgprice; }
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
        public string csize
        {
            set { _csize = value; }
            get { return _csize; }
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
