using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_ViewTable
    {
        public Sys_ViewTable()
        { }
        #region Model
        private int _id;
        private string _emname = "";
        private string _emcode = "";
        private string _tname = "";
        private string _tcode = "";
        private string _rcode = "";
        private string _tabname = "";
        private string _tabcode = "";
        private string _cols = "";
        private string _sqlcols = "";
        private string _sqlcondition = "";
        private string _maker = "";
        private string _cdate ;
        private string _ecols = "";
        private string _esqlcols = "";
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
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
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
        public string tabname
        {
            set { _tabname = value; }
            get { return _tabname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tabcode
        {
            set { _tabcode = value; }
            get { return _tabcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cols
        {
            set { _cols = value; }
            get { return _cols; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ecols
        {
            set { _ecols = value; }
            get { return _ecols; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sqlcols
        {
            set { _sqlcols = value; }
            get { return _sqlcols; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string esqlcols
        {
            set { _esqlcols = value; }
            get { return _esqlcols; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sqlcondition
        {
            set { _sqlcondition = value; }
            get { return _sqlcondition; }
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
