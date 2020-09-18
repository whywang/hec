using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_NomalSize
    {
        public Sys_NomalSize()
        { }
        #region Model
        private int _id;
        private string _nname = "";
        private string _ncode = "";
        private int  _ng = 0;
        private int  _nk = 0;
        private int  _nh = 0;
        private int  _nf = 0;
        private int  _nsl = 0;
        private string _nattr;
        private string _maker = "";
        private string  _cdate = "";
        private bool _nrelate = false;
        private int  _nrg = 0;
        private int  _nrk = 0;
        private int  _nrn = 0;
        private int  _nrf = 0;
        private int  _nrsl = 0;
        private string _dcode = "";
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
        public string nname
        {
            set { _nname = value; }
            get { return _nname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ncode
        {
            set { _ncode = value; }
            get { return _ncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ng
        {
            set { _ng = value; }
            get { return _ng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nk
        {
            set { _nk = value; }
            get { return _nk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nh
        {
            set { _nh = value; }
            get { return _nh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nf
        {
            set { _nf = value; }
            get { return _nf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nsl
        {
            set { _nsl = value; }
            get { return _nsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nattr
        {
            set { _nattr = value; }
            get {return _nattr;}
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
        /// <summary>
        /// 
        /// </summary>
        public bool nrelate
        {
            set { _nrelate = value; }
            get { return _nrelate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nrg
        {
            set { _nrg = value; }
            get { return _nrg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nrk
        {
            set { _nrk = value; }
            get { return _nrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nrn
        {
            set { _nrn = value; }
            get { return _nrn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nrf
        {
            set { _nrf = value; }
            get { return _nrf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  nrsl
        {
            set { _nrsl = value; }
            get { return _nrsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model
    }
}
