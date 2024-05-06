using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{   
    /// <summary>
    /// 封装一些字符串处理的扩展方法
    /// </summary>
    public static class StringHelper
    {


        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="separator">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrList(this string str, char separator, bool toLower)
        {
            List<string> list = new List<string>();
            string[] sList = str.Split(separator);
            foreach (string s in sList)
            {
                if (!string.IsNullOrEmpty(s) && s != separator.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }


        /// <summary>
        /// 将子串从主串中移除
        /// </summary>
        /// <param name="str">主串</param>
        /// <param name="reStr">要移除的子串</param>
        /// <returns></returns>
        public static string RemoveSubStr(this string str,string reStr)
        {
            List<string> arrStr = str.GetStrList(',', false);
            arrStr.Remove(reStr);
            return arrStr.GetListStrToString(",");
        }


        /// <summary>
        /// 把字符串数组通过分隔符组装成字符串
        /// </summary>
        /// <param name="list">字符串数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string GetListStrToString(this List<string> list,string separator)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    str.Append(list[i]);
                }
                else
                {
                    str.Append(list[i]);
                    str.Append(separator);
                }
            }
            return str.ToString();
        }

    }
}
