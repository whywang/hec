using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_Functions
    {
        #region Model
        private int _id;
        private string _fname = "";
        private string _fstr = "";
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
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fstr
        {
            set { _fstr = value; }
            get { return _fstr; }
        }
        #endregion Model
    }
}
