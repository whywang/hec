using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
    [Serializable]
    public  class CB_OrderEventBtn
    {
      
		public CB_OrderEventBtn()
		{}
		#region Model
		private int _id;
		private string _sid="";
		private string _emname="";
		private string _emcode="";
		private string _wfname="";
		private string _wfcode="";
		private string _bname="";
		private string _bcode="";
		private string _btype="";
		private int _state=0;
		private string _ps="";
		private string _maker="";
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
		public string emname
		{
			set{ _emname=value;}
			get{return _emname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string emcode
		{
			set{ _emcode=value;}
			get{return _emcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wfname
		{
			set{ _wfname=value;}
			get{return _wfname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wfcode
		{
			set{ _wfcode=value;}
			get{return _wfcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bname
		{
			set{ _bname=value;}
			get{return _bname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bcode
		{
			set{ _bcode=value;}
			get{return _bcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string btype
		{
			set{ _btype=value;}
			get{return _btype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ps
		{
			set{ _ps=value;}
			get{return _ps;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maker
		{
			set{ _maker=value;}
			get{return _maker;}
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
