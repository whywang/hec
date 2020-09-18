using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
  public  class Sys_TabMenuAbc
    {
        #region Model
        private int _id;
        private string _tmname = "";
        private string _tmcode = "";
        private string _tname = "";
        private string _tcode = "";
        private string _rcode = "";
        private string _tsql = "";
        private string _cdate;
        private string _ptype = "";

        public string ptype
        {
            get { return _ptype; }
            set { _ptype = value; }
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
        public string tmname
        {
            set { _tmname = value; }
            get { return _tmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tmcode
        {
            set { _tmcode = value; }
            get { return _tmcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tsql
        {
            set { _tsql = value; }
            get { return _tsql; }
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
