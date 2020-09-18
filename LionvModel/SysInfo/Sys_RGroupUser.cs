using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_RGroupUser
    {
        public Sys_RGroupUser()
        { }
        #region Model
        private int _id;
        private string _gcode;
        private string _uname;
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
        public string gcode
        {
            set { _gcode = value; }
            get { return _gcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        #endregion Model

    }
}
