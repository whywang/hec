using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_SystemImg
    {
        #region Model
        private int _id;
        private string _murl;
        private int _mtype = 0;
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
        public string murl
        {
            set { _murl = value; }
            get { return _murl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        #endregion Model
    }
}
