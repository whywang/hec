using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_SetMealProduction
    {
 
        #region Model
        private int _id;
        private string _tcname = "";
        private string _tccode = "";
        private string _tcplb = "";
        private string _tcblbcode = "";
        private string _tcpxz = "";
        private int _tcpnum = 0;
        private int _tcplnum = 0;
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
        public string tcplb
        {
            set { _tcplb = value; }
            get { return _tcplb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcblbcode
        {
            set { _tcblbcode = value; }
            get { return _tcblbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tcplnum
        {
            set { _tcplnum = value; }
            get { return _tcplnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tcpnum
        {
            set { _tcpnum = value; }
            get { return _tcpnum; }
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
        public string tcpxz
        {
            set { _tcpxz = value; }
            get { return _tcpxz; }
        }
        #endregion Model

    }
}
