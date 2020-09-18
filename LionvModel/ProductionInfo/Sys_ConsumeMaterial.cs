using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ConsumeMaterial
    {
        #region Model
        private int _id;
        private string _mname = "";
        private string _mcode;
        private string _pmcode = "";
        private string _pmname = "";
        private int _mlength = 0;
        private int _mwidth = 0;
        private int _mdeep = 0;
        private string _munit = "";
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pmcode
        {
            set { _pmcode = value; }
            get { return _pmcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pmname
        {
            set { _pmname = value; }
            get { return _pmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int mlength
        {
            set { _mlength = value; }
            get { return _mlength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int mwidth
        {
            set { _mwidth = value; }
            get { return _mwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int mdeep
        {
            set { _mdeep = value; }
            get { return _mdeep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string munit
        {
            set { _munit = value; }
            get { return _munit; }
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
