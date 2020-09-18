using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
    [Serializable]
    public  class CB_OrderState
    {
        public CB_OrderState()
        { }
        #region Model
        private int _id;
        private string _sid;
        private int _ichange = 0;
        private int _imodify = 0;
        private int _iadd = 0;
        private int _iover = 0;
        private int _istop = 0;
        private int _ifast = 0;
        private int _imoney = 0;
        private int _ifactorydeliver = 0;
        private int _istoreget = 0;
        private int _ipackage = 0;
        private int _istoredeliver = 0;
        private int _icityget = 0;
        private int _idistribution = 0;
        private int _ifixed = 0;

        private int _iwjbh = 0;
        private int _iwjfh = 0;
        private int _isetlment = 0;
        private int _iinsap = 0;
        private int _iwjinsap = 0;
        private int _icsap=0;
        private int _idmoney = 0;
        private int _inewpp = 0;
        private int _ipdraw = 0;
        private int _iproduce = 0;
        private int _imeasure = 0;

        private int _inproduce = 0;
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
        public int ichange
        {
            set { _ichange = value; }
            get { return _ichange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int imodify
        {
            set { _imodify = value; }
            get { return _imodify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iadd
        {
            set { _iadd = value; }
            get { return _iadd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iover
        {
            set { _iover = value; }
            get { return _iover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int istop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ifast
        {
            set { _ifast = value; }
            get { return _ifast; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int imoney
        {
            set { _imoney = value; }
            get { return _imoney; }
        }
        public int inproduce
        {
            get { return _inproduce; }
            set { _inproduce = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ifactorydeliver
        {
            set { _ifactorydeliver = value; }
            get { return _ifactorydeliver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int istoreget
        {
            set { _istoreget = value; }
            get { return _istoreget; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ipackage
        {
            set { _ipackage = value; }
            get { return _ipackage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int istoredeliver
        {
            set { _istoredeliver = value; }
            get { return _istoredeliver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int icityget
        {
            set { _icityget = value; }
            get { return _icityget; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idistribution
        {
            set { _idistribution = value; }
            get { return _idistribution; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ifixed
        {
            set { _ifixed = value; }
            get { return _ifixed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iwjbh
        {
            set { _iwjbh = value; }
            get { return _iwjbh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iwjfh
        {
            set { _iwjfh = value; }
            get { return _iwjfh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isetlment
        {
            set { _isetlment = value; }
            get { return _isetlment; }
        }
        public int iinsap
        {
            get { return _iinsap; }
            set { _iinsap = value; }
        }
        public int iwjinsap
        {
            get { return _iwjinsap; }
            set { _iwjinsap = value; }
        }
        public int icsap
        {
            get { return _icsap; }
            set { _icsap = value; }
        }
        public int idmoney
        {
            get { return _idmoney; }
            set { _idmoney = value; }
        }
        public int inewpp
        {
            get { return _inewpp; }
            set { _inewpp = value; }
        }
        public int ipdraw
        {
            get { return _ipdraw; }
            set { _ipdraw = value; }
        }
        public int iproduce
        {
            get { return _iproduce; }
            set { _iproduce = value; }
        }
        public int imeasure
        {
            get { return _imeasure; }
            set { _imeasure = value; }
        }
        #endregion Model

    }
}
