using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_jlProvince
    {
        #region Model
        private int _id;
        private string _jcode = "";
        private string _jname = "";
        private int _jlevel = 0;
        private string _pcode = "";
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
        public string jcode
        {
            set { _jcode = value; }
            get { return _jcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jname
        {
            set { _jname = value; }
            get { return _jname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int jlevel
        {
            set { _jlevel = value; }
            get { return _jlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        #endregion Model
    }
}
