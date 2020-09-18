using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_HyType
    {
        #region Model
        private int _id;
        private string _hyname = "";
        private string _hycode;
        private decimal _hyprice = 0;
        private string _bdcode = "";
        private string _maker = "";
        private string _cdate;
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
        public string hyname
        {
            set { _hyname = value; }
            get { return _hyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hycode
        {
            set { _hycode = value; }
            get { return _hycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal hyprice
        {
            set { _hyprice = value; }
            get { return _hyprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
