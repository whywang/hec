using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Account
{
    public class B_ExchangeRecord
    {
        #region Model
        private int _id;
		private string _sid;
		private string _osid="";
		private string _sacode="";
		private string _oscode="";
		private string _etype="";
		private string _otype="";
		private decimal _emoney=0M;
		private decimal _umoney=0M;
		private string _cdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string osid
		{
			set{ _osid=value;}
			get{return _osid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sacode
		{
			set{ _sacode=value;}
			get{return _sacode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oscode
		{
			set{ _oscode=value;}
			get{return _oscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string etype
		{
			set{ _etype=value;}
			get{return _etype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otype
		{
			set{ _otype=value;}
			get{return _otype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal emoney
		{
			set{ _emoney=value;}
			get{return _emoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal umoney
		{
			set{ _umoney=value;}
			get{return _umoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdate
		{
			set{ _cdate=value;}
			get{return _cdate;}
		}
		#endregion Model
      
    }
}
