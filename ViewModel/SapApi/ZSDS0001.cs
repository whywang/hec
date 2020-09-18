using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    public class ZSDS0001
    {
        #region 属性定义
        /// <summary>
        /// 订单系统订单号
        /// <summary>
        public string BSTKD_E { get; set; }
        /// <summary>
        /// 订单系统生产单号
        /// <summary>
        public string ZUONR { get; set; }
        ///// <summary>
        ///// 支付日期(yyyy-MM-dd)
        ///// <summary>
        //public string BSTDK { get; set; }
        /// <summary>
        /// 业务标识
        /// <summary>
        public string ZZYWBZ { get; set; }
        /// <summary>
        /// 样品业务标识
        /// <summary>
        public string ZZYPYWBZ { get; set; }
        /// <summary>
        /// 重做标识
        /// <summary>
        public string ZZCZBZ { get; set; }
        /// <summary>
        /// 工厂上线标识
        /// <summary>
        public string ZZGCSXBZ { get; set; }
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
        /// 售达方采购订单类型
        /// <summary>
        public string BSARK { get; set; }
        /// <summary>
        /// 特殊处理标识
        /// <summary>
        public string SDABW { get; set; }
        /// <summary>
        /// 订单原因
        /// <summary>
        public string AUGRU { get; set; }
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
        /// 原订单系统单号
        /// <summary>
        public string BSTKD_Y { get; set; }
        /// <summary>
        /// 分厂日期
        /// <summary>
        public string ERDAT_FC { get; set; }
        /// <summary>
        /// 生产确认日期
        /// <summary>
        public string ERDAT_QR { get; set; }
        /// <summary>
        /// 材质分类
        /// <summary>
        public string ZZCZFL { get; set; }
        /// <summary>
        /// 订单系统主表主键
        /// <summary>
        public string ZZGUID { get; set; }
        /// <summary>
        /// 主表备注
        /// <summary>
        public string ZZZBBZ { get; set; }
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
        /// 工厂
        /// <summary>
        public string FCCODE { get; set; }
        #endregion

        /// <summary>
        /// 一级产品表明细
        /// </summary>
        public List<ZSDS0002> ITEMS_SD01;

        /// <summary>
        /// 销售订单价格金额表
        /// </summary>
        public List<ZSDS0003> PRICE_SD01;

        /// <summary>
        /// 销售订单产品三级表
        /// </summary>
        public List<ZSDS0006> LEVE3_SD01;

        /// <summary>
        /// 销售订单特性信息
        /// </summary>
        public List<ZSDS0007> CHARA_SD01;
        /// <summary>
        /// 销售产品分包信息处理
        /// </summary>
        public List<ZSDS0011> PACKA_SD01;
    }
}
