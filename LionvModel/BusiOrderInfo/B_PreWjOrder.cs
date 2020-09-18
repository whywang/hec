using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_PreWjOrder
    {
        public B_PreWjOrder()
        { }
        #region Model
        private int _id;
        private string _sid;
        private string _wjcode = "";
        private string _e_city = "";
        private string _remark = "";
        private string _cdate = "";
        private string _maker = "";
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
        public string wjcode
        {
            set { _wjcode = value; }
            get { return _wjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_city
        {
            set { _e_city = value; }
            get { return _e_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        #endregion Model
    }
}
