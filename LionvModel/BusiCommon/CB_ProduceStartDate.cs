using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_ProduceStartDate
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _msid;
        private string  _sdate;
        private string _dname = "";
        private string _dcode = "";
        private string  _cdate;
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
        public string msid
        {
            set { _msid = value; }
            get { return _msid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  sdate
        {
            set { _sdate = value; }
            get { return _sdate; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model

    }
}
