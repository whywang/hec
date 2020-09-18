using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public  class Sys_Group
    {
        public Sys_Group()
        { }
        #region Model
        private int _id;
        private string _gname = "";
        private string _gcode = "";
        private string _gdetail = "";
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
        public string gname
        {
            set { _gname = value; }
            get { return _gname; }
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
        public string gdetail
        {
            set { _gdetail = value; }
            get { return _gdetail; }
        }
        #endregion Model

    }
}
