using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProductionProcessCate
    {
        #region Model
        private int _id;
        private string _pcname = "";
        private string _pccode = "";
        private string _maker = "";
        private string _dcode = "";
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
        public string pcname
        {
            set { _pcname = value; }
            get { return _pcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pccode
        {
            set { _pccode = value; }
            get { return _pccode; }
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

        public string dcode
        {
            get { return _dcode; }
            set { _dcode = value; }
        }
        #endregion Model

    }
}
