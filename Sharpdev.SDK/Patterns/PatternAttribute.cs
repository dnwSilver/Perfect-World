using System;

namespace Sharpdev.SDK.Patterns
{
    /// <summary>
    ///     Шаблон проектирования.
    /// </summary>
    public class PatternAttribute : Attribute
    {
        /// <summary>
        ///     Название шаблона проектирования.
        /// </summary>
        /// <returns></returns>
        public string PatternName()
        {
            return GetType().Name;
        }
    }
}
