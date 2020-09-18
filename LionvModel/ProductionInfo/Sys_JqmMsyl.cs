using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_JqmMsyl
    {
        #region Model
        private int _id;
        private string _ylname = "";
        private string _ylcode;
        private int  _hyl = 0;
        private int  _wyl = 0;
        private string _maker = "";
        private string  _cdate = "";
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
        public string ylname
        {
            set { _ylname = value; }
            get { return _ylname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ylcode
        {
            set { _ylcode = value; }
            get { return _ylcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  hyl
        {
            set { _hyl = value; }
            get { return _hyl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  wyl
        {
            set { _wyl = value; }
            get { return _wyl; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
