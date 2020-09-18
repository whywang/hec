using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    /// <summary>
    /// 销售订单-一级产品表类
    /// </summary>
    public class ZSDS0002
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
        /// 原订单系统序号
        /// <summary>
        public string POSEX_Y { get; set; }
        /// <summary>
        /// 订单系统序号
        /// <summary>
        public string POSEX_E { get; set; }
        /// <summary>
        /// 订单系统产品编码
        /// <summary>
        public string ZZDDCPBM { get; set; }
        /// <summary>
        /// 订单系统产品描述
        /// <summary>
        public string ZZDDCPMS { get; set; }
        /// <summary>
        /// SAP产品编码
        /// <summary>
        public string MATNR { get; set; }
        /// <summary>
        /// 数量
        /// <summary>
        public string KWMENG { get; set; }
        /// <summary>
        /// 生产工厂
        /// <summary>
        public string WERKS_SC { get; set; }
        /// <summary>
        /// 发货工厂
        /// <summary>
        public string WERKS_FH { get; set; }
        /// <summary>
        /// 库存地点
        /// <summary>
        public string LGORT { get; set; }
        /// <summary>
        /// 交货日期
        /// <summary>
        public string ETDAT { get; set; }
        /// <summary>
        /// 是否含预装五金
        /// <summary>
        public string ZZYZWJ { get; set; }
        /// <summary>
        /// 高
        /// <summary>
        public string ZZGAO { get; set; }
        /// <summary>
        /// 宽
        /// <summary>
        public string ZZKUAN { get; set; }
        /// <summary>
        /// 厚
        /// <summary>
        public string ZZHOU { get; set; }
        /// <summary>
        /// 安装方式
        /// <summary>
        public string ZZAZFS { get; set; }
        /// <summary>
        /// 开向
        /// <summary>
        public string ZZKX { get; set; }
        /// <summary>
        /// 合页
        /// <summary>
        public string ZZHY { get; set; }
        /// <summary>
        /// 锁孔
        /// <summary>
        public string ZZSK { get; set; }
        /// <summary>
        /// 安放位置
        /// <summary>
        public string ZZAFWZ { get; set; }
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
    }
}
