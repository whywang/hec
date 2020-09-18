using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_SetMeal
    {
        public B_SetMeal()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _tsid;
        private string _tcname = "";
        private string _tccode = "";
        private decimal _tcprice = 0;
        private decimal _tgprice = 0;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tsid
        {
            set { _tsid = value; }
            get { return _tsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcname
        {
            set { _tcname = value; }
            get { return _tcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tccode
        {
            set { _tccode = value; }
            get { return _tccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tcprice
        {
            set { _tcprice = value; }
            get { return _tcprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tgprice
        {
            set { _tgprice = value; }
            get { return _tgprice; }
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
