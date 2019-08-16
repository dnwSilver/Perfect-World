using System;

using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Ошибка при получении <see cref="Result" />.
    /// </summary>
    /// <remarks>
    ///     Для реализации данного интерфейса будем использовать шаблон IHasState.
    /// </remarks>
    [HasState]
    public interface IResultError : IFormattable
    {
    }
}
