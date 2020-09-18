using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_PartQualityOrder
    {
        #region Model
        private int _id;
        private string _qsid;
        private string _sid = "";
        private string _qcode = "";
        private int _qstate = 0;
        private string _maker = "";
        private string _cdate;
        private string _remark = "";
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
        public string qsid
        {
            set { _qsid = value; }
            get { return _qsid; }
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
        public string qcode
        {
            set { _qcode = value; }
            get { return _qcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int qstate
        {
            set { _qstate = value; }
            get { return _qstate; }
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
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
