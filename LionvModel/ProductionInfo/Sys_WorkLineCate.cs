using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_WorkLineCate
    {
        #region Model
        private int _id;
        private string _wcname = "";
        private string _wccode="";
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
        public string wcname
        {
            set { _wcname = value; }
            get { return _wcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wccode
        {
            set { _wccode = value; }
            get { return _wccode; }
        }
        #endregion Model
    }
}
