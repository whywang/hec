using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_ProductionPriceTemp
    {
        public Sys_ProductionPriceTemp()
        { }
        #region Model
        private int _id;
        private string _ptname = "";
        private string _ptcode;
        private string _ppname = "";
        private string _ppcode = "";
        private string _ptemp = "";
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
        public string ptname
        {
            set { _ptname = value; }
            get { return _ptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptcode
        {
            set { _ptcode = value; }
            get { return _ptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppname
        {
            set { _ppname = value; }
            get { return _ppname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppcode
        {
            set { _ppcode = value; }
            get { return _ppcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptemp
        {
            set { _ptemp = value; }
            get { return _ptemp; }
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
