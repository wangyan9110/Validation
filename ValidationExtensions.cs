/*********************************************************************************
 *
 * 功能描述：    验证表达式
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
    /// 验证表达式扩展类
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// 通用验证表达式
        /// </summary>
        /// <typeparam name="T">异常类型</typeparam>
        /// <param name="validation">验证对象</param>
        /// <param name="filterMethod">验证表达式</param>
        /// <param name="exception">异常</param>
        /// <returns>验证对象</returns>
        private static Validation Check<T>(this Validation validation, Func<bool> filterMethod, T exception) where T : Exception
        {
            if (filterMethod())
            {
                Validation valid=Validation.Install;
                valid.IsValid=true;
                return validation ?? valid;
            }
            else
            {
                throw exception;
            }
        }

        /// <summary>
        /// 参数验证
        /// </summary>
        /// <param name="validation">验证对象</param>
        /// <param name="filterMethod">验证表达式</param>
        /// <returns>验证对象</returns>
        public static Validation Check(this Validation validation, Func<bool> filterMethod)
        {
            return Check<Exception>(validation, filterMethod, new Exception("Parameter InValid"));
        }

        /// <summary>
        /// 判断参数是否为null
        /// </summary>
        /// <param name="validation">验证对象</param>
        /// <param name="obj">被验证对象</param>
        /// <returns>验证对象</returns>
        public static Validation IsNotNull(this Validation validation, object obj)
        {
            return Check<ArgumentNullException>(
                validation,
                () => obj != null,
                new ArgumentNullException(string.Format("参数{0},不能为null", obj)));
        }

        /// <summary>
        /// 判断参数是否为null或者为空
        /// </summary>
        /// <param name="validation">验证</param>
        /// <param name="str">被验证字符串</param>
        /// <returns>验证对象</returns>
        public static Validation IsNotNullOrEmpty(this Validation validation, string str)
        {
            return Check<ArgumentException>
                (
                 validation,
                 () => !(string.IsNullOrEmpty(str) && string.IsNullOrWhiteSpace(str)),
                 new ArgumentException(string.Format("参数{0}不能为空或者为null", str))
                );
        }

        /// <summary>
        /// 验证参数必须大于最小值
        /// </summary>
        /// <param name="validation">验证对象</param>
        /// <param name="arg">需要验证的参数</param>
        /// <param name="min">最小值</param>
        /// <returns>验证对象</returns>
        public static Validation IsGreaterThan(this Validation validation, int arg, int min)
        {
            return Check<ArgumentException>
            (validation,
            () =>
            {
                return arg > min;
            },
            new ArgumentException(string.Format("参数{0},要大于{1}", arg, min))
            );
        }

        /// <summary>
        /// 验证参数必须大于最小值或等于
        /// </summary>
        /// <param name="validation">验证对象</param>
        /// <param name="arg">需要验证的参数</param>
        /// <param name="min">最小值</param>
        /// <returns>验证对象</returns>
        public static Validation IsGreaterEqual(this Validation validation, int arg, int min)
        {
            return Check<ArgumentException>(validation,
           () =>
           {
               return arg >= min;
           },
           new ArgumentException(string.Format("参数{0},不能小于{1}", arg, min))
           );
        }
    }
}
