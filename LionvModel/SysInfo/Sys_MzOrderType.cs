using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_MzOrderType
    {
        #region Model
        private int _id;
        private string _mtname = "";
        private string _mtcode = "";
        private string _emcode = "";
        private string _maker = "";
        private string _cdate;
        private string _otype = "";
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
        public string mtname
        {
            set { _mtname = value; }
            get { return _mtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtcode
        {
            set { _mtcode = value; }
            get { return _mtcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
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
