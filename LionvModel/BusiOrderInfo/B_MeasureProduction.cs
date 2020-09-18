using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_MeasureProduction
    {
        public B_MeasureProduction()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _pcname = "";
        private int _pcnum = 0;
        private string _pccode = "";
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
        public string pcname
        {
            set { _pcname = value; }
            get { return _pcname; }
        }
        public string pccode
        {
            get { return _pccode; }
            set { _pccode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pcnum
        {
            set { _pcnum = value; }
            get { return _pcnum; }
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
