using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_SearchCondtion
    {
        public Sys_SearchCondtion()
        { }
        #region Model
        private int _id;
        private string _mcode;
        private string _rcode;
        private string _ssql;
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
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        public string ssql
        {
            set { _ssql = value; }
            get { return _ssql; }
        }
        #endregion Model

    }
}
