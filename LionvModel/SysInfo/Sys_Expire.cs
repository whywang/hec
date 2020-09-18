using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_Expire
    {
        public Sys_Expire()
        { }
        #region Model
        private int _id;
        private string _expdate;
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
        public string expdate
        {
            set { _expdate = value; }
            get { return _expdate; }
        }
        #endregion Model

    }
}
