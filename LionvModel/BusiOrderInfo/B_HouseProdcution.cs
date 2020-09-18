
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_HouseProdcution
    {
        #region Model
        private int _id;
        private string _sid = "";
        private int _gnum = 0;
        private string _psid = "";
        private string _psize = "";
        private string _pname = "";
        private string _mname = "";
        private int _pnum = 0;
        private int _istate = 0;
        private int _ostate = 0;
        private string _idate;
        private string _odate;
        private string _osid = "";
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
        public int gnum
        {
            set { _gnum = value; }
            get { return _gnum; }
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
        public string psize
        {
            set { _psize = value; }
            get { return _psize; }
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
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
        public int istate
        {
            set { _istate = value; }
            get { return _istate; }
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
        public string idate
        {
            set { _idate = value; }
            get { return _idate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string odate
        {
            set { _odate = value; }
            get { return _odate; }
        }
        #endregion Model
    }
}