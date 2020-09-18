using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_RemarkCondition
    {
        public Sys_RemarkCondition()
        { }
        #region Model
        private int _id;
        private string _rcname = "";
        private string _rccode = "";
        private string _rcode = "";
        private string _rtype = "";
        private int _rbottomv = 0;
        private int _rtopv = 0;
        private string _rxtext = "";
        private string _marker = "";
        private string _cdate = "";
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
        public string rcname
        {
            set { _rcname = value; }
            get { return _rcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rccode
        {
            set { _rccode = value; }
            get { return _rccode; }
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
        public string rtype
        {
            set { _rtype = value; }
            get {
                return _rtype;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int rbottomv
        {
            set { _rbottomv = value; }
            get { return _rbottomv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int rtopv
        {
            set { _rtopv = value; }
            get { return _rtopv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rxtext
        {
            set { _rxtext = value; }
            get { return _rxtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string marker
        {
            set { _marker = value; }
            get { return _marker; }
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
