using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_WorkSchedule
    {
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode = "";
        private int  _cyear;
        private int  _cmonth;
        private string _curdate;
        private string _btime;
        private string _etime;
        private string _title = "";
        private string _color = "";
        private string _classname = "";
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
        public int  cyear
        {
            set { _cyear = value; }
            get { return _cyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  cmonth
        {
            set { _cmonth = value; }
            get { return _cmonth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curdate
        {
            set { _curdate = value; }
            get { return _curdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string btime
        {
            set { _btime = value; }
            get { return _btime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string etime
        {
            set { _etime = value; }
            get { return _etime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string classname
        {
            set { _classname = value; }
            get { return _classname; }
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
