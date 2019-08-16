using System;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Ошибка при получении <see cref="Result" />.
    /// </summary>
    /// <remarks>
    ///     Для реализации данного интерфейса будем использовать шаблон IHasState.
    /// </remarks>
    public interface IResultError : IFormattable
    {
    }
}
