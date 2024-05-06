using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustAttributes
{
    /// <summary>
    /// 列名特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ColumnAttribute:Attribute
    {   
        //列名
        public string Name { get; protected set; }

        public ColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}
