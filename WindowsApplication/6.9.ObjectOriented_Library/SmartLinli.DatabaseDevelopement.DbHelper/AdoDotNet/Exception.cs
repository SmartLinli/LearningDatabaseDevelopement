using System;

namespace SmartLinli.DatabaseDevelopement
{
    /// <summary>
    /// 违反唯一性异常；
    /// </summary>
    public class NotUniqueException : Exception
    {
        /// <summary>
        /// 构造函数；
        /// </summary>
        public NotUniqueException() : base("当前写入记录与已有记录的键值重复，请修改数据后重试")
        {
            ;
        }
    }
}
