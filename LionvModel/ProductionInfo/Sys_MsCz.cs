using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public   class Sys_MsCz
    {
        #region Model
        private int _id;
        private string _czname;
        private string _czcode;
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
        public string czname
        {
            set { _czname = value; }
            get { return _czname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string czcode
        {
            set { _czcode = value; }
            get { return _czcode; }
        }
        #endregion Model

    }
}
