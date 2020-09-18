using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_Duty
    {
        public Sys_Duty()
        { }
        #region Model
        private int _id;
        private string _dname;
        private string _dcode;
        private string _ddetail;
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddetail
        {
            set { _ddetail = value; }
            get { return _ddetail; }
        }
        #endregion Model

    }
}
