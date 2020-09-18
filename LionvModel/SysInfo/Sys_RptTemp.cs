using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    //报表模板管理
   public class Sys_RptTemp
    {
        #region Model
        private int _id;
        private string _rtname = "";
        private string _rtcode;
        private string _emcode = "";
        private string _emname = "";
        private string _dbtname = "";
        private string _thtext = "";
        private string _dbcol = "";
        private string _dbwhere = "";
        private string _maker = "";
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
        public string rtname
        {
            set { _rtname = value; }
            get { return _rtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rtcode
        {
            set { _rtcode = value; }
            get { return _rtcode; }
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
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbtname
        {
            set { _dbtname = value; }
            get { return _dbtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string thtext
        {
            set { _thtext = value; }
            get { return _thtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbcol
        {
            set { _dbcol = value; }
            get { return _dbcol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbwhere
        {
            set { _dbwhere = value; }
            get { return _dbwhere; }
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
