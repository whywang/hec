using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_PackageCode
    {
        public B_PackageCode()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private int _bnum = 0;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bnum
        {
            set { _bnum = value; }
            get { return _bnum; }
        }
        #endregion Model

    }
}
