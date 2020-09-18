using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public  class Sys_RGroupButton
    {
        public Sys_RGroupButton()
        { }
        #region Model
        private int _id;
        private string _gcode;
        private string _bcode;
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
        public string bcode
        {
            set { _bcode = value; }
            get { return _bcode; }
        }
        #endregion Model

    }
}
