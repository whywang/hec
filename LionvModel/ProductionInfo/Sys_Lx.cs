using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public   class Sys_Lx
    {
 
        #region Model
        private int _id;
        private string _lxname;
        private string _lxcode;
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
        public string lxname
        {
            set { _lxname = value; }
            get { return _lxname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lxcode
        {
            set { _lxcode = value; }
            get { return _lxcode; }
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
