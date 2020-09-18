using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public  class Sys_ColorPane
    {
 
        #region Model
        private int _id;
        private string _sbname;
        private string _sbcode;
        private bool _used = true;
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
        public string sbname
        {
            set { _sbname = value; }
            get { return _sbname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sbcode
        {
            set { _sbcode = value; }
            get { return _sbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool used
        {
            set { _used = value; }
            get { return _used; }
        }
        #endregion Model

    }
}
