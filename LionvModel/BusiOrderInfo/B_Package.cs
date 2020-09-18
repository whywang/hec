using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_Package
    {
        public B_Package()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _bsid = "";
        private int _sortnum = 0;
        private int _bnum = 0;
        private string _pname = "";
        private string _pcode = "";
        private int _pnum = 0;
        private int _height = 0;
        private int _width = 0;
        private int _deep = 0;
        private string _maker = "";
        private string _cdate ;
        private string _btype = "";
        private int _bz = 0;
        private int _zbrk = 0;
        private int _zbck = 0;
        private int _csrk = 0;
        private int _csck = 0;
        private string _bzid = "";
        /// <summary>
        /// 
        /// </summary>
        public int bz
        {
            set { _bz = value; }
            get { return _bz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bzid
        {
            set { _bzid = value; }
            get { return _bzid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int zbrk
        {
            set { _zbrk = value; }
            get { return _zbrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int zbck
        {
            set { _zbck = value; }
            get { return _zbck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int csrk
        {
            set { _csrk = value; }
            get { return _csrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int csck
        {
            set { _csck = value; }
            get { return _csck; }
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bsid
        {
            set { _bsid = value; }
            get { return _bsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sortnum
        {
            set { _sortnum = value; }
            get { return _sortnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bnum
        {
            set { _bnum = value; }
            get { return _bnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
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
        public int pnum
        {
            set { _pnum = value; }
            get { return _pnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int deep
        {
            set { _deep = value; }
            get { return _deep; }
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
        public string btype
        {
            set { _btype = value; }
            get { return _btype; }
        }
        #endregion Model

    }
}
