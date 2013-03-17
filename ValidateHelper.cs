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
    /// 验证帮助类
    /// </summary>
    public static class ValidateHelper
    {

        /// <summary>
        /// 验证
        /// </summary>
        public static Validation Valid
        {
            get
            {
                return Validation.Install;
            }
        }
    }
}
