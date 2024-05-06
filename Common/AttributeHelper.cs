using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = Common.CustAttributes.ColumnAttribute;
using TableAttribute = Common.CustAttributes.TableAttribute;

namespace Common
{   
    /// <summary>
    /// 封装获取实体类中表名、主键、列名等映射的方法
    /// </summary>
    public static class AttributeHelper
    {   

        /// <summary>
        /// 获取类型对应的表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTName(this Type type)
        {
            string tableName = "";
            var attr = type.GetCustomAttribute<TableAttribute>(false);
            if (attr!=null)
            {
                tableName = attr.TableName;
            }
            else
                tableName = type.Name;
            return tableName;
        } 
        /// <summary>
        /// 获取属性映射的列名
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetColName(this PropertyInfo property)
        {
            string colName = "";
            var attr = property.GetCustomAttribute<ColumnAttribute>(false);
            if (attr != null)
            {
                colName = attr.Name;
            }
            else
                colName = property.Name;
            return colName;
        }
        /// <summary>
        /// 获取主键名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetPKName(this Type type)
        {
            string priName = "";
            var attr = type.GetCustomAttribute<PrimaryKeyAttribute>(false);
            if (attr != null)
            {
                priName = attr.Name;
            }
            else
                priName = attr.Name;
            return priName;
        }

        /// <summary>
        /// 判断指定属性是否为主键
        /// </summary>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsPrimaryKey(this PropertyInfo property)
        {
            Type type = property.DeclaringType;
            string primaryKey = type.GetPKName();//获取该类型的主键名
            string colName = property.GetColName();//获取该属性的映射列名
            return (primaryKey == colName);
        }
        /// <summary>
        /// 判断主键是否自增
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAutoIncrement(this Type type)
        {
            var attr = type.GetCustomAttribute<PrimaryKeyAttribute>(false);//获取此类型上所有自定义特性
            if (attr != null)
            {
                return attr.autoIncrement;
            }
            return false;
        }

    }
}
