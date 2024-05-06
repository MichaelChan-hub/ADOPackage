using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PropertyHelper
    {
        /// <summary>
        /// 输入列名字符串获取对应的实体类属性名，并返回
        /// </summary>
        /// <typeparam name="T">实体类 </typeparam>
        /// <param name="cols">列名字符串，以逗号隔开</param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties<T>(string cols)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            if (!string.IsNullOrEmpty(cols))
            {
                List<string> listCols = cols.GetStrList(',', true);//转换成List<string>，并转换成小写
                properties = properties.Where(p => listCols.Contains(p.GetColName().ToLower())).ToArray();
            }
            return properties;
        }
    }
}
