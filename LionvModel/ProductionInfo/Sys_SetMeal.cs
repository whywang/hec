using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_SetMeal
    {
 
        #region Model
        private int _id;
        private string _tcname = "";
        private string _tccode = "";
        private string _tcbdate;
        private string _tcedate;
        private decimal _bjprice = 0M;
        private decimal _wbprice = 0M;
        private decimal _cgprice = 0M;
        private int _tcnum = 0;
        private string _tcarea = "";
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
        public string tcbdate
        {
            set { _tcbdate = value; }
            get { return _tcbdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcedate
        {
            set { _tcedate = value; }
            get { return _tcedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bjprice
        {
            set { _bjprice = value; }
            get { return _bjprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal wbprice
        {
            set { _wbprice = value; }
            get { return _wbprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cgprice
        {
            set { _cgprice = value; }
            get { return _cgprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tcnum
        {
            set { _tcnum = value; }
            get { return _tcnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcarea
        {
            set { _tcarea = value; }
            get { return _tcarea; }
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
