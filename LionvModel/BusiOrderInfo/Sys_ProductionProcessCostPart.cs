using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class Sys_ProductionProcessCostPart
    {
        #region Model
        private int _id;
        private string _uname;
        private string _ucode;
        private string _bjtype;
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
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ucode
        {
            set { _ucode = value; }
            get { return _ucode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjtype
        {
            set { _bjtype = value; }
            get { return _bjtype; }
        }
        #endregion Model
    }
}
