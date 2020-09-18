using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    //部分发货单
   public class B_ApartSendOrder
    {
        #region Model
        private int _id;
        private string _osid;
        private string _sid;
        private int _snum = 0;
        private string _fhcode = "";
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
        public string osid
        {
            set { _osid = value; }
            get { return _osid; }
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
        /// 发货单数量
        /// </summary>
        public int snum
        {
            set { _snum = value; }
            get { return _snum; }
        }
        /// <summary>
        /// 发货单编号
        /// </summary>
        public string fhcode
        {
            set { _fhcode = value; }
            get { return _fhcode; }
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
