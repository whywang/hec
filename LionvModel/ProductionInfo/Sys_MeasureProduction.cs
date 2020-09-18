using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_MeasureProduction
    {
        #region Model
        private int _id;
        private string _mpname = "";
        private string _mpcode;
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
        public string mpname
        {
            set { _mpname = value; }
            get { return _mpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mpcode
        {
            set { _mpcode = value; }
            get { return _mpcode; }
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
