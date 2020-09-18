using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    /// </summary>
	[Serializable]
	public class B_InHouseOrder
	{
		public B_InHouseOrder()
		{}
		#region Model
		private int _id;
		private string _sid="";
		private string _isid="";
		private string _icode="";
		private string _ps="";
		private int _state=0;
		private string _maker="";
		private string _cdate ;
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
		public string isid
		{
			set{ _isid=value;}
			get{return _isid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icode
		{
			set{ _icode=value;}
			get{return _icode;}
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
		public int state
		{
			set{ _state=value;}
			get{return _state;}
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
