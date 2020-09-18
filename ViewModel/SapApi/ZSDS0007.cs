using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    /// <summary>
    /// 订单信息特性类
    /// </summary>
    public class ZSDS0007
    {
        /// <summary>
        /// GID
        /// <summary>
        public string ZZGUID { get; set; }
        /// <summary>
        /// PID
        /// <summary>
        public string ZZPID { get; set; }
        /// <summary>
        /// 物料编码
        /// <summary>
        public string MATNR { get; set; }
        /// <summary>
        /// 特性
        /// <summary>
        public string ATNAM { get; set; }
        /// <summary>
        /// 特性值
        /// <summary>
        public string ATWRT { get; set; }
        /// <summary>
        /// 特性值描述
        /// <summary>
        public string ATBEZ { get; set; }
        /// <summary>
        /// 产品编码
        /// <summary>
        public string ATPCODE { get; set; }
        /// <summary>
        /// 产品结构
        /// <summary>
        public string ATPJG { get; set; }
        /// <summary>
        /// 转换标示
        /// <summary>
        public string ATCFLAG { get; set; }
    }
}
