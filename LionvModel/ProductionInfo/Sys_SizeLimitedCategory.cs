using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public partial class Sys_SizeLimitedCategory
    {
 
        #region Model
        private int _id;
        private string _scname = "";
        private string _sccode = "";
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
        public string scname
        {
            set { _scname = value; }
            get { return _scname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sccode
        {
            set { _sccode = value; }
            get { return _sccode; }
        }
        #endregion Model

    }
}
