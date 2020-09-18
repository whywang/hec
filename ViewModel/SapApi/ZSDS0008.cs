using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
   public class ZSDS0008
    {

        /// <summary>
        /// 订单系统订单号
        /// <summary>
        public string ZUONR { get; set; }
        /// <summary>
        /// 订单系统生产单号
        /// <summary>
        public string BSTKD_E { get; set; }
        /// <summary>
        /// 业务标识
        /// <summary>
        public string ZZYWBZ { get; set; }
        /// <summary>
        /// 订单类型
        /// <summary>
        public string AUART { get; set; }
        /// <summary>
        /// 销售组织
        /// <summary>
        public string VKORG { get; set; }
        /// <summary>
        /// 分销渠道
        /// <summary>
        public string VTWEG { get; set; }
        /// <summary>
        /// 产品组
        /// <summary>
        public string SPART { get; set; }
        /// <summary>
        /// 客户编码
        /// <summary>
        public string KUNNR { get; set; }
        /// <summary>
        /// 店面面积
        /// <summary>
        public string ZZDMMJ { get; set; }
        /// <summary>
        /// 客户参考
        /// <summary>
        public string BSTKD { get; set; }
        /// <summary>
        /// 客户参考日期
        /// <summary>
        public string BSTDK { get; set; }
        /// <summary>
        /// 订单原因
        /// <summary>
        public string AUGRU { get; set; }
        /// <summary>
        /// 特殊处理标识
        /// <summary>
        public string SDABW { get; set; }
        /// <summary>
        /// 订单成本中心
        /// <summary>
        public string KOSTL { get; set; }
        /// <summary>
        /// 汇总号
        /// <summary>
        public string SUBMI { get; set; }
        /// <summary>
        /// 名称
        /// <summary>
        public string BNAME { get; set; }
        /// <summary>
        /// 订单系统支付单号
        /// <summary>
        public string XBLNR { get; set; }
        /// <summary>
        /// 工程项目描述
        /// <summary>
        public string ZZGCXMMS { get; set; }
        /// <summary>
        /// 原订单系统单号（参考VBKD-BSTKD_E）
        /// <summary>
        public string BSTKD_Y { get; set; }
        /// <summary>
        /// 订单系统主表主键
        /// <summary>
        public string ZZGUID { get; set; }
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
        public string BSARK { get; set; }
        /// <summary>
        /// 五金子表信息
        /// </summary>
        public List<ZSDS0009> ITEMS_SD03 { get; set; }
        /// <summary>
        /// 五金价格信息
        /// </summary>
        public List<ZSDS0010> PRICE_SD03 { get; set; }
    }
}
