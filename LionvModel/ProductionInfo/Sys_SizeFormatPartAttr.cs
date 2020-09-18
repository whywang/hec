using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SizeFormatPartAttr
    {
        #region Model
        private int _id;
        private string _tname = "";
        private string _tabc = "";
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
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tabc
        {
            set { _tabc = value; }
            get { return _tabc; }
        }
        #endregion Model

    }
}
