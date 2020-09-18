using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_DataTable
    {
        public Sys_DataTable()
        { }
        #region Model
        private int _id;
        private string _sname = "";
        private string _stable = "";
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
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stable
        {
            set { _stable = value; }
            get { return _stable; }
        }
        #endregion Model

    }
}
