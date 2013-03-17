/*********************************************************************************
 *
 * 功能描述：    验证帮助类
 *
 * 作    者：    yywang
 *
 * 修改日期：    2013-03-17
 *
 * 版    本：    1.0.0.0
 * 
 * 备    注：    无
************************************************************************************/

namespace PMS.Common.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 验证类
    /// </summary>
    public sealed class Validation
    {
        private static Validation valid = null;

        /// <summary>
        /// 私有构造器
        /// </summary>
        private Validation() { }

        /// <summary>
        /// 获取验证
        /// </summary>
        public static Validation Install
        {
            get
            {
                if (valid == null)
                {
                    lock (typeof(Validation))
                    {
                        if (valid == null)
                        {
                            valid = new Validation();
                            return valid;
                        }
                    }
                }
                return valid;
            }
        }

        /// <summary>
        /// 是否验证通过
        /// </summary>
        public bool IsValid { get; set; }
    }
}
