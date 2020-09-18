using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_XxType
    {
        #region Model
        private int _id;
        private string _xxname = "";
        private string _xxcode;
        private string  _cdate = "";
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
        public string xxname
        {
            set { _xxname = value; }
            get { return _xxname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xxcode
        {
            set { _xxcode = value; }
            get { return _xxcode; }
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
