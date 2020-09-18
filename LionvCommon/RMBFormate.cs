using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvCommon
{
    public class RMBFormate
    {
        private const string DXSZ = "零壹贰叁肆伍陆柒捌玖";
        private const string DXDW = "毫厘分角元拾佰仟萬拾佰仟亿拾佰仟萬兆拾佰仟萬亿京拾佰仟萬亿兆垓";
        private const string SCDW = "元拾佰仟萬亿京兆垓";

        private string ConvertIntToUppercaseAmount(string capValue)
        {
            string currCap = "";    //当前金额
            string capResult = "";  //结果金额
            string currentUnit = "";//当前单位
            string resultUnit = ""; //结果单位           
            int prevChar = -1;      //上一位的值
            int currChar = 0;       //当前位的值
            int posIndex = 4;       //位置索引，从"元"开始

            if (Convert.ToDouble(capValue) == 0) return "";
            for (int i = capValue.Length - 1; i >= 0; i--)
            {
                currChar = Convert.ToInt32(capValue.Substring(i, 1));
                if (posIndex > 30)
                {
                    break;
                }
                else if (currChar != 0)
                {
                    currCap = DXSZ.Substring(currChar, 1) + DXDW.Substring(posIndex, 1);
                }
                else
                {
                    switch (posIndex)
                    {
                        case 4: currCap = "元"; break;
                        case 8: currCap = "萬"; break;
                        case 12: currCap = "亿"; break;
                        case 17: currCap = "兆"; break;
                        case 23: currCap = "京"; break;
                        case 30: currCap = "垓"; break;
                        default: break;
                    }
                    if (prevChar != 0)
                    {
                        if (currCap != "")
                        {
                            if (currCap != "元") currCap += "零";
                        }
                        else
                        {
                            currCap = "零";
                        }
                    }
                }       
                if (capResult.Length > 0)
                {
                    resultUnit = capResult.Substring(0, 1);
                    currentUnit = DXDW.Substring(posIndex, 1);
                    if (SCDW.IndexOf(resultUnit) > 0)
                    {
                        if (SCDW.IndexOf(currentUnit) > SCDW.IndexOf(resultUnit))
                        {
                            capResult = capResult.Substring(1);
                        }
                    }
                }
                capResult = currCap + capResult;
                prevChar = currChar;
                posIndex += 1;
                currCap = "";
            }
            return capResult;
        }

        private string ConvertDecToUppercaseAmount(string capValue, bool addZero)
        {
            string currCap = "";
            string capResult = "";
            int prevChar = addZero ? -1 : 0;
            int currChar = 0;
            int posIndex = 3;

            if (Convert.ToInt16(capValue) == 0) return "";
            for (int i = 0; i < capValue.Length; i++)
            {
                currChar = Convert.ToInt16(capValue.Substring(i, 1));
                if (currChar != 0)
                {
                    currCap = DXSZ.Substring(currChar, 1) + DXDW.Substring(posIndex, 1);
                }
                else
                {
                    if (Convert.ToInt16(capValue.Substring(i)) == 0)
                    {
                        break;
                    }
                    else if (prevChar != 0)
                    {
                        currCap = "零";
                    }
                }
                capResult += currCap;
                prevChar = currChar;
                posIndex -= 1;
                currCap = "";
            }
            return capResult;
        }

        public string RMBAmount(double value)
        {
            string capResult = "";
            string capValue = string.Format("{0:f2}", value);       //格式化
            int dotPos = capValue.IndexOf(".");                     //小数点位置
            bool addInt = (Convert.ToInt32(capValue.Substring(dotPos + 1)) == 0);//是否在结果中加"整"
            bool addMinus = (capValue.Substring(0, 1) == "-");      //是否在结果中加"负"
            int beginPos = addMinus ? 1 : 0;                        //开始位置
            string capInt = capValue.Substring(beginPos, dotPos);   //整数
            string capDec = capValue.Substring(dotPos + 1);         //小数

            if (dotPos > 0)
            {
                capResult = ConvertIntToUppercaseAmount(capInt) +
                    ConvertDecToUppercaseAmount(capDec, Convert.ToDouble(capInt) != 0 ? true : false);
            }
            else
            {
                capResult = ConvertIntToUppercaseAmount(capDec);
            }
            if (addMinus) capResult = "负" + capResult;
            if (addInt) capResult += "整";
            return capResult;
        }

        public string[] RMBtoStr(double value)
        {
            string capValue = string.Format("{0:f2}", value);
            int dotPos = capValue.IndexOf(".");
            bool addInt = (Convert.ToInt32(capValue.Substring(dotPos + 1)) == 0);
            bool addMinus = (capValue.Substring(0, 1) == "-");   
            int beginPos = addMinus ? 1 : 0;                  
            string capInt = capValue.Substring(beginPos, dotPos);
            string capDec = capValue.Substring(dotPos + 1);
            string []a=  YSplitMoney(capInt);
            string []b=JSplitMoney(capDec);
            string []c = new string[8];
            for (int i = 0; i < 6; i++)
            {
                c[i] = a[i];
            }
            for (int i = 0; i < 2; i++)
            {
                c[i+6] = b[i];
            }
            return c;
        }
        private string[] YSplitMoney(string mv)
        {
            string mvl = mv.ToString().PadLeft(6, '0');
            string[] marr = new string[6];
            for (int i = 0; i < 6; i++)
            {
                marr[i] = mvl.Substring(i, 1);
            }
            return marr;
        }
        private string[] JSplitMoney(string mv)
        {
            string mvl = mv.ToString().PadRight(2, '0');
            string[] marr = new string[2];
            for (int i = 0; i < 2; i++)
            {
                marr[i] = mvl.Substring(i, 1);
            }
            return marr;
        }
    }
}
