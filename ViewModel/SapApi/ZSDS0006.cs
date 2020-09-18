using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    /// <summary>
    /// 订单信息产品三级表类
    /// </summary>
    public class ZSDS0006
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
        /// MID
        /// <summary>
        public string ZZMID { get; set; }
        /// <summary>
        /// PIDS
        /// <summary>
        public string ZZPIDS { get; set; }
        /// <summary>
        /// 订单系统订单号
        /// <summary>
        public string BSTKD_E { get; set; }
        /// <summary>
        /// 订单系统序号
        /// <summary>
        public string POSEX_E { get; set; }
        /// <summary>
        /// 订单系统生产单号
        /// <summary>
        public string ZUONR { get; set; }
        /// <summary>
        /// 产品分类
        /// <summary>
        public string ZZCPFL { get; set; }
        /// <summary>
        /// 材质分类
        /// <summary>
        public string ZZCZFL { get; set; }
        /// <summary>
        /// 结构类型
        /// <summary>
        public string ZZJGLX { get; set; }
        /// <summary>
        /// 尺寸
        /// <summary>
        public string ZZCC { get; set; }
        /// <summary>
        /// 尺寸公示
        /// <summary>
        public string ZZCCGS { get; set; }
        /// <summary>
        /// SAP产品编码
        /// <summary>
        public string MATNR { get; set; }
        /// <summary>
        /// 材质编码
        /// <summary>
        public string ZZCZBM { get; set; }
        /// <summary>
        /// 数量
        /// <summary>
        public string KWMENG { get; set; }
        /// <summary>
        /// 预留字段1
        /// <summary>
        public string ZZYL1 { get; set; }
        /// <summary>
        /// 预留字段2
        /// <summary>
        public string ZZYL2 { get; set; }
        /// <summary>
        /// 预留字段3
        /// <summary>
        public string ZZYL3 { get; set; }
        /// <summary>
        /// 产品编码
        /// <summary>
        public string ZZPCODE { get; set; }
    }
}
