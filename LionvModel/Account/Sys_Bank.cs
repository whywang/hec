using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
   public class Sys_Bank
    {
        #region Model
        private int _id;
        private string _bname = "";
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
        public string bname
        {
            set { _bname = value; }
            get { return _bname; }
        }
        #endregion Model
    }
}
