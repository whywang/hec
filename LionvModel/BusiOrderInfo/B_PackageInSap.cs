using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_PackageInSap
    {
        #region Model
        private int _id;
        private int _bid = 0;
        private int _instore = 0;
        private int _outstore = 0;
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
        public int bid
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int instore
        {
            set { _instore = value; }
            get { return _instore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int outstore
        {
            set { _outstore = value; }
            get { return _outstore; }
        }
        #endregion Model
    }
}
