using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustAttributes
{
    /// <summary>
    /// 主键特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PrimaryKeyAttribute:Attribute
    {   
        //主键名
        public string Name { get;protected set; }
        //是否自增
        public bool autoIncrement = false;

        public PrimaryKeyAttribute(string name)
        {
            this.Name = name; 
        }
    }
}
