using System;

namespace Sharpdev.SDK.Layers.Infrastructure.Repositories
{
    /// <summary>
    ///     Параметр для поиска.
    /// </summary>
    /// <typeparam name="TParameterType">Тип данных.</typeparam>
    public interface IScalarParameter<out TParameterType>
    {
        /// <summary>
        ///     Используется ли параметр для поиска?
        /// </summary>
        bool IsUsed { get; }

        /// <summary>
        ///     Значение параметра для поиска.
        /// </summary>
        TParameterType Value { get; }

        /// <summary>
        ///     Тип параметра.
        /// </summary>
        Type GetType { get; }
    }
}
